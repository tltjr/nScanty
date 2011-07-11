using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;

namespace nScanty
{
    [TestFixture]
    public class HashedPasswordGenerator
    {
        [Test]
        public void HashPassword()
        {
            var desiredPassword = "changeme";
            string hashed = BCrypt.HashPassword(desiredPassword, BCrypt.GenerateSalt());
            // break here and copy the hashed value into the web config where key="password"
        }
    }
}