/*
 Copyright 2012 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


namespace FluentDot.Samples.Exporter
{
    using System;
    
    public class Program
    {
        #region Main

        public static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                PrintUsage();
            }
            else
            {
                new SampleExporter().Export(args[0]);
                Console.WriteLine("Done.");
                Console.ReadLine();
            }
        }

        #endregion

        #region Private Members

        private static void PrintUsage()
        {
            Console.WriteLine("Usage :");
            Console.WriteLine("FluentDot.Samples.Exporter [exportDirectory]");
            Console.WriteLine();
        }

        #endregion
    }
}
