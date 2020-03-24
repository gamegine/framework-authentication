using framework_authentication.Models;
using NUnit.Framework;

namespace NUnitTest.Models
{
    class TestToken
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor()
        {
            Token t = new Token();
            Assert.IsNotNull(t,"new token => null");
            Assert.IsNotNull(t.token, "token string is null");
            Assert.AreNotEqual(t.token,new Token().token, "token string is not random");
        }
        [Test]
        public void IsValid()
        {
            Token t = new Token();
            Assert.AreEqual(t.IsValid(), true);
        }
    }
}
