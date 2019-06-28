using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData oldData = new GroupData("имя группы для переименования");
            oldData.Header = "хедер переименования";
            oldData.Footer = "футер переименования";

            GroupData newData = new GroupData("имя группы");
            newData.Header = "хедер";
            newData.Footer = "футер";


            if (app.Group.IsCheckedElement() == false)
            {
                app.Group.Create(oldData);
            }

            app.Group.Modify(1,oldData, newData);

        }
    }
}
