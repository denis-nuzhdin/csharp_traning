using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData
    {

        private string first_name="";
        private string middle_name = "";
        private string last_name = "";
        private string nickname = "";
        private string photo = "";
        private string title = "";
        private string company = "";
        private string address = "";
        private string phone_home = "";
        private string phone_mobile = "";
        private string phone_work = "";
        private string phone_fax = "";
        private string email1 = "";
        private string email2 = "";
        private string email3 = "";
        private string homepage = "";
        private string birthday = "";
        private string anniversary = "";
        private string group = "";
        private string secondary_address = "";
        private string secondary_home = "";
        private string secondary_notes = "";


        public ContactData(string first_name)
        {
            this.first_name = first_name;
        }

        public string FistName
        {
            get
            {
                return first_name;
            }

            set
            {
                first_name = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return middle_name;
            }

            set
            {
                middle_name = value;
            }
        }

        public string LastName
        {
            get
            {
                return last_name;
            }

            set
            {
                last_name = value;
            }
        }

        public string Nickname
        {
            get
            {
                return nickname;
            }

            set
            {
                nickname = value;
            }
        }

        public string Photo
        {
            get
            {
                return photo;
            }

            set
            {
                photo = value;
            }
        }

        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }

        public string Company
        {
            get
            {
                return company;
            }

            set
            {
                company = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }

        public string PhoneHome
        {
            get
            {
                return phone_home;
            }

            set
            {
                phone_home = value;
            }
        }

        public string PhoneMobile
        {
            get
            {
                return phone_mobile;
            }

            set
            {
                phone_mobile = value;
            }
        }

        public string PhoneWork
        {
            get
            {
                return phone_work;
            }

            set
            {
                phone_work = value;
            }
        }

        public string PhoneFax
        {
            get
            {
                return phone_fax;
            }

            set
            {
                phone_fax = value;
            }
        }

        public string Email1
        {
            get
            {
                return email1;
            }

            set
            {
                email1 = value;
            }
        }

        public string Email2
        {
            get
            {
                return email2;
            }

            set
            {
                email2 = value;
            }
        }

        public string Email3
        {
            get
            {
                return email3;
            }

            set
            {
                email3 = value;
            }
        }

        public string Homepage
        {
            get
            {
                return homepage;
            }

            set
            {
                homepage = value;
            }
        }

        public string Birthday
        {
            get
            {
                return birthday;
            }

            set
            {
                birthday = value;
            }
        }

        public string Anniversary
        {
            get
            {
                return anniversary;
            }

            set
            {
                anniversary = value;
            }
        }

        public string Group
        {
            get
            {
                return group;
            }

            set
            {
                group = value;
            }
        }

        public string SecondaryAddress
        {
            get
            {
                return secondary_address;
            }

            set
            {
                secondary_address = value;
            }
        }

        public string SecondaryHome
        {
            get
            {
                return secondary_home;
            }

            set
            {
                secondary_home = value;
            }
        }

        public string SecondaryNotes
        {
            get
            {
                return secondary_notes;
            }

            set
            {
                secondary_notes = value;
            }
        }
    }
 
}
