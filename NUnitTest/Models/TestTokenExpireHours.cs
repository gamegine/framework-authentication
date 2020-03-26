using NUnit.Framework;
using framework_authentication.Models;
using System;

namespace NUnitTest.Models
{
    class TestTokenExpireHours
    {
        [Test]
        public void Constructor()
        {
            DateTime d = DateTime.Now;
            TokenExpireHours t = new TokenExpireHours();
            Assert.IsNotNull(t, "new token => null");
            Assert.IsNotNull(t.token, "token string is null");
            Assert.AreNotEqual(t.token, new TokenExpireHours().token, "token string is not random");
            Assert.AreNotEqual(t.date, d, "token create date");
        }

        [Test]
        public void IsValid()
        {
            TokenExpireHours t = new TokenExpireHours();
            Assert.AreEqual(t.IsValid(), true,"token now is not valid");
            DateTime d = DateTime.Now.AddHours(-2);
            t.date = d;
            Assert.AreEqual(t.date, d,"cant set tokent date");
            Assert.AreEqual(t.IsValid(), false,"expired token is valid");
        }
    }
}
