using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {

            ContactData oldData = new ContactData("Петр для удаления", "Петров для удаления");
            //oldData.LastName = "Петров для удаления";

            if (app.Contact.IsCheckedContact() == false)
            {
                app.Contact.Create(oldData);
            }

            List<ContactData> oldContacts = app.Contact.GetContactList();

            app.Contact.Remove(0, oldData);

            List<ContactData> newContacts = app.Contact.GetContactList();

            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
