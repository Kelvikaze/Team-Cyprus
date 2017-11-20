using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;

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
        const int MaxLength = 30;// Creates a max form for the first and last name

        /// <summary>
        /// Main methond to run the program
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            LoadStudents();

            newStudent();

            SearchFirstName(Console.ReadLine());

            //SaveStudents();

            //LoadStudents();

            Console.ReadLine();
        }

        /// <summary>
        /// searches the reconds by the first name of the student
        /// </summary>
        /// <param name="input">the input the the user wants to search by</param>
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

        /// <summary>
        /// searches the reconds by the last name of the student
        /// </summary>
        /// <param name="input">the input the the user wants to search by</param>
        static void SearchStudentsLastName(string input)//Searchs Students by last name
        {
            List<student> output = new List<student>();

            foreach (var item in studentLastName.Keys)
            {
                if (item.ToLower().Contains(input))
                {
                    output.Add(studentLastName[item]);
                }
            }

            if (output.Count > 0)
            {
                Console.WriteLine("Found student(s) with matching criteria");

                foreach (var item in output)
                {
                    Console.WriteLine(item.LastName + " " + item.FirstName);
                }

            }
        }

        /// <summary>
        /// Search students by courses taken by course name from the reconds entered
        /// </summary>
        /// <param name="input">the input the the user wants to search by</param>
        
        static void SearchCourseName(string input)
        {
            List<student> output = new List<student>();

            foreach (var item in studentCourseName.Keys)
            {
                if (item.ToLower().Contains(input))
                {
                    output.Add(studentCourseName[item]);
                }
            }

            if (output.Count > 0)
            {
                Console.WriteLine("Found Students Course(s) taken with matching criteria");

                foreach (var item in output)
                {
                    Console.WriteLine(item.CourseName + " " + item.CourseID + " " + item.LastName);
                }
            }
        }

        /// <summary>
        /// creates new student records 
        /// </summary>
        static void newStudent()
        {
            Console.WriteLine("Input the desired student ID: ");
            NewStudent.ID = Convert.ToInt32(Console.ReadLine());

            //Regex reg = new Regex(@"^\(\d[1-9]\) \d[1-9]-\d[1-9]( ext \d[1-9])[1-9])[1-9]$");//Reg for student id
            

            Console.Clear();
            Console.WriteLine("Input the desired student first name: ");
            NewStudent.FirstName = Console.ReadLine();
            if (NewStudent.FirstName.Length > MaxLength)//limits the number of letters in the first name
            {
                Console.Write("Invald First Name");
                Console.Clear();
            }
            Console.Clear();
            Console.WriteLine("Input the desired student last name: ");
            NewStudent.LastName = Console.ReadLine();
            if (NewStudent.LastName.Length > MaxLength)//Limits the number of letters in the last name
            {
                Console.Write("Invald Last Name");
                Console.Clear();
            }
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
            Console.WriteLine("Student Identification Number: " + NewStudent.ID);
            Console.WriteLine("First Name: "+ NewStudent.FirstName);
            Console.WriteLine("Last Name: "+ NewStudent.LastName);
            Console.WriteLine("Course Identification: " + NewStudent.CourseID);
            Console.WriteLine("Course Identification Number: "+ NewStudent.CourseNumber);
            Console.WriteLine("Course Name: "+ NewStudent.CourseName);
            Console.WriteLine("Credit Total: "+ NewStudent.Credit);
            Console.WriteLine("Semester: " + NewStudent.Semester);
            Console.WriteLine("Year: "+ NewStudent.Year);
            Console.WriteLine("Course Type: "+ NewStudent.CourseType);
            Console.WriteLine("Course Grade: "+ NewStudent.CourseGrade);

            Console.ReadKey();
            Console.Clear();
        }
        /// <summary>
        /// clears the entries from the arrays 
        /// </summary>
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

        /// <summary>
        /// Loads students infomation from the arrays that the users inputs
        /// </summary>
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

        /// <summary>
        /// Saves the student infomation to a document inside a data file
        /// </summary>
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
