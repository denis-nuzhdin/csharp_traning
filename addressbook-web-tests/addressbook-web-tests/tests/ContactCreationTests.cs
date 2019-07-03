using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("Иван", "Иванов");
            //contact.LastName = "Иванов";

            List<ContactData> oldContacts = app.Contact.GetContactList();
            

            app.Contact.Create(contact);
            //List<ContactData> oldContacts = app.Contact.GetContactList();
            //Debug.WriteLine(oldContacts);

            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts,newContacts);


        }
    }
}
