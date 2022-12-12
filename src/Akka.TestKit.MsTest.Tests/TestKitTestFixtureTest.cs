//-----------------------------------------------------------------------
// <copyright file="TestKitTests.cs" company="Akka.NET Project">
//     Copyright (C) 2009-2022 Typesafe Inc. <http://www.typesafe.com>
//     Copyright (C) 2013-2022 Akka.NET project <https://github.com/akkadotnet/akka.net>
// </copyright>
//-----------------------------------------------------------------------

using Akka.Actor;
using Akka.TestKit.TestActors;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Akka.TestKit.MsTest.Tests
{
    [TestClass]
    public class TestKitTestFixtureTest : TestKit
    {
        [TestMethod]
        public void Can_create_more_than_one_test_in_a_fixture_with_the_same_actor_name_test1()
        {
            Sys.ActorOf<BlackHoleActor>("actor-name");
        }

        [TestMethod]
        public void Can_create_more_than_one_test_in_a_fixture_with_the_same_actor_name_test2()
        {
            Sys.ActorOf<BlackHoleActor>("actor-name");
        }
    }
}
