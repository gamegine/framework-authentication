using framework_authentication.Models;
using NUnit.Framework;

namespace NUnitTest
{
    public class TestUser
    {
        Token token = new Token();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Login()
        {
            Users fifi = new Users();
            fifi.Login();
            Assert.AreEqual(fifi.tokens.Count, 1);
        }
        [Test]
        public void IsLog()
        {
            Users fifi = new Users();
            fifi.tokens.Add(token);
            Assert.AreEqual(fifi.Islog(token.token), true);

            Users fofo = new Users();
            Assert.AreEqual(fofo.Islog(token.token), false);
        }
        [Test]
        public void Logout()
        {
            Users fifi = new Users();
            fifi.tokens.Add(token);
            Assert.AreEqual(fifi.Logout(token.token), true);
            Assert.AreEqual(fifi.tokens.Count, 0);

            Users fofo = new Users();
            Assert.AreEqual(fofo.Logout(token.token), false);
        }
    }
}
