using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppRetrieveStudentData
{
    internal class Program
    {
        static List<Student> students = new List<Student>();

        static void LoadDataFromFile(string filePath)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 2)
                    {
                        Student student = new Student
                        {
                            Name = parts[0].Trim(),
                            Class = parts[1].Trim()
                        };
                        students.Add(student);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found. Make sure the 'students.txt' file exists.");
                Environment.Exit(1);
            }
        }

        static void SortStudentsByName()
        {
            students.Sort((s1, s2) => string.Compare(s1.Name, s2.Name, StringComparison.OrdinalIgnoreCase));
        }

        static void DisplayStudents()
        {
            Console.WriteLine("\nSorted Student Data:");
            foreach (Student student in students)
            {
                Console.WriteLine($"{student.Name}, {student.Class}");
            }
        }

        static void SearchStudentByName(string name)
        {
            Student foundStudent = students.Find(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (foundStudent != null)
            {
                Console.WriteLine($"\nStudent Found: {foundStudent.Name}, {foundStudent.Class}");
            }
            else
            {
                Console.WriteLine("\nStudent not found.");
            }
        }

        static void Main(string[] args)
        {
            LoadDataFromFile("students.txt");
            SortStudentsByName();
            DisplayStudents();

            Console.WriteLine("\nEnter a name to search:");
            string searchName = Console.ReadLine();
            SearchStudentByName(searchName);
        }

    }
}
