﻿/*
 Copyright 2012 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using FluentDot.Attributes.Shared;
using FluentDot.Entities;
using FluentDot.Entities.Nodes;
using Moq;
using NUnit.Framework;

namespace FluentDot.Tests.Entities {

    [TestFixture]
    public class EntityDefaultsBaseTests {

        [Test]
        public void Constructor_Should_Throw_If_Invalid_Name_Specified()
        {
            Assert.Throws<ArgumentException>(() => new EntityDefaultsBase(null, new Mock<IAttributeBasedEntity>().Object));
        }

        [Test]
        public void Constructor_Should_Throw_If_Invalid_Template_Specified()
        {
            Assert.Throws<ArgumentNullException>(() => new EntityDefaultsBase("name", null));
        }

        [Test]
        public void ToDot_Should_Use_Name_And_Attributes_Of_Template()
        {
            var node = new GraphNode("name");
            node.Attributes.AddAttribute(new LabelAttribute("label"));
            node.Attributes.AddAttribute(new URLAttribute("http://www.google.com"));

            var defaults = new EntityDefaultsBase("entity", node);
            Assert.AreEqual(defaults.ToDot(), "entity [label=\"label\", URL=\"http://www.google.com\"]");
        }
    }
}
