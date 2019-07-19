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
        private string address;
        private string allEmails;
        private string detailedInformation;
        private string allFIO;
        private string nickname;
        private string allPhonesView;
        private string title;
        private string company;
        private string homepage;
        private string homePageView;
        private string stringRN = "\r\n";
        private string allMailsView;
        private string bYear;
        private int fullBYears;

        public ContactData(string first_name ,string last_name)
        {
            FistName = first_name;
            LastName = last_name;

        }

        public ContactData()
        {

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

            return "lastname = "+LastName+"\nfirstname = " + FistName+ "\nmiddlename = " + MiddleName;

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
            if (LastName.CompareTo(other.LastName) == 0)
            {
                return FistName.CompareTo(other.FistName);
            }
            else
            {
                return LastName.CompareTo(other.LastName);
            }

        }


        public string FistName { get; set;}

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Address
        {
            get
            {
                if (address != null)
                {
                    return address;
                }
                else
                {
                    return fromatRNforString(address) + stringRN;
                }
            }

            set

            {
                address = value;
            }
                
        }

        //public string Nickname { get; set; }
        public string Nickname
        {
            get
            {
                if (nickname != null || nickname=="")
                {
                    return nickname + stringRN;
                }
                else
                {
                    return nickname + stringRN;
                }
            }
 

            set
            {
                nickname = value;
            }
        }



        public string Photo { get; set; }

        public string Title
        {
            get
            {
                if (title != null || title == "")
                {
                    return fromatRNforString(title);
                }
                else return fromatRNforString(title);

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
                if (company != null || company == "")
                {
                    return fromatRNforString(company);
                }
                else return fromatRNforString(company);

            }

            set
            {
                company = value;
            }
        }

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
                    return (CheckEmails(Email1) + CheckEmails(Email2) +CheckEmails(Email3)).Trim();
                }

            }
            set
            {
                allEmails = value;
            }
        }


        private string CheckEmails(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            return email + "\r\n";
        }

        public string Homepage
        {
            get
            {
                if (homepage != null || homepage == "")
                {
                    return homepage;
                }
                else
                {
                    return homepage;
                }
            }

            set
            {
                homepage = value;
            }
        }

        public string Birthday { get; set; }
        public string Bday { get; set; }
        public string Bmonth { get; set; }
        public string Byear
        { get
            {
                if (bYear != null)
                {
                    return bYear;
                }
                else
                {
                    return bYear;
                }
            }

            set 
            {
                bYear = value;
            }
        }

        public string Anniversary { get; set; }

        //public string FullBYear
        //{
        //    get
        //    {
        //        int currentYear;
        //        currentYear = Convert.ToInt32(DateTime.Now.Year);
              
        //        if (Byear == null)
        //        {
        //            return "";
        //        }
        //        else
        //        {
        //           //return currentYear;
        //            fullBYears = currentYear - Convert.ToInt32(bYear);
        //            return fullBYears;
        //        }

        //    }

        //    set
        //    {
        //        fullBYears = value;
        //    }

        //}

        public string Aday { get; set; }
        public string Amonth { get; set; }
        public string Ayear { get; set; }

        public string Group { get; set; }

        public string SecondaryAddress { get; set; }

        public string SecondaryHome { get; set; }

        public string SecondaryNotes { get; set; }


        public string DetailedInformation
        {
            get
            {
                if (detailedInformation != null)
                {
                    return detailedInformation;
                }
                else
                {
                    return (GetFIOFromView + Nickname + Title + Company + Address + GetPhonesFromView + 
                        GetMailsFromView + GetHomepageFromView + fromatRNforString(Birthday) + fromatRNforString(Anniversary) +stringRN 
                        + fromatRNforString(SecondaryAddress)+ stringRN + SecondaryNotes).Trim();

                }
            }

            set
            {
                detailedInformation = value;
            }
        }


        public string GetFIOFromView
        {
            get
            {
                if (allFIO != null)
                {
                    return allFIO;
                }
                else
                {
                    return FistName + " " + MiddleName + " " + LastName + stringRN;
                }
            }

            set
            {
                allFIO = value;
            }
        }




        string GetPhonesFromView
        {
            get
            {
                if (allPhonesView == null || allPhones =="")
                {
                    return "";
                }
                else
                {
                    return fromatRNforString("H: " + PhoneHome + stringRN + "M: " + 
                        PhoneMobile + stringRN + "W: " + PhoneWork + stringRN + "F: "+PhoneFax) + stringRN;
                }

            }

            set
            {
                allPhonesView = value;
            }

        }


        string GetMailsFromView
        {
            get
            {
                if (allMailsView == null || allMailsView =="")
                {
                    return "";
                }
                else
                {
                    return fromatRNforString(Email1 + stringRN + Email2 + stringRN + Email3);
                }

            }

            set
            {
                allPhonesView = value;
            }

        }



        string GetHomepageFromView
        {
            get
            {
                if (homePageView == null || homePageView == "")
                {
                    return "";
                }
                else
                {
                    return fromatRNforString("Homepage:"+ stringRN + Homepage) + stringRN;
                }

            }

            set
            {
                allPhonesView = value;
            }

        }


        string fromatRNforString(string thisString)
        {
            if (thisString == null || thisString == "")
            {
                return "";
            }
            return thisString + "\r\n";
        }


    }

}

