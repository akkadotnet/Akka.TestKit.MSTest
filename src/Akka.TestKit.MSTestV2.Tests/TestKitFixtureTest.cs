using Akka.Actor;
using Akka.TestKit.TestActors;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Akka.TestKit.MSTestV2.Tests
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
