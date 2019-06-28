using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {

            ContactData oldData = new ContactData("Петр для удаления");
            oldData.LastName = "Петров для удаления";

            if (app.Contact.IsCheckedContact() == false)
            {
                app.Contact.Create(oldData);
            }
            app.Contact.Remove(1, oldData);

        }
    }
}
