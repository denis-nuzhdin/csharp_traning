﻿using System;
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

        public ContactHelper Modify(int v, ContactData newData)
        {
            manager.Navigator.OpenHomePage();
            //SelectContact(v);
            InitContactModification(v);
            FillContact(newData);
            SubmitContactModification();
            manager.Navigator.OpenHomePage();

            return this;
        }

        public ContactHelper Remove(int v)
        {
            manager.Navigator.OpenHomePage();
            SelectContact(v);
            DeleteContactFromList();
            driver.SwitchTo().Alert().Accept();
            //DeleteContact();
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
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr["+index+"]/td/input")).Click();
            return this;
        }

        public ContactHelper SubmitContact()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            return this;
        }

        public ContactHelper FillContact(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.FistName);
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.LastName);
            return this;
        }


    }
}
