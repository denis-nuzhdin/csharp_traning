using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("имя группы");
            newData.Header = "хедер";
            newData.Footer = "футер";
 
            app.Group.Modify(4, newData);

        }
    }
}
