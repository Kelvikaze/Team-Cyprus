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
        internal static List<student> students = new List<student>();

        internal static Dictionary<int, student> studentID = new Dictionary<int, student>();
        internal static Dictionary<string, student> studentFirstName = new Dictionary<string, student>();
        internal static Dictionary<string, student> studentLastName = new Dictionary<string, student>();
        internal static Dictionary<int, student> studentCourseID = new Dictionary<int, student>();
        internal static Dictionary<int, student> studentCourseNumber = new Dictionary<int, student>();
        internal static Dictionary<string, student> studentCourseName = new Dictionary<string, student>();
        internal static Dictionary<int, student> studentCredit = new Dictionary<int, student>();
        internal static Dictionary<string, student> studentSemester = new Dictionary<string, student>();
        internal static Dictionary<int, student> studentYear = new Dictionary<int, student>();
        internal static Dictionary<string, student> studentCourseType = new Dictionary<string, student>();
        internal static Dictionary<string, student> studentCourseGrade = new Dictionary<string, student>();

        static void Main(string[] args)
        {
            LoadStudents();

            student NewStudent = new student();

            NewStudent.ID = Convert.ToInt32(Console.ReadLine());
            NewStudent.FirstName = Console.ReadLine();
            NewStudent.LastName = Console.ReadLine();
            NewStudent.CourseID = Convert.ToInt32(Console.ReadLine());
            NewStudent.CourseNumber = Convert.ToInt32(Console.ReadLine());
            NewStudent.CourseName = Console.ReadLine();
            NewStudent.Credit = Convert.ToInt32(Console.ReadLine());
            NewStudent.Semester = Console.ReadLine();
            NewStudent.Year = Convert.ToInt32(Console.ReadLine());
            NewStudent.CourseType = Console.ReadLine();
            NewStudent.CourseGrade = Console.ReadLine();

            students.Add(NewStudent);

            SaveStudents();

            LoadStudents();

            Console.ReadLine();
        }

        static void ClearCurrentEntries()
        {
            students.Clear();

            studentID.Clear();
            studentFirstName.Clear();
            studentLastName.Clear();
            studentCourseID.Clear();
            studentCourseNumber.Clear();
            studentCourseName.Clear();
            studentCredit.Clear();
            studentSemester.Clear();
            studentYear.Clear();
            studentCourseType.Clear();
            studentCourseGrade.Clear();
        }

        static void LoadStudents()
        {
            ClearCurrentEntries();

            try
            {
                using (Stream stream = File.Open("data.bin", FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();

                    var students2 = (List<student>)bin.Deserialize(stream);
                    foreach (student boi in students2)
                    {
                        Console.Clear();
                        Console.WriteLine(boi.ID);
                        Console.WriteLine(boi.FirstName);
                        Console.WriteLine(boi.LastName);
                        Console.WriteLine(boi.CourseID);
                        Console.WriteLine(boi.CourseNumber);
                        Console.WriteLine(boi.CourseName);
                        Console.WriteLine(boi.Credit);
                        Console.WriteLine(boi.Semester);
                        Console.WriteLine(boi.Year);
                        Console.WriteLine(boi.CourseType);
                        Console.WriteLine(boi.CourseGrade);
                    }
                }
            }
            catch (IOException)
            {
                Console.WriteLine("Error loading students");
            }
        }

        static void SaveStudents()
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
                Console.WriteLine("Error writing file");
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
