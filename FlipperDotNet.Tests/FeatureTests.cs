﻿using FlipperDotNet.Adapter;
using NUnit.Framework;
using Rhino.Mocks;

namespace FlipperDotNet.Tests
{
    [TestFixture]
    class FeatureTests
    {
        [Test]
        public void ConstructorShouldSetName()
        {
            const string name = "Test";
            var feature = new Feature(name, null);
            Assert.That(feature.Name, Is.EqualTo(name));
        }

        [Test]
        public void ConstructorShouldSetAdapter()
        {
            var adapter = MockRepository.GenerateStub<IAdapter>();
            var feature = new Feature("Name", adapter);
            Assert.That(feature.Adapter, Is.EqualTo(adapter));
        }
    }

    [TestFixture]
    public class EnabledFeatureTests
    {
        private Feature _feature;

        [SetUp]
        public void SetUp()
        {
            _feature = new Feature("Test", new MemoryAdapter());
            _feature.Enable();
        }

        [Test]
        public void ShouldReturnStateOfOn()
        {
            Assert.That(_feature.State, Is.EqualTo(FeatureState.On));
        }

        [Test]
        public void ShouldReturnTrueForIsOn()
        {
            Assert.That(_feature.IsOn, Is.True);
        }

        [Test]
        public void ShouldReturnFalseForIsOff()
        {
            Assert.That(_feature.IsOff, Is.False);
        }

        [Test]
        public void ShouldReturnFalseForIsConditional()
        {
            Assert.That(_feature.IsConditional, Is.False);
        }
    }

    [TestFixture]
    public class PercentageOfTime100Tests
    {
        private Feature _feature;

        [SetUp]
        public void SetUp()
        {
            _feature = new Feature("Test", new MemoryAdapter());
            _feature.EnablePercentageOfTime(100);
        }

        [Test]
        public void ShouldReturnStateOfOn()
        {
            Assert.That(_feature.State, Is.EqualTo(FeatureState.On));
        }

        [Test]
        public void ShouldReturnTrueForIsOn()
        {
            Assert.That(_feature.IsOn, Is.True);
        }

        [Test]
        public void ShouldReturnFalseForIsOff()
        {
            Assert.That(_feature.IsOff, Is.False);
        }

        [Test]
        public void ShouldReturnFalseForIsConditional()
        {
            Assert.That(_feature.IsConditional, Is.False);
        }
    }

    [TestFixture]
    public class FeatureBooleanValueTests
    {
        private Feature _feature;

        [SetUp]
        public void SetUp()
        {
            _feature = new Feature("Test", new MemoryAdapter());
        }

        [Test]
        public void ShouldDefaultToFalse()
        {
            Assert.That(_feature.BooleanValue, Is.False);
        }

        [Test]
        public void ShouldReturnTrueWhenEnabled()
        {
            _feature.Enable();
            Assert.That(_feature.BooleanValue, Is.True);
        }

        [Test]
        public void ShouldReturnFalseWhenDisabled()
        {
            _feature.Disable();
            Assert.That(_feature.BooleanValue, Is.False);
        }
    }

    [TestFixture]
    public class FeaturePercentageOfTimeValueTests
    {
        private Feature _feature;

        [SetUp]
        public void SetUp()
        {
            _feature = new Feature("Test", new MemoryAdapter());
        }

        [Test]
        public void ShouldDefaultToZero()
        {
            Assert.That(_feature.PercentageOfTimeValue, Is.EqualTo(0));
        }

        [Test]
        public void ShouldReturnValueWhenEnabled()
        {
            _feature.EnablePercentageOfTime(5);
            Assert.That(_feature.PercentageOfTimeValue, Is.EqualTo(5));
        }

        [Test]
        public void ShouldReturnZeroWhenDisabled()
        {
            _feature.Disable();
            Assert.That(_feature.PercentageOfTimeValue, Is.EqualTo(0));
        }
    }
}
