//-----------------------------------------------------------------------
// <copyright file="AssertionsTests.cs" company="Akka.NET Project">
//     Copyright (C) 2013-2022 Akka.NET project <https://github.com/akkadotnet/akka.net>
// </copyright>
//-----------------------------------------------------------------------

using Akka.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Akka.TestKit.MsTest.Tests
{
    [TestClass]
    public class AssertionsTests
    {
        private MsTestAssertions? _assertions;

        [TestInitialize]
        public void SetUp()
        {
            _assertions = new MsTestAssertions();
        }

        [TestMethod]
        public void Fail_should_throw()
        {
            Assert.ThrowsExactly<AssertFailedException>(() => _assertions!.Fail());
        }

        [TestMethod]
        public void AssertTrue_should_throw_on_false()
        {
            Assert.ThrowsExactly<AssertFailedException>(() => _assertions!.AssertTrue(false));
        }

        [TestMethod]
        public void AssertTrue_should_succeed_on_true()
        {
            _assertions!.AssertTrue(true);
        }

        [TestMethod]
        public void AssertFalse_should_throw_on_true()
        {
            Assert.ThrowsExactly<AssertFailedException>(() => _assertions!.AssertFalse(true));
        }

        [TestMethod]
        public void AssertFalse_should_succeed_on_false()
        {
            _assertions!.AssertFalse(false);
        }


        [TestMethod]
        public void AssertEqual_should_throw_on_not_equal()
        {
            Assert.ThrowsExactly<AssertFailedException>(() => _assertions!.AssertEqual(42, 4711));
        }

        [TestMethod]
        public void AssertEqual_should_succeed_on_equal()
        {
            _assertions!.AssertEqual(42, 42);
        }


        [TestMethod]
        public void AssertEqualWithComparer_should_throw_on_not_equal()
        {
            Assert.ThrowsExactly<AssertFailedException>(() => _assertions!.AssertEqual(42, 1142, Comparer));
        }

        [TestMethod]
        public void AssertEqualWithComparer_should_succeed_on_equal()
        {
            _assertions!.AssertEqual(42, 42, Comparer);
        }

        private bool Comparer(int a, int b) => a == b;

        [TestMethod]
        [DynamicData(nameof(ExceptionData), DynamicDataSourceType.Method)]
        public void Generic_AssertThrows_should_succeed_only_on_specific_exception(Exception exception)
        {
            if (exception is ConfigurationException ex)
            {
                // Should pass and return the same exception instance
                var returned = _assertions!.AssertThrows<ConfigurationException>(ThisThrows);
                Assert.AreEqual(ex, returned);
            }
            else
            {
                // Should fail the assertion since it's not the expected type
                Assert.ThrowsExactly<AssertFailedException>(() =>
                    _assertions!.AssertThrows<ConfigurationException>(ThisThrows));
            }

            void ThisThrows()
            {
                throw exception;
            }
        }

        [TestMethod]
        [DynamicData(nameof(ExceptionData), DynamicDataSourceType.Method)]
        public async Task Generic_AssertThrows_should_succeed_only_on_specific_exception_async(Exception exception)
        {
            if (exception is ConfigurationException ex)
            {
                var returned = await _assertions!.AssertThrowsAsync<ConfigurationException>(ThisThrows);
                Assert.AreEqual(ex, returned);
            }
            else
            {
                await Assert.ThrowsExactlyAsync<AssertFailedException>(async () =>
                    await _assertions!.AssertThrowsAsync<ConfigurationException>(ThisThrows));
            }

            async Task ThisThrows()
            {
                await Task.Yield();
                throw exception;
            }
        }

        [TestMethod]
        public void Generic_AssertThrows_should_fail_when_no_exception_was_thrown()
        {
            Assert.ThrowsExactly<AssertFailedException>(() =>
                _assertions!.AssertThrows<ConfigurationException>(ThisDoesNotThrow));

            void ThisDoesNotThrow()
            {
            }
        }

        [TestMethod]
        public async Task Generic_AssertThrows_should_fail_when_no_exception_was_thrown_async()
        {
            await Assert.ThrowsExactlyAsync<AssertFailedException>(async () =>
                await _assertions!.AssertThrowsAsync<ConfigurationException>(ThisDoesNotThrow));

            async Task ThisDoesNotThrow()
            {
                await Task.Yield();
            }
        }

        // Dynamic data source
        public static IEnumerable<object[]> ExceptionData()
        {
            yield return [new Exception("Wheee")];
            yield return [new ConfigurationException("Wheee")];
            yield return [new TimeoutException("Wheee")];
            yield return [new OperationCanceledException("Wheee")];
        }
    }
}

