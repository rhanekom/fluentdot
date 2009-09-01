/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using FluentDot.Configuration;
using FluentDot.Entities.Graphs;
using FluentDot.Expressions.Configuration;
using FluentDot.Expressions.Graphs;

namespace FluentDot {
    
    /// <summary>
    /// The entry point for FluentDot operations.
    /// </summary>
    public static class Fluently {
        
        /// <summary>
        /// Creates a new directed graph.
        /// </summary>
        /// <returns>A new instance of a directed graph.</returns>
        public static IGraphExpression CreateDirectedGraph() 
        {
            return new GraphExpression<IDirectedGraph>(new DirectedGraph { Name = "DirectedGraph"});
        }

        /// <summary>
        /// Creates a new undirected graph.
        /// </summary>
        /// <returns>A new instance of an undirected graph.</returns>
        public static IGraphExpression CreateUndirectedGraph()
        {
            return new GraphExpression<IUndirectedGraph>(new UndirectedGraph { Name = "UndirectedGraph" });
        }

        /// <summary>
        /// Configures the FluentDot environment.
        /// </summary>
        /// <returns>A configuration expression, used to configure the FluentDot environment.</returns>
        public static void Configure(Action<IConfigurationExpression> configurationAction)
        {
            if (configurationAction == null)
            {
                throw new ArgumentNullException("configurationAction");
            }

            configurationAction(new ConfigurationExpression(GlobalConfiguration.Instance));
        }
    }
}
