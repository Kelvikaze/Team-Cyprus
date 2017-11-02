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
        internal static student NewStudent = new student();

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

            //newStudent();

            SearchFirstName(Console.ReadLine());

            //SaveStudents();

            //LoadStudents();

            Console.ReadLine();
        }

        static void SearchFirstName(string input)
        {
            List<student> output = new List<student>();

            foreach (var item in studentFirstName.Keys)
            {
                if (item.ToLower().Contains(input))
                {
                    output.Add(studentFirstName[item]);
                }
            }

            if (output.Count > 0)
            {
                Console.WriteLine("Found student(s) with matching criteria");

                foreach (var item in output)
                {
                    Console.WriteLine(item.FirstName + " " + item.LastName);
                }
            }
        }

        static void newStudent()
        {
            Console.WriteLine("Input the desired student ID");
            NewStudent.ID = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Input the desired student first name");
            NewStudent.FirstName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Input the desired student last name");
            NewStudent.LastName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Input the desired course ID");
            NewStudent.CourseID = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Input the desired course number");
            NewStudent.CourseNumber = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Input the desired course name");
            NewStudent.CourseName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Input the desired credits");
            NewStudent.Credit = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Input the desired semester");
            NewStudent.Semester = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Input the desired year");
            NewStudent.Year = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Input the desired course type");
            NewStudent.CourseType = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Input the desired course grade");
            NewStudent.CourseGrade = Console.ReadLine();

            students.Add(NewStudent);
            Console.Clear();
            Console.WriteLine("Added New Student:");
            Console.WriteLine(NewStudent.ID);
            Console.WriteLine(NewStudent.FirstName);
            Console.WriteLine(NewStudent.LastName);
            Console.WriteLine(NewStudent.CourseID);
            Console.WriteLine(NewStudent.CourseNumber);
            Console.WriteLine(NewStudent.CourseName);
            Console.WriteLine(NewStudent.Credit);
            Console.WriteLine(NewStudent.Semester);
            Console.WriteLine(NewStudent.Year);
            Console.WriteLine(NewStudent.CourseType);
            Console.WriteLine(NewStudent.CourseGrade);

            Console.ReadKey();
            Console.Clear();
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
            Console.Clear();
            try
            {
                using (Stream stream = File.Open("data.bin", FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();

                    var students2 = (List<student>)bin.Deserialize(stream);
                    foreach (student boi in students2)
                    {                        
                        Console.WriteLine(boi.ID);
                        studentID.Add(boi.ID, boi);
                        Console.WriteLine(boi.FirstName);
                        studentFirstName.Add(boi.FirstName, boi);
                        Console.WriteLine(boi.LastName);
                        studentLastName.Add(boi.LastName, boi);
                        Console.WriteLine(boi.CourseID);
                        studentCourseID.Add(boi.CourseID, boi);
                        Console.WriteLine(boi.CourseNumber);
                        studentCourseNumber.Add(boi.CourseNumber, boi);
                        Console.WriteLine(boi.CourseName);
                        studentCourseName.Add(boi.CourseName, boi);
                        Console.WriteLine(boi.Credit);
                        studentCredit.Add(boi.Credit, boi);
                        Console.WriteLine(boi.Semester);
                        studentSemester.Add(boi.Semester, boi);
                        Console.WriteLine(boi.Year);
                        studentYear.Add(boi.Year, boi);
                        Console.WriteLine(boi.CourseType);
                        studentCourseType.Add(boi.CourseType, boi);
                        Console.WriteLine(boi.CourseGrade);
                        studentCourseGrade.Add(boi.CourseGrade, boi);
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
        internal class student
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
