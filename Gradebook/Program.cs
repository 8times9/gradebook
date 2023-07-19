using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook
{
    class Program
    {
        static Random rn = new Random();

        static List<List<int>> AddStudent(List<List<int>> Gradebook)
        {
            List<int> temp = new List<int>();

            int RandomGrade = rn.Next(60, 101);
            temp.Add(RandomGrade);

            RandomGrade = rn.Next(60, 101);
            temp.Add(RandomGrade);

            RandomGrade = rn.Next(60, 101);
            temp.Add(RandomGrade);

            Gradebook.Add(temp);
            return Gradebook;
        }

        static List<List<int>> AddStudent(List<List<int>> Gradebook, int NumberOfStudents)
        {
            for (int i = 0; i < NumberOfStudents; i = i + 1)
            {
                Gradebook = AddStudent(Gradebook);
            }
            return Gradebook;
        }

        static void DisplayStudents(List<List<int>> Gradebook)
        {
            for (int x = 0; x < Gradebook.Count; x = x + 1)
            {
                Console.Write("Student " + x + ":");
                for (int y = 0; y < Gradebook[x].Count; y = y + 1)
                {
                    Console.Write(" " + Gradebook[x][y] + " ");
                }
                double AverageGrade = Gradebook[x].Average();
                Console.WriteLine("   Average: " + Math.Round(AverageGrade, 2));
            }
            return;
        }

        static void FindTopStudent(List<List<int>> Gradebook)
        {
            double NewHighestAverage = 0;
            int NewHighestAverageStudent = 0;
            int Counter = 0;
            foreach (List<int> x in Gradebook)
            {
                if (x.Average() > NewHighestAverage)
                {
                    NewHighestAverage = x.Average();
                    NewHighestAverageStudent = Counter;
                }
                Counter = Counter + 1;
            }

            Console.WriteLine("\nStudent " + NewHighestAverageStudent + " has the highest average grade, at " + Math.Round(NewHighestAverage, 2));
            return;
        }

        static void Main(string[] args)
        {
            List<List<int>> Gradebook = new List<List<int>>();

            try
            {
                while (true)
                {
                    Console.WriteLine("Displayed below are your options to execute:");
                    Console.WriteLine("\n1) Add 1 student");
                    Console.WriteLine("2) Add multiple students");
                    Console.WriteLine("3) Display all students");
                    Console.WriteLine("4) Display the top student");
                    Console.WriteLine("5) Exit program");

                    string Input = Console.ReadLine();

                    if (Input == "1")
                    {
                        Console.Clear();
                        Gradebook = AddStudent(Gradebook);
                        Console.WriteLine("1 student was added to the system");
                    }
                    else if (Input == "2")
                    {
                        Console.Clear();
                        Console.WriteLine("How many students do you wish to add?");
                        int StudentsNumberInput = Convert.ToInt32(Console.ReadLine());

                        AddStudent(Gradebook, StudentsNumberInput);
                    }
                    else if (Input == "3")
                    {
                        Console.Clear();
                        DisplayStudents(Gradebook);
                    }
                    else if (Input == "4")
                    {
                        FindTopStudent(Gradebook);
                    }
                    else if (Input == "5")
                    { break; }
                    else
                    { Console.WriteLine("Sorry, the input you provided does not match a function of the gradebook."); }

                    Console.WriteLine("\nPress any key to continue.");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            catch
            { Console.WriteLine("Please make sure your input is an integer corresponding to the above 5 options"); }
        }
    }
}
