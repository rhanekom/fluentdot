/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Expressions.Edges;
using FluentDot.Expressions.Nodes;
using FluentDot.Expressions.Shared;

namespace FluentDot.Expressions.Graphs {

    /// <summary>
    /// An expression for selecting the type of defaults to set.
    /// </summary>
    public interface IDefaultsExpression {

        /// <summary>
        /// Configures the default values for nodes.
        /// </summary>
        /// <value>The configuratione expression for nodes.</value>
        IMultiActionExpression<INodeExpression, IGraphExpression> ForNodes { get; }

        /// <summary>
        /// Configures the default values for edges.
        /// </summary>
        /// <value>The configuratione expression for edges.</value>
        IMultiActionExpression<IEdgeExpression, IGraphExpression> ForEdges { get; }
    }
}
