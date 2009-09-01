/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;

namespace FluentDot.Expressions.Conventions
{
    /// <summary>
    /// An expression for modifying a collection of conventions.
    /// </summary>
    public interface IConventionCollectionModifiersExpression<T> {

        /// <summary>
        /// Adds the conventions configured by the specified add expression.
        /// </summary>
        /// <param name="setupExpression">The setup expression.</param>
        /// <returns>The parent expression instance.</returns>
        T Setup(Action<IConventionCollectionSetupExpression> setupExpression);
    }
}