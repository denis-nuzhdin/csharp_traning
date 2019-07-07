using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;

        public ContactData(string first_name ,string last_name)
        {
            FistName = first_name;
            LastName = last_name;

        }


          // ////////////////////////////


        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return LastName == other.LastName && FistName == other.FistName;

            //return FIO == other.FIO;
            //return LastName == other.LastName;
        }

        public override int GetHashCode()
        {
            return LastName.GetHashCode() + FistName.GetHashCode();
            //return FIO.GetHashCode();
            //return LastName.GetHashCode();
        }

        public override string ToString()
        {
            return LastName + FistName;
            //return FIO;
            //return "fio=" + LastName + FistName;
            //return "last_name=" + LastName;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            //if (Object.ReferenceEquals(this, other))
            //{
            //    return 1;
            //}
            //return LastName.CompareTo(other.LastName);
            
            return LastName.CompareTo(other.LastName) + FistName.CompareTo(other.FistName);
            //return FIO.CompareTo(other.FIO);
            //return LastName.CompareTo(other.LastName);
        }

        /// //////////////////////////////////

 
        public string FistName { get; set;}

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string Nickname { get; set; }

        public string Photo { get; set; }

        public string Title { get; set; }

        public string Company { get; set; }

        public string PhoneHome { get; set; }

        public string PhoneMobile { get; set; }

        public string PhoneWork { get; set; }

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(PhoneHome) + CleanUp(PhoneMobile) + CleanUp(PhoneWork)).Trim();
                }

            }
            set
            {
                allPhones = value;
            }
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone=="")
            {
                return "";
            }
            return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
        }

        public string PhoneFax { get; set; }

        public string Email1 { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (Email1+"\r\n" + Email2+"\r\n" + Email3).Trim();
                }

            }
            set
            {
                allEmails = value;
            }
        }

        public string Homepage { get; set; }

        public string Birthday { get; set; }

        public string Anniversary { get; set; }

        public string Group { get; set; }

        public string SecondaryAddress { get; set; }

        public string SecondaryHome { get; set; }

        public string SecondaryNotes { get; set; }
    
    }
 
}
