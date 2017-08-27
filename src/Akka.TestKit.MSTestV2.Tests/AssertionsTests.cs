﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Akka.TestKit.MSTestV2.Tests
{
    [TestClass]
    public class AssertionsTests
    {
        private MSTestAssertions _assertions;

        public AssertionsTests()
        {
            _assertions = new MSTestAssertions();
        }

        [TestMethod]
        [ExpectedException(typeof(AssertFailedException))]
        public void Fail_should_throw()
        {
            _assertions.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AssertFailedException))]
        public void AssertTrue_should_throw_on_false()
        {
            _assertions.AssertTrue(false);
        }

        [TestMethod]
        public void AssertTrue_should_succeed_on_true()
        {
            _assertions.AssertTrue(true);
        }

        [TestMethod]
        [ExpectedException(typeof(AssertFailedException))]
        public void AssertFalse_should_throw_on_true()
        {
            _assertions.AssertFalse(true);
        }

        [TestMethod]
        public void AssertFalse_should_succeed_on_false()
        {
            _assertions.AssertFalse(false);
        }


        [TestMethod]
        [ExpectedException(typeof(AssertFailedException))]
        public void AssertEqual_should_throw_on_not_equal()
        {
            _assertions.AssertEqual(42, 4711);
        }

        [TestMethod]
        public void AssertEqual_should_succeed_on_equal()
        {
            _assertions.AssertEqual(42, 42);
        }


        [TestMethod]
        [ExpectedException(typeof(AssertFailedException))]
        public void AssertEqualWithComparer_should_throw_on_not_equal()
        {
            _assertions.AssertEqual(42, 42, (x, y) => false);
        }

        [TestMethod]
        public void AssertEqualWithComparer_should_succeed_on_equal()
        {
            _assertions.AssertEqual(42, 4711, (x, y) => true);
        }

    }
}
