using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            GroupData oldData = new GroupData("имя группы для удаления");
            oldData.Header = "хедер удаления";
            oldData.Footer = "футер удаления";


            if (app.Group.IsCheckedElement() == false)
            {
                app.Group.Create(oldData);
            }

            app.Group.Remove(1, oldData);
            
        }
    }
}
