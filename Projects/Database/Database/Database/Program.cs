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
        internal static bool searching;
        internal static List<student> students = new List<student>();
        internal static List<classes> studentClasses = new List<classes>();
        internal static Dictionary<int, student> studentID = new Dictionary<int, student>();
        internal static Dictionary<string, student> studentFirstName = new Dictionary<string, student>();
        internal static Dictionary<string, student> studentLastName = new Dictionary<string, student>();
        internal static Dictionary<string, student> classNumbers = new Dictionary<string, student>();
        const int MaxLength = 20;// Creates a max form for the first and last name

        /// <summary>
        /// Main methond to run the program
        /// </summary>
        static void Main(string[] args)
        {
            Console.Title = "Student Database";

            Intro();

            LoadStudents();

            MainMenu();

            Console.WriteLine("End script");

            Console.ReadLine();
        }

        /// <summary>
        /// Main menu method which handles where the user goes after the intro sequence
        /// </summary>
        static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine(".-.   .-.  .--.  .-..-. .-.   .-.   .-..----..-. .-..-. .-.");
            Console.WriteLine("|  `.'  | / {} \\ | ||  `| |   |  `.'  || {_  |  `| || { } |");
            Console.WriteLine("| |\\ /| |/  /\\  \\| || |\\  |   | |\\ /| || {__ | |\\  || {_} |");
            Console.WriteLine("`-' ` `-'`-'  `-'`-'`-' `-'   `-' ` `-'`----'`-' `-'`-----'");
            Console.WriteLine("");

            if (PromptBool("Would you like to search the student database?"))
            {
                SearchDatabase();
            }
            else
            {
                Console.Clear();
                Console.WriteLine(".-.   .-.  .--.  .-..-. .-.   .-.   .-..----..-. .-..-. .-.");
                Console.WriteLine("|  `.'  | / {} \\ | ||  `| |   |  `.'  || {_  |  `| || { } |");
                Console.WriteLine("| |\\ /| |/  /\\  \\| || |\\  |   | |\\ /| || {__ | |\\  || {_} |");
                Console.WriteLine("`-' ` `-'`-'  `-'`-'`-' `-'   `-' ` `-'`----'`-' `-'`-----'");
                Console.WriteLine("");
                if (!PromptBool("Would you like to add an entry instead?"))
                {
                    Environment.Exit(1);
                }
                else
                {
                    newStudent();
                }
            }
        }

        /// <summary>
        /// Determines which method of searching the user would like to use
        /// </summary>
        static void SearchDatabase()
        {
            Console.Clear();
            
            switch (GetInt("How would you like to search the database?\nSubmit the number corresponding to how you would like to search\n0 - Student ID\n1 - Student First Name\n2 - Student Last Name\n3 - Course Numbers\n4 - Return to Main Menu")) {
                case 0:
                    // Do Student ID search
                    break;
                case 1:
                    searching = true;
                    Search(1);
                    break;
                case 2:
                    searching = true;
                    Search(2);
                    break;
                case 3:
                    // Course ID
                    break;
                case 4:
                    MainMenu();
                    break;
                default:
                    Console.WriteLine("Unfortunately that is not a valid search method");
                    System.Threading.Thread.Sleep(2000);
                    Console.Clear();
                    SearchDatabase();
                    break;
            }
        }

        static void Search(int searchMode)
        {
            while (searching)
            {
                Console.Clear();
                switch (searchMode)
                {
                    case 0:
                        break;
                    case 1:
                        SearchFirstName(GetString("Enter search terms"));
                        break;
                    case 2:
                        SearchStudentsLastName(GetString("Enter search terms"));
                        break;
                    case 3:
                        break;
                }

                if (PromptBool("Continue searching?"))
                {
                    
                }
                else
                {
                    searching = false;
                }
            }

            if (!PromptBool("Would you like to change search method instead?"))
            {
                Environment.Exit(1);
            }
            else
                SearchDatabase();
        }

        static bool PromptBool(string question)
        {
            Console.WriteLine(question);
            Console.WriteLine("Submit 'y' to continue or 'n' to return");
            string input = Console.ReadLine().ToLower();
            if (input == "n")
            {
                return false;
            }
            else if (input != "y")
            {
                Console.WriteLine("You did not answer with an accepted answer so I'll take that as a yes");
                System.Threading.Thread.Sleep(2000);
                return true;
            }
            else
            return true;
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
                if (item.ToLower().Contains(input.ToLower()))
                {
                    output.Add(studentFirstName[item]);
                }
            }

            if (output.Count > 0)
            {
                Console.WriteLine("Found " + output.Count + " student(s) with matching criteria\n[First name, Last name, Student ID]");

                foreach (var item in output)
                {
                    Console.WriteLine(item.FirstName + " " + item.LastName + " | " + GetID(item.ID));
                }
            }
            else
            {
                Console.WriteLine("No students found with matching criteria");
            }
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
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
                Console.WriteLine(item);
                if (item.ToLower().Contains(input.ToLower()))
                {
                    output.Add(studentLastName[item]);
                }
            }

            if (output.Count > 0)
            {
                Console.WriteLine("Found " + output.Count + " student(s) with matching criteria");

                foreach (var item in output)
                {
                    Console.WriteLine(item.LastName + ", " + item.FirstName + " | " + GetID(item.ID));
                }
            }
            else
            {
                Console.WriteLine("No students found with matching criteria");
            }
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        static Int32 GetInt(string prompt)
        {
            bool metCriteria = false;
            while (!metCriteria)
            {
                Console.Clear();
                Console.WriteLine(prompt);
                int output;
                string input = Console.ReadLine();
                if (input.Length < MaxLength + 1 && int.TryParse(input, out output))
                {
                    return output;
                }
                else
                {
                    if (input.Length > MaxLength)
                        Console.WriteLine("Input was too large, please stay under " + MaxLength + " digits");
                    else
                        Console.WriteLine("Please input the correct data type");
                    System.Threading.Thread.Sleep(1500);
                }
            }
            return 0;
        }

        static string GetString(string prompt)
        {
            bool metCriteria = false;
            while (!metCriteria)
            {
                Console.Clear();
                Console.WriteLine(prompt);
                string input = Console.ReadLine();
                if (input.Length < MaxLength + 1)
                {
                    return input;
                }
                else
                {
                    if (input.Length > MaxLength)
                        Console.WriteLine("Input was too large, please stay under " + MaxLength + " digits");
                    
                    System.Threading.Thread.Sleep(1500);
                }
            }
            return "";
        }

        static string GetID(int oldID)
        {
            int dummy = oldID;
            string newID;
            List<int> numList = new List<int>();
            while (oldID > 0) {
                numList.Add(oldID % 10);
                oldID = oldID / 10;
            }
            numList.Reverse();
            if (numList.Count != 6)
            {
                return dummy.ToString();
            }
            newID = numList[0] + "-" + numList[1] + numList[2] + "-" + numList[3] + numList[4] + numList[5];
            return newID;
        }

        #region New Student
        /// <summary>
        /// Run the prompt for creating a new student
        /// </summary>
        static void newStudent()
        {
            student NewStudent = new student();

            NewStudent.ID = GetInt("Input the desired student ID: (######)");           

            Console.Clear();

            NewStudent.FirstName = GetString("Input the desired student first name: (ABCDXYZ)");

            Console.Clear();

            NewStudent.LastName = GetString("Input the desired student last name: (ABCDXYZ)");

            Console.Clear();

            int classesNum = GetInt("How many classes is the student in? (#)");

            List<classes> newClassList = new List<classes>();

            for (int i = 0; i < classesNum; i++)
            {
                classes newClass = new classes();
                newClass.CourseID = GetInt("Input course ID: (####)");
                newClass.CourseNumber = GetString("Input course number: (ABCD####");
                newClass.CourseName = GetString("Input course name: (ABCXYZ)");
                newClass.Credit = GetInt("Input course credit amount: (#)");
                newClass.Semester = GetString("Input course semester: (ABCXYZ)");
                newClass.Year = GetInt("Input course year: (####)");
                newClass.CourseType = GetString("Input course type: (ABCXYZ)");
                newClass.CourseGrade = GetString("Input course grade:");
                newClassList.Add(newClass);
            }

            NewStudent.Classes = newClassList;

            students.Add(NewStudent);
            Console.Clear();
            Console.WriteLine("Added New Student:");
            Console.WriteLine("Student Identification Number: " + NewStudent.ID);
            Console.WriteLine("First Name: "+ NewStudent.FirstName);
            Console.WriteLine("Last Name: "+ NewStudent.LastName);
            Console.WriteLine("Class(es):");
            foreach (var clss in NewStudent.Classes)
            {
                Console.WriteLine(clss.CourseName);
            }

            Console.ReadKey();
            Console.Clear();

            SaveStudents();
        }
        #endregion

        #region LoadStudents
        /// <summary>
        /// Clear the lists so they're empty before loading in the students
        /// </summary>
        static void ClearCurrentEntries()
        {
            students.Clear();

            studentID.Clear();
            studentFirstName.Clear();
            studentLastName.Clear();
            classNumbers.Clear();
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
                using (Stream stream = File.Open(Directory.GetCurrentDirectory() + "data.bin", FileMode.Open))
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
                        foreach (var clss in boi.Classes)
                        {
                            classNumbers.Add(clss.CourseNumber, boi);
                        }
                    }
                }
            }
            catch (IOException)
            {
                // The file might not be created yet
            }
        }
        #endregion

        #region SaveStudents
        /// <summary>
        /// Saves the student infomation to a document inside a data file
        /// </summary>
        static void SaveStudents()
        {
            try
            {
                using (Stream stream = File.Open(Directory.GetCurrentDirectory() + "data.bin", FileMode.Create))
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
        #endregion

        #region Intro
        static void Intro()
        {
            string[] introText = new string[11];
            introText[0] = (" ______   ______     ______     __    __   ");
            introText[1] = ("/\\__  _\\ /\\  ___\\   /\\  __ \\   /\\ \" -./  \\  ");
            introText[2] = ("\\/_/\\ \\/ \\ \\  __\\   \\ \\  __ \\  \\ \\ \\-./\\ \\ ");
            introText[3] = ("   \\ \\_\\  \\ \\_____\\  \\ \\_\\ \\_\\  \\ \\_\\ \\ \\_\\                     ");
            introText[4] = ("    \\/_/   \\/_____/   \\/_/\\/_/   \\/_/  \\/_/                     ");
            introText[5] = ("                                                                ");
            introText[6] = (" ______     __  __     ______   ______     __  __     ______    ");
            introText[7] = ("/\\  ___\\   /\\ \\_\\ \\   /\\  == \\ /\\  == \\   /\\ \\/\\ \\   /\\  ___\\   ");
            introText[8] = ("\\ \\ \\____  \\ \\____ \\  \\ \\  _-/ \\ \\  __<   \\ \\ \\_\\ \\  \\ \\___  \\  ");
            introText[9] = (" \\ \\_____\\  \\/\\_____\\  \\ \\_\\    \\ \\_\\ \\_\\  \\ \\_____\\  \\/\\_____\\ ");
            introText[10] = ("  \\/_____/   \\/_____/   \\/_/     \\/_/ /_/   \\/_____/   \\/_____/ ");

            foreach (var line in introText)
            {
                Console.WriteLine(line);
                System.Threading.Thread.Sleep(100);
            }
            System.Threading.Thread.Sleep(400);

            for (int i = 0; i < 4; i++)
            {
                Console.Clear();
                System.Threading.Thread.Sleep(100);
                foreach (var line in introText)
                {
                    Console.WriteLine(line);
                }
                System.Threading.Thread.Sleep(100);
            }

            Console.WriteLine("\nWelcome to the Team Cyprus Student Database!");
            System.Threading.Thread.Sleep(100);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        #endregion

        [Serializable]
        internal class classes
        {
            public int CourseID = 0;
            public string CourseNumber = null;
            public string CourseName = null;
            public int Credit = 0;
            public string Semester = null;
            public int Year = 0;
            public string CourseType = null;
            public string CourseGrade = null;
        }

        [Serializable]
        internal class student
        {
            public int ID = 0;          
            public string FirstName = null;
            public string LastName = null;
            public List<classes> Classes = null;
        }
    }
}
