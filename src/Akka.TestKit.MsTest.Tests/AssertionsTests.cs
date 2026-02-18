//-----------------------------------------------------------------------
// <copyright file="AssertionsTests.cs" company="Akka.NET Project">
//     Copyright (C) 2013-2022 Akka.NET project <https://github.com/akkadotnet/akka.net>
// </copyright>
//-----------------------------------------------------------------------

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
            Assert.ThrowsExactly<AssertFailedException>(() => _assertions!.AssertEqual(42, 42, (x, y) => false));
        }

        [TestMethod]
        public void AssertEqualWithComparer_should_succeed_on_equal()
        {
            _assertions!.AssertEqual(42, 4711,(x,y)=>true);
        }

    }
}

