using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace Database
{
    class Program
    {
        internal static List<student> students;

        static void Main(string[] args)
        {

        }

        static void LoadStudents()
        {
            try
            {
                using (Stream stream = File.Open("data.bin", FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, students);
                }
            }
            catch (IOException)
            {
                Console.WriteLine("Error loading file");
            }
        }

        [Serializable]
        public class student
        {
            public int ID = 0;          
            public string FirstName = null;
            public string LastName = null;
            public int CourseID = 0;
            public int CourseNumber = 0;
            public string CourseName = null;
            public int Credit = 0;
            public string Semester = null;
            public int Year = 0;
            public string CourseType = null;
            public string CourseGrade = null;
        }
    }
}
