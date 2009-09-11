/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using FluentDot.Execution;
using FluentDot.Samples.Core.Demos;

namespace FluentDot.Samples.Exporter
{
    public class SampleExporter
    {
        #region Globals

        private readonly FileHasher hasher = new FileHasher();

        #endregion

        #region Construction

        public SampleExporter()
        {
            Fluently.Configure(x => x.DotFilePath.Is(@"C:\Program Files\Graphviz 2.21\bin\dot.exe"));
        }

        #endregion

        #region Public Members

        public void Export(string exportDirectory)
        {
            int updateCount = 0;

            IList<IGraphDemo> demos = DemoRegister.GetDemos();

            var toc = new Dictionary<DemoType, List<WikiLink>>
                          {
                              {DemoType.API, new List<WikiLink>()},
                              {DemoType.Layout, new List<WikiLink>()},
                              {DemoType.SimpleGraphs, new List<WikiLink>()},
                              {DemoType.VisualElements, new List<WikiLink>()}
                          };

            foreach (var d in demos)
            {
                toc[d.Type].Add(new WikiLink {DisplayText = d.FriendlyName, WikiPage = "Demo" + d.GetType().Name});

                if (ExportDemo(d, exportDirectory))
                {
                    updateCount++;
                }
            }

            ExportTOC(exportDirectory, toc);

            Console.WriteLine("Files updated : {0}.", updateCount);
        }
        
        #endregion

        #region Private Members

        private void ExportTOC(string exportDirectory, Dictionary<DemoType, List<WikiLink>> toc)
        {
            string tocContent = File.ReadAllText("TOCTemplate.wiki");
            
            foreach (DemoType type in Enum.GetValues(typeof(DemoType)))
            {
                List<WikiLink> links;
                
                if (toc.TryGetValue(type, out links))
                {
                    links.Sort((x, y) => x.DisplayText.CompareTo(y.DisplayText));

                    var linkContent = new StringBuilder();
                    
                    foreach (var l in links)
                    {
                        linkContent.AppendLine("  * [" + l.WikiPage + " " + l.DisplayText + "]");
                    }

                    tocContent = tocContent.Replace("${" + type + "}", linkContent.ToString());
                }
                else
                {
                    tocContent = tocContent.Replace("${" + type + "}", String.Empty);
                }
            }


            var tocFile = Path.GetTempFileName();
            string tocExportFilePath = Path.Combine(exportDirectory, "Demos.wiki");

            try
            {
                File.WriteAllText(tocFile, tocContent);

                if (ReplaceFile(tocFile, tocExportFilePath))
                {
                    Console.WriteLine("TOC replaced.");
                }
            }
            finally
            {
                SafeDelete(tocFile);
            }

        }

        private bool ExportDemo(IGraphDemo demo, string exportDirectory)
        {
            bool updated = false;

            Console.WriteLine("Exporting demo : {0}.", demo.GetType().Name);
            var graphExpression = demo.GetGraph();

            if (!Directory.Exists(exportDirectory))
            {
                Directory.CreateDirectory(exportDirectory);
            }
            string imageDirectory = Path.Combine(exportDirectory, "Images");

            if (!Directory.Exists(imageDirectory))
            {
                Directory.CreateDirectory(imageDirectory);
            }

            string exportImageFile = Path.Combine(imageDirectory, "Demo" +  demo.GetType().Name + ".png");
            string exportTemplateFile = Path.Combine(exportDirectory, "Demo" + demo.GetType().Name + ".wiki");

            var dotFile = Path.GetTempFileName();
            var imageFile = Path.GetTempFileName();
            var templateFile = Path.GetTempFileName();

            try
            {
                string dot = graphExpression.GenerateDot();

                string codeFile =
                    Path.GetFullPath(string.Format(@"..\..\..\FluentDot.Samples.Core\Demos\{0}\{1}.cs", demo.Type,
                                                   demo.GetType().Name));

                graphExpression.Save(x => x.ToFile(imageFile).UsingFormat(OutputFormat.PNG));

                WriteTemplate(templateFile, exportImageFile, demo, dot, GetCode(codeFile));

                if ((ReplaceFile(imageFile, exportImageFile) | (ReplaceFile(templateFile, exportTemplateFile))))
                {
                    updated = true;
                }
            }
            finally
            {
                SafeDelete(dotFile);
                SafeDelete(imageFile);
                SafeDelete(templateFile);
            }

            return updated;
        }

        private string GetCode(string codeFile)
        {
            string content = File.ReadAllText(codeFile);

            int index = content.IndexOf("#region ExportCode");

            if (index < 0)
            {
                Console.WriteLine("Could not find code block for {0}.", codeFile);
                return String.Empty;
            }
            
            var lines = content.Substring(index).Split(new [] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            var sb = new StringBuilder();

            // yuck.
            for (int i = 1; i< lines.Length; i++)
            {
                if (Regex.Match(lines[i], @"^(\ )*\#endregion(\ )*$", RegexOptions.Singleline).Success)
                {
                    break;
                }
                
                sb.AppendLine(lines[i]);
            }

            return sb.ToString();
        }

        private bool ReplaceFile(string fromFile, string toFile)
        {
            Console.Write("Checking file {0} for changes : ", toFile);

            if (File.Exists(toFile))
            {
                if (!hasher.AreSame(fromFile, toFile))
                {
                    Console.WriteLine("file changed - copying.");
                    File.Copy(fromFile, toFile, true);
                    return true;
                }
            }
            else
            {
                Console.WriteLine("file not found - copying.");
                File.Copy(fromFile, toFile, true);
                return true;
            }

            Console.WriteLine("not changed.");
            return false;
        }

        private void WriteTemplate(string templateFile, string imagePath, IGraphDemo demo, string dot, string code)
        {
            // Start with our template
            string template = File.ReadAllText("Template.wiki");

            template = template.Replace("${DemoName}", demo.FriendlyName);
            template = template.Replace("${DemoDescription}", demo.Description);
            template = template.Replace("${Dot}", dot);
            template = template.Replace("${ImageFileName}", Path.GetFileName(imagePath));
            template = template.Replace("${Code}", code);

            File.WriteAllText(templateFile, template);
        }

        private void SafeDelete(string fileName)
        {
            try
            {
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
            }
            catch  (Exception ex)
            {
                Console.WriteLine("Could not delete file {0} - {1}.", fileName, ex.Message);
            }
        }

        #endregion
    }
}
    