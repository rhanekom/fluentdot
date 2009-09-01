/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Conventions;

namespace FluentDot.Expressions.Conventions
{
    /// <summary>
    /// Sets us the conventions for a graph.
    /// </summary>
    public interface IConventionCollectionSetupExpression
    {
        /// <summary>
        /// Adds the specified type as a convention.
        /// </summary>
        /// <typeparam name="T">The type of convention to add.</typeparam>
        /// <returns>The current expression instance.</returns>
        IConventionCollectionSetupExpression AddType<T>() where T : IConvention, new();

        /// <summary>
        /// Adds the specified convention instance to the collection.
        /// </summary>
        /// <typeparam name="T">The type of convention to add.</typeparam>
        /// <param name="instance">The instance of the convention to add.</param>
        /// <returns>The current expression instance.</returns>
        IConventionCollectionSetupExpression AddInstance<T>(T instance) where T : IConvention;
    }
}
