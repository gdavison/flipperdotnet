﻿using System.Collections.Generic;
using FlipperDotNet.Gate;
using NUnit.Framework;

namespace FlipperDotNet.Tests
{
    [TestFixture]
    public class GateValuesTests
    {
        [TestCase(null, ExpectedResult = false)]
        [TestCase(false, ExpectedResult = false)]
        [TestCase(true, ExpectedResult = true)]
        public bool ShouldReturnBooleanValue(bool? input)
        {
            var adapterValues = new Dictionary<string, object> {{BooleanGate.KEY, input}};
            var gateValues = new GateValues(adapterValues);
            return gateValues.Boolean;
        }

        [TestCase(0, ExpectedResult = 0)]
        [TestCase(1, ExpectedResult = 1)]
        public int ShouldReturnPercentageOfTimeValue(int input)
        {
            var adapterValues = new Dictionary<string, object> {{PercentageOfTimeGate.KEY, input}};
            var gateValues = new GateValues(adapterValues);
            return gateValues.PercentageOfTime;
        }

        [TestCase(0, ExpectedResult = 0)]
        [TestCase(1, ExpectedResult = 1)]
        public int ShouldReturnPercentageOfActorsValue(int input)
        {
            var adapterValues = new Dictionary<string, object> {{PercentageOfActorsGate.KEY, input}};
            var gateValues = new GateValues(adapterValues);
            return gateValues.PercentageOfActors;
        }

        [Test]
        public void ShouldRetrieveTheBooleanValue()
        {
            var adapterValues = new Dictionary<string, object> {{BooleanGate.KEY, true}};
            var gateValues = new GateValues(adapterValues);
            Assert.That(gateValues[BooleanGate.KEY], Is.EqualTo(true));
        }

        [Test]
        public void ShouldRetrieveTheActorsValue()
        {
            var adapterValues = new Dictionary<string, object> {{ActorGate.KEY, new HashSet<string> {"1", "2"}}};
            var gateValues = new GateValues(adapterValues);
            Assert.That(gateValues[ActorGate.KEY], Is.EquivalentTo(new[] {"1", "2"}));
        }

        [Test]
        public void ShouldRetrieveTheGroupsValue()
        {
            var adapterValues = new Dictionary<string, object> {{GroupGate.KEY, new HashSet<string> {"admins"}}};
            var gateValues = new GateValues(adapterValues);
            Assert.That(gateValues[GroupGate.KEY], Is.EquivalentTo(new[] {"admins"}));
        }

        [Test]
        public void ShouldRetrieveThePercentageOfTimeValue()
        {
            var adapterValues = new Dictionary<string, object> {{PercentageOfTimeGate.KEY, 15}};
            var gateValues = new GateValues(adapterValues);
            Assert.That(gateValues[PercentageOfTimeGate.KEY], Is.EqualTo(15));
        }

        [Test]
        public void ShouldRetrieveThePercentageOfActorsValue()
        {
            var adapterValues = new Dictionary<string, object> {{PercentageOfActorsGate.KEY, 25}};
            var gateValues = new GateValues(adapterValues);
            Assert.That(gateValues[PercentageOfActorsGate.KEY], Is.EqualTo(25));
        }

        [Test]
        public void ShouldReturnNullForNonExistantValue()
        {
            var adapterValues = new Dictionary<string, object>();
            var gateValues = new GateValues(adapterValues);
            Assert.That(gateValues["foo"], Is.Null);
        }
    }
}
