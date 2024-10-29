using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Practice_DB
{
    internal class Menu
    {
        public void MainMenu()
        {
            var dbCtx = new StudentDbCtx();
            bool IsRunning = true;
            do
            {
                Console.Clear();
                Console.WriteLine("1. Registrera ny student: \n" +
                    "2. Ändra studentuppgifter: \n" +
                    "3. Lista alla studenter: \n" +
                    "4. Avsluta");

                int userChoice = Convert.ToInt32(Console.ReadLine());

                switch (userChoice)
                {
                    case 1:
                        Console.WriteLine("Ange förnamn: ");
                        string? FirstName = Console.ReadLine();
                        Console.WriteLine("Ange efternamn: ");
                        string? LastName = Console.ReadLine();
                        Console.WriteLine("Ange hemstad: ");
                        string? City = Console.ReadLine();

                        dbCtx.Add(new Student( FirstName, LastName, City));  
                        dbCtx.SaveChanges();
                        break;

                    case 2:
                        Console.WriteLine("Ange förnamn på student du vill ändra: ");
                        ShowListStudents(dbCtx);
                        string? nameChoice = Console.ReadLine();
                        var student = dbCtx.Students.Where(s => s.FirstName == nameChoice).FirstOrDefault<Student>();
                        Console.WriteLine("Vad vill du ändra? \n" +
                            "1. Förnamn \n" +
                            "2. Efternamn \n" +
                            "3. Hemstad \n" +
                            "4. Samtliga");
                        int choice = Convert.ToInt32(Console.ReadLine());
                        if (choice == 1)
                        {
                            Console.WriteLine("Vilket namn ska det vara?: ");
                            string? fNameChoice = Console.ReadLine();
                            student.FirstName = fNameChoice;
                            break;
                        }
                        else if (choice == 2)
                        {
                            Console.WriteLine("Vilket efternamn ska det vara?: ");
                            string? lNameChoice = Console.ReadLine();
                            student.LastName = lNameChoice;
                            break;
                        }
                        else if (choice == 3)
                        {
                            Console.WriteLine("Vilken hemstad ska det vara?: ");
                            string? cityChoice = Console.ReadLine();
                            student.City = cityChoice;
                            break;
                        }
                        else 
                            Console.WriteLine("Ange nytt förnamn: ");
                            string? newFName = Console.ReadLine();
                            student.FirstName = newFName;
                            Console.WriteLine("Ange nytt efternamn: ");
                            string? newLName = Console.ReadLine();
                            student.LastName = newLName;
                            Console.WriteLine("Ange ny hemstad: ");
                            string? newCity = Console.ReadLine();
                        student.City = newCity;
                            break;

                    case 3:
                        ShowListStudents(dbCtx);
                        Console.ReadLine();
                        break;

                    case 4:
                        Console.WriteLine("Avsluta");
                        Environment.Exit(0);
                        IsRunning = false;
                        break;

                    default:
                        Console.WriteLine("Ogiltigt val, välj 1-4: ");
                        break;
                }

            } while (IsRunning);
        }

        private static void ShowListStudents(StudentDbCtx dbCtx)
        {
            foreach (Student s in dbCtx.Students)
            {
                Console.WriteLine($"{s.FirstName} {s.LastName} {s.City}");
            }
        }
    }
}
