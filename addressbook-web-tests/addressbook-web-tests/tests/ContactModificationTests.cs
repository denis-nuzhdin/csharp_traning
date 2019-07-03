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
            ContactData newData = new ContactData("Петр", "Петров");
            //newData.LastName = "Петров";

            ContactData oldData = new ContactData("Петр для редактирования", "Петров для редактирования");
            //oldData.LastName = "Петров для редактирования";


            if (app.Contact.IsCheckedContact() == false)
            {
                app.Contact.Create(oldData);
            }

            List<ContactData> oldContacts = app.Contact.GetContactList();

            app.Contact.Modify(0,oldData, newData);

            List<ContactData> newContacts = app.Contact.GetContactList();
            //oldContacts.Add(contact);
            oldContacts[0].LastName = newData.LastName;
            oldContacts[0].FistName = newData.FistName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
