using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

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
            return this;
        }

        public ContactHelper DeleteContactFromForm()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.XPath("//input[@value='Update']")).Click();
            return this;
        }

        public ContactHelper InitContactModification(int index)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + index + "]")).Click();
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            //driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr["+index+"]/td/input")).Click();
            driver.FindElement(By.XPath("//tr[@name='entry'][" + index + "]//input[@name='selected[]']")).Click();
            return this;
        }

        public ContactHelper SubmitContact()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
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



    }
}
