using System;

namespace Reflection
{
    // Main Program class
    class Program
    {
        static TestManager testManager = new TestManager(); // Manages Tests
        static string userName;

        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Welcome to Personality and Skills Assessment Program!");
            Console.WriteLine("The Personality and Skills Assessment Program is a tool designed to help individuals gain a deeper understanding of their unique personality traits and core skills.");
            Console.WriteLine("By engaging in a series of thoughtfully crafted questions, users will receive information about themselves.");
            Console.WriteLine("Please Enter your username");
            userName = Console.ReadLine();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("***********************************");
                Console.WriteLine("*     KNOW MORE ABOUT YOURSELF    *");
                Console.WriteLine("***********************************");
                Console.WriteLine("*  1. WHATS YOUR ZODIAC SIGN      *");
                Console.WriteLine("*  2. PERSONALITY TEST            *");
                Console.WriteLine("*  3. EQ TEST                     *");
                Console.WriteLine("*  4. CREATIVITY TEST             *");
                Console.WriteLine("*  5. SOCIAL TEST                 *");
                Console.WriteLine("*  6. VIEW TEST RESULTS           *");
                Console.WriteLine("*  7. EXIT                        *");
                Console.WriteLine("***********************************");
                Console.Write("Enter your choice: ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        testManager.ZodiacSignTest(userName);
                        break;
                    case 2:
                        testManager.PersonalityTest();
                        break;
                    case 3:
                        testManager.EQTest();
                        break;
                    case 4:
                        testManager.CreativityTest();
                        break;
                    case 5:
                        testManager.SocialTest();
                        break;
                    case 6:
                        testManager.ViewTestResults(userName);
                        break;
                    case 7:
                        Console.Clear();
                        return;
                    default:
                        Console.WriteLine("INVALID CHOICE.");
                        break;
                }
            }
        }
    }
}