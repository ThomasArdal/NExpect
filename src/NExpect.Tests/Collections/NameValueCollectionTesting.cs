﻿using System.Collections.Specialized;
using NUnit.Framework;
using static PeanutButter.RandomGenerators.RandomValueGen;
using NExpect.Exceptions;
using NExpect.Implementations;
using static NExpect.Expectations;
// ReSharper disable InconsistentNaming
// ReSharper disable ExpressionIsAlwaysNull

namespace NExpect.Tests.Collections
{
    [TestFixture]
    public class NameValueCollectionTesting
    {
        [TestFixture]
        public class Expect_NameValueCollection_To_Contain
        {
            [TestFixture]
            public class Key
            {
                [TestFixture]
                public class OperatingOnPlainNameValueCollection
                {
                    [Test]
                    public void WhenHasKey_ShouldNotThrow()
                    {
                        // Arrange
                        var key = GetRandomString(2);
                        var src = new NameValueCollection();
                        src[key] = GetRandomString();
                        // Pre-Assert

                        // Act
                        Assert.That(() =>
                            {
                                Expect(src).To.Contain.Key(key);
                            },
                            Throws.Nothing);

                        // Assert
                    }

                    [Test]
                    public void Negated_WhenHasKey_ShouldThrow()
                    {
                        // Arrange
                        var key = GetRandomString(2);
                        var src = new NameValueCollection()
                        {
                            [key] = GetRandomString()
                        };
                        // Pre-Assert

                        // Act
                        Assert.That(() =>
                            {
                                Expect(src).Not.To.Contain.Key(key);
                            },
                            Throws.Exception.InstanceOf<UnmetExpectationException>()
                                .With.Message.Contains(
                                    $"not to contain key {key.Stringify()}"
                                ));

                        // Assert
                    }

                    [Test]
                    public void Negated_Alt_WhenHasKey_ShouldThrow()
                    {
                        // Arrange
                        var key = GetRandomString(2);
                        var src = new NameValueCollection()
                        {
                            [key] = GetRandomString()
                        };
                        // Pre-Assert

                        // Act
                        Assert.That(() =>
                            {
                                Expect(src).To.Not.Contain.Key(key);
                            },
                            Throws.Exception.InstanceOf<UnmetExpectationException>()
                                .With.Message.Contains(
                                    $"not to contain key {key.Stringify()}"
                                ));

                        // Assert
                    }
                    
                    [TestFixture]
                    public class WithValue
                    {
                        [TestFixture]
                        public class OperatingOnPrimitiveTypes
                        {
                            [Test]
                            public void WhenHasKey_AndValueMatches_ShouldNotThrow()
                            {
                                // Arrange
                                var key = GetRandomString(2);
                                var value = GetRandomString(2);
                                var src = new NameValueCollection()
                                {
                                    [key] = value
                                };
                                // Pre-Assert

                                // Act
                                Assert.That(() =>
                                    {
                                        Expect(src).To.Contain.Key(key).With.Value(value);
                                    },
                                    Throws.Nothing);

                                // Assert
                            }

                            [Test]
                            public void WhenDoesNotHaveKey_ShouldThrowForThatReason()
                            {
                                // Arrange
                                var key = GetRandomString(2);
                                var value = GetRandomString(2);
                                var src = new NameValueCollection()
                                {
                                    [key] = value
                                };
                                var testingValue = GetAnother(key);
                                // Pre-Assert

                                // Act
                                Assert.That(() =>
                                    {
                                        Expect(src).To.Contain.Key(testingValue).With.Value(value);
                                    },
                                    Throws.Exception.TypeOf<UnmetExpectationException>()
                                        .With.Message.Contains($"to contain key \"{testingValue}\""));

                                // Assert
                            }

                            [Test]
                            public void WhenHasKey_AndValueDoesNotMatch_ShouldThrow()
                            {
                                // Arrange
                                var key = GetRandomString(2);
                                var value = GetRandomString(2);
                                var src = new NameValueCollection()
                                {
                                    [key] = value
                                };
                                var testingValue = GetAnother(value);
                                // Pre-Assert

                                // Act
                                Assert.That(() =>
                                    {
                                        Expect(src).To.Contain.Key(key).With.Value(testingValue);
                                    },
                                    Throws.Exception.TypeOf<UnmetExpectationException>()
                                        .With.Message.Contains($"Expected \"{testingValue}\" but got \"{value}\""));

                                // Assert
                            }
                        }


                    }
                }
            }
        }
    }
}