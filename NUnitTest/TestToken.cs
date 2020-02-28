using NUnit.Framework;
using framework_authentication.Models;
using System;

namespace NUnitTest
{
    class TestToken
    {


        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void isValid()
        {
            Token toto = new Token(DateTime.Now.AddDays(1));
            Assert.AreEqual(toto.isValid(), true);
            Token toto2 = new Token(DateTime.Now.AddDays(-1));
            Assert.AreEqual(toto2.isValid(), false);
        }

        [Test]
        public void delete()
        {
            Token toto = new Token(DateTime.Now.AddDays(1));
            toto.delete();
            Assert.AreEqual(toto.isValid(), false);
        }

        [Test]
        public void getToken()
        {
            Token toto = new Token();
            Assert.IsNotNull(toto.getToken());
        }
    }
}
