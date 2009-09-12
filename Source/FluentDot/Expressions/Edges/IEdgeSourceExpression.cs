/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using FluentDot.Expressions.Nodes;

namespace FluentDot.Expressions.Edges
{
    /// <summary>
    /// An expression for specifying the source of an edge.
    /// </summary>
    public interface IEdgeSourceExpression {

        /// <summary>
        /// Selects a node by name to be the source of the edge.
        /// </summary>
        /// <param name="name">The name of the node to choose as the source of the edge.</param>
        /// <returns>An expression to choose the destination of the edge.</returns>
        IEdgeDestinationSelectionExpression FromNodeWithName(string name);

        /// <summary>
        /// Selects a node by tag to be the source of the edge.
        /// </summary>
        /// <typeparam name="T">The type of tag.</typeparam>
        /// <param name="tag">The tag to match.</param>
        /// <returns>An expression to choose the destination of the edge.</returns>
        IEdgeDestinationSelectionExpression FromNodeWithTag<T>(T tag);

        /// <summary>
        /// Selects a record by name to be the source of the edge.
        /// </summary>
        /// <param name="name">The name of the record to choose as the source of the edge.</param>
        /// <param name="elementName">Name of the element.</param>
        /// <returns>An expression to choose the destination of the edge.</returns>
        IEdgeDestinationSelectionExpression FromRecordWithName(string name, string elementName);

        /// <summary>
        /// Selects a record by tag to be the source of the edge.
        /// </summary>
        /// <typeparam name="T">The type of tag.</typeparam>
        /// <param name="tag">The tag to match.</param>
        /// <param name="elementName">Name of the element.</param>
        /// <returns>An expression to choose the destination of the edge.</returns>
        IEdgeDestinationSelectionExpression FromRecordWithTag<T>(T tag, string elementName);

        /// <summary>
        /// Selects a node by creating a new one to be the source of the edge.
        /// </summary>
        /// <param name="nodeName">Name of the node.</param>
        /// <returns>An expression to choose the destination of the edge.</returns>
        IEdgeDestinationSelectionExpression FromNewNode(string nodeName);

        /// <summary>
        /// Selects a node by creating a new one to be the source of the edge.
        /// </summary>
        /// <param name="nodeName">Name of the node.</param>
        /// <param name="nodeConfiguration">The node configuration to apply to the node.</param>
        /// <returns>An expression to choose the destination of the edge.</returns>
        IEdgeDestinationSelectionExpression FromNewNode(string nodeName, Action<INodeExpression> nodeConfiguration);
    }
}