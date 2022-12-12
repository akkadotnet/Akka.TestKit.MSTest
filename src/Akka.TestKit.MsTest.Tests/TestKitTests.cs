//-----------------------------------------------------------------------
// <copyright file="TestKitTests.cs" company="Akka.NET Project">
//     Copyright (C) 2009-2022 Typesafe Inc. <http://www.typesafe.com>
//     Copyright (C) 2013-2022 Akka.NET project <https://github.com/akkadotnet/akka.net>
// </copyright>
//-----------------------------------------------------------------------

using Akka.Actor;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Akka.TestKit.MsTest.Tests
{
    [TestClass]
    public class TestKitTests : TestKit
    {
        [TestCleanup]
        public void Cleanup()
        {
            Shutdown();
        }

        [TestMethod]
        public void Expect_a_message()
        {
            TestActor.Tell("Test");
            ExpectMsg("Test");
        }
    }
}

