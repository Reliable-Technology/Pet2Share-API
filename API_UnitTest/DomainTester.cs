using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using NUnit.Common;

using Pet2Share_API.Domain;

namespace API_UnitTest
{
    [TestFixture]
    public class DomainTester
    {
        [TestCase]
        public void UserTest()
        {
            User u = new User(1000);
            Assert.IsNull(u);
        }
    }
}
