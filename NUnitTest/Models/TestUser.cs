using framework_authentication.Models;
using NUnit.Framework;
using System.Collections.Generic;

namespace NUnitTest.Models
{
    public class TestUser
    {
        Token token = new Token();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void LoginToken()
        {
            Users fifi = new Users();
            fifi.tokens = new List<Token>();
            Token gen = fifi.Login<Token>();
            Assert.AreEqual(fifi.tokens.Count, 1);
            Assert.AreEqual(fifi.tokens.Contains(gen),true);
            Assert.AreEqual(gen is Token, true);
            Assert.AreEqual(gen is TokenExpireHours, false);
        }
        [Test]
        public void LoginTokenExpire()
        {
            Users fifi = new Users();
            fifi.tokens = new List<Token>();
            Token gen = fifi.Login<TokenExpireHours>();
            Assert.AreEqual(fifi.tokens.Count, 1);
            Assert.AreEqual(fifi.tokens.Contains(gen), true);
            Assert.AreEqual(gen is Token, true);
            Assert.AreEqual(gen is TokenExpireHours, true);
        }
        [Test]
        public void IsLog()
        {
            Users fifi = new Users();
            fifi.tokens = new List<Token>() { token };
            Assert.AreEqual(fifi.Islog(token.token), true);

            Users fofo = new Users();
            fofo.tokens = new List<Token>();
            Assert.AreEqual(fofo.Islog(token.token), false);
        }
        [Test]
        public void Logout()
        {
            Users fifi = new Users();
            fifi.tokens = new List<Token>() { token };
            Assert.AreEqual(fifi.Logout(token.token), true);
            Assert.AreEqual(fifi.tokens.Count, 0);

            Users fofo = new Users();
            fofo.tokens = new List<Token>();
            Assert.AreEqual(fofo.Logout(token.token), false);
        }
    }
}
