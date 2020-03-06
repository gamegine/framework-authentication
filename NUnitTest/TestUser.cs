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
            User fifi = new User(1, "noura");
            Assert.IsNotEmpty(fifi.login("noura"));
            Assert.AreEqual(fifi.login("nora"), null);
        }

        [Test]
        public void loginExpire()
        {
            UserExpireDays fifi = new UserExpireDays(1, "noura");
            Assert.IsNotEmpty(fifi.login("noura",1));
            Assert.AreEqual(fifi.login("nora"), null);
        }

        [Test]
        public void isLog()
        {
            UserExpireDays fifi = new UserExpireDays(1, "noura");
            token = fifi.login("noura", 1);
            UserExpireDays fofo = new UserExpireDays(2, "noura");
            string toke = fofo.login("noura", -1);
            Assert.IsNotEmpty(fifi.login("noura", 1));
            Assert.AreEqual(fifi.islog(token), true);
            Assert.AreEqual(fofo.islog(toke), false);
        }
        public void logout()
        {
            Assert.IsNotEmpty(token);
            User fifi = new User();
            fifi.logout(token);
            Assert.AreEqual(fifi.islog(token), false);
        }
    }
}