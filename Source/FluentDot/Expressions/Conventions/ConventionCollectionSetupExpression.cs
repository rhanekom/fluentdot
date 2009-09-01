/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using FluentDot.Conventions;

namespace FluentDot.Expressions.Conventions
{
    /// <summary>
    /// A concrete implementation of a <see cref="IConventionCollectionSetupExpression"/>.
    /// </summary>
    public class ConventionCollectionSetupExpression : IConventionCollectionSetupExpression
    {
        #region Globals

        private readonly IConventionTracker conventionTracker;

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="ConventionCollectionSetupExpression"/> class.
        /// </summary>
        /// <param name="conventionTracker">The convention tracker.</param>
        public ConventionCollectionSetupExpression(IConventionTracker conventionTracker)
        {
            this.conventionTracker = conventionTracker;
        }

        #endregion

        #region IConventionCollectionSetupExpression Members

        /// <summary>
        /// Adds the specified type as a convention.
        /// </summary>
        /// <typeparam name="T">The type of convention to add.</typeparam>
        /// <returns>The current expression instance.</returns>
        public IConventionCollectionSetupExpression AddType<T>() where T : IConvention, new()
        {
            var instance = new T();
            AddInstance(instance);
            return this;
        }

        /// <summary>
        /// Adds the specified convention instance to the collection.
        /// </summary>
        /// <typeparam name="T">The type of convention to add.</typeparam>
        /// <param name="instance">The instance of the convention to add.</param>
        /// <returns>The current expression instance.</returns>
        public IConventionCollectionSetupExpression AddInstance<T>(T instance) where T : IConvention
        {
            if (typeof(INodeConvention).IsAssignableFrom(typeof(T))) 
            {
                conventionTracker.AddConvention((INodeConvention)Activator.CreateInstance<T>());
            } 
            else if (typeof(IEdgeConvention).IsAssignableFrom(typeof(T))) 
            {
                conventionTracker.AddConvention((IEdgeConvention)Activator.CreateInstance<T>());
            } 
            else {
                throw new ArgumentException("Conventions can only be of type INodeConvention or IEdgeConvention.");
            }

            return this;
        }

        #endregion
    }
}