﻿using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;
using Newtonsoft.Json;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {

        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData()
                {
                    FistName = GenerateRandomString(10),
                    LastName = GenerateRandomString(20),
                    Address = GenerateRandomString(30)
                });


            }


            return contacts;

        }


        public static IEnumerable<ContactData> GroupDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(File.ReadAllText(@"contacts.json"));

        }


        [Test, TestCaseSource("GroupDataFromJsonFile")]
        public void ContactCreationTest(ContactData contact)
        {

            List<ContactData> oldContacts = app.Contact.GetContactList();


            app.Contact.Create(contact);

            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts,newContacts);


        }
    }
}
