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
    public class GroupHelper : HelperBase
    {

        public GroupHelper(ApplicationManager manager): base (manager)
        {
        }


        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.OpenGroupPage();
            InitGropCreation();
            FillGroup(group);
            SubmitGroup();
            manager.Navigator.OpenGroupPage();
            return this;
        }


        public GroupHelper Remove()
        {
            manager.Navigator.OpenGroupPage();
            SelectGroup();
            RemoveGroup();
            manager.Navigator.OpenGroupPage();
            return this;
        }

        public GroupHelper InitGropCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }

        public GroupHelper SelectGroup()
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[3]")).Click();
            return this;
        }

        public GroupHelper FillGroup(GroupData group)
        {
            driver.FindElement(By.Name("group_name")).Click();
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            driver.FindElement(By.Name("group_header")).Click();
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            driver.FindElement(By.Name("group_footer")).Click();
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
            return this;
        }

        public GroupHelper SubmitGroup()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }
    }
}
