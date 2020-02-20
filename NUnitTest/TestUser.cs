using NUnit.Framework;
using framework_authentication.Models;

namespace NUnitTest
{
    public class TestUser
    {
        string token;
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void login()
        {
            User fifi = new User();
            token = fifi.login();
            Assert.IsNotEmpty(token);
        }
        [Test]
        public void isLog()
        {
            Assert.IsNotEmpty(token);
            User fifi = new User();
            fifi.islog(token);
            Assert.AreEqual(fifi.islog(token), true);
        }
    }
}