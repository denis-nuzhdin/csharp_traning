using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using WebAddressbookTests;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]);
            StreamWriter writer = new StreamWriter(args[1]);
            string format = args[2]; //в видео было значение 3
            string dataType = args[3];
            dynamic objectData = null;

            if (dataType == "groups")
            {

                objectData = new List<GroupData>();
                for (int i = 0; i < count; i++)
                {
                    objectData.Add(new GroupData(TestBase.GenerateRandomString(10))
                    {
                        Header = TestBase.GenerateRandomString(10),
                        Footer = TestBase.GenerateRandomString(10)

                    });

                }
            }
            else if (dataType == "contacts")
            {

                objectData = new List<ContactData>();
                for (int i = 0; i < count; i++)
                {
                    objectData.Add(new ContactData
                    {
                        FistName = TestBase.GenerateRandomString(10),
                        LastName = TestBase.GenerateRandomString(10)
                        //Address = TestBase.GenerateRandomString(10)

                    });

                }

            }
            else
            {
                System.Console.Out.Write("Неверный тип данных: " + dataType);
            }

         

            if (format == "csv")
            {
                writeGroupsToCsvFile(objectData, writer);
            }

            else if (format == "xml")
            {
                writeGroupsToXmlFile(objectData, writer);
            }

            else if (format == "json")
            {
                writeGroupsToJsonFile(objectData, writer);
            }

            else
            {
                System.Console.Out.Write("Неверный формат: " + format);

            }
            writer.Close();


        }

        static void writeGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.Name, group.Header, group.Footer));
                System.Console.Out.Write("name=" + group.Name, "header=" + group.Header,"footer=" + group.Footer);
            }
        }


        static void writeGroupsToXmlFile<Data>(List<Data> objectData, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<Data>)).Serialize(writer, objectData);
            
        }


        static void writeGroupsToJsonFile<Data>(List<Data> objectData, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(objectData, Newtonsoft.Json.Formatting.Indented));

        }

    }
}
