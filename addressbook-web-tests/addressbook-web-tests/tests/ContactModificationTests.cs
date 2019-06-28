using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("Петр");
            newData.LastName = "Петров";

            ContactData oldData = new ContactData("Петр для редактирования");
            oldData.LastName = "Петров для редактирования";


            if (app.Contact.IsCheckedContact() == false)
            {
                app.Contact.Create(oldData);
            }
            app.Contact.Modify(1,oldData, newData);

        }
    }
}
