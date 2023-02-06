using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LPHN2CollectionLinq
{
    public class Program
    {
        public static string path = @"D:\ФАИС\ИП-21\ЯПВУ\labsLPHN\LPHN2CollectionLinq\LPHN2CollectionLinq\fileTeachers.txt";
        public static void ReadFromFile(out Collection<Teacher> collection)
        {
            try
            {

                StreamReader sr = new StreamReader(path, System.Text.Encoding.Default);
                string line;
                string[] data;
                collection = new Collection<Teacher>();
                int key = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    data = line.Split(';');
                    collection.AddElement(data[0], new Teacher(data[0], data[1], Convert.ToInt32(data[2]), Convert.ToInt32(data[3]),
                        Convert.ToInt32(data[4]), Convert.ToInt32(data[5]), Convert.ToInt32(data[6]), Convert.ToInt32(data[7]),
                        Convert.ToInt32(data[8]), Convert.ToInt32(data[9]), Convert.ToInt32(data[10]), Convert.ToInt32(data[11])));
                }
            }
            catch (Exception sample)
            {
                throw new Exception(sample.Message);
            }
        }
        static void Main(string[] args)
        {
            Collection<Teacher> collection;
            ReadFromFile(out collection);
            foreach (Teacher item in collection)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("List of teacher in the IT faculty");

            List<Teacher> listTeachersIT = new List<Teacher>();
            listTeachersIT = collection.Where<Teacher>(teacher => teacher.Faculty == "IT");
            foreach (Teacher teacher in listTeachersIT)
                Console.WriteLine(teacher.Name);

            double averageChargedHoursUniversity = (from teacher in collection.GetList.Values
                                     select teacher.averageChargedHours).Average();

            var firstTeacherQuery = from teacher in collection
                                    where teacher.averageChargedHours > averageChargedHoursUniversity
                                    select teacher;
            Console.WriteLine("List of teachers with average charged hours more than University average");
            foreach (Teacher teacher in firstTeacherQuery)
                Console.WriteLine(teacher.Name);
            var secondTeacherQuery = from teacher in collection.GetList.Values
                                     group teacher by teacher.Faculty
                                     into faculties
                                     from teacher in faculties
                                     where teacher.chargedHours.Sum() == (from teacher in faculties
                                                                          select teacher.chargedHours.Sum()).Max()
                                     select teacher;
            Console.WriteLine("List of teachers with maximum charged hours in each faculty");
            foreach (Teacher teacher in secondTeacherQuery)
                Console.WriteLine("In the faculty of "+teacher.Faculty+ "\n "+ teacher.Name + " with " + teacher.chargedHours.Sum());
        }
    }
}