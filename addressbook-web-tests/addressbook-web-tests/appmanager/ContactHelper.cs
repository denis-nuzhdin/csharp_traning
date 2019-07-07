using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
            {

            }

    
        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.InitContactCreation();
            FillContact(contact);
            SubmitContact();
            manager.Navigator.OpenHomePage();
            return this;
        }


        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.OpenHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.XPath("//tr[@name='entry']"));

                string lastName;
                string firstName;

                foreach (IWebElement element in elements)
                {

                    List<IWebElement> cells = new List<IWebElement>(element.FindElements(By.TagName("td")));

                    lastName = cells[1].Text;
                    firstName = cells[2].Text;

                    contactCache.Add(new ContactData(firstName, lastName));
                }
                        
            }

            return new List<ContactData>(contactCache);
            
        }


        public ContactHelper Modify(int v, ContactData oldData, ContactData newData)
        {
            //manager.Navigator.OpenHomePage();
            InitContactModification(v);
            FillContact(newData);
            SubmitContactModification();
            manager.Navigator.OpenHomePage();

            return this;
        }

        public ContactHelper Remove(int v, ContactData oldData)
        {
            //manager.Navigator.OpenHomePage();
            SelectContact(v);
            DeleteContactFromList();
            driver.SwitchTo().Alert().Accept();
            manager.Navigator.OpenHomePage();
            return this;
        }

        public ContactHelper DeleteContactFromList()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper DeleteContactFromForm()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.XPath("//input[@value='Update']")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper InitContactModification(int index)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + (index + 1) + "]")).Click();
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            //driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr["+index+"]/td/input")).Click();
            driver.FindElement(By.XPath("//tr[@name='entry'][" + (index+1) + "]//input[@name='selected[]']")).Click();
            return this;
        }

        public ContactHelper SubmitContact()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper FillContact(ContactData contact)
        {
            Type(By.Name("firstname"), contact.FistName);
            Type(By.Name("lastname"), contact.LastName);
            return this;
        }

        public bool IsCheckedContact()
        {
            manager.Navigator.OpenHomePage();
            return IsElementPresent(By.XPath("//table[@id='maintable']/tbody//td/input"));
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.OpenHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allPhones = cells[5].Text;
            string allEmails = cells[4].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails

            };
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.OpenHomePage();
            InitContactModification(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Address = address,
                PhoneHome = homePhone,
                PhoneMobile = mobilePhone,
                PhoneWork = workPhone,
                Email1 = email,
                Email2 = email2,
                Email3 = email3
                
            };
        }



    }
}
