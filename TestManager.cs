using System;

namespace Reflection
{
    class TestManager
    {
        private Dictionary<string, string> testResults = new Dictionary<string, string>(); // Stores test results

        public void ViewTestResults(string userName)
        {
            Console.Clear();
            Console.WriteLine("********* TEST RESULTS *********");
            Console.WriteLine($"User: {userName}");

            if (testResults.Count == 0)
            {
                Console.WriteLine("No test results available.");
            }
            else
            {
                foreach (var result in testResults)
                {
                    Console.WriteLine($"{result.Key}: {result.Value}");
                }
            }

            Console.WriteLine("\nPress enter to continue");
            Console.ReadLine();
        }

        public void ZodiacSignTest(string userName)
        {
            Console.Clear();
            Console.WriteLine("Enter your birthdate (YYYY-MM-DD):");

            DateTime birthdate;
            if (!DateTime.TryParse(Console.ReadLine(), out birthdate))
            {
                Console.WriteLine("Invalid date format.");
                Console.ReadLine();
                return;
            }

            int age = CalculateAge(birthdate);
            string zodiacSign = GetZodiacSign(birthdate.Month, birthdate.Day);

            Console.WriteLine($"Your age is: {age}");
            Console.WriteLine($"Your zodiac sign is: {zodiacSign}");
            testResults["Zodiac Sign"] = $"Age: {age}, Sign: {zodiacSign}";

            Console.ReadLine();
        }

        public void PersonalityTest()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Personality Type Quiz!");
            Console.WriteLine("For each statement, enter a number from 1 to 5 based on how well it describes you.");
            Console.WriteLine("1: Strongly Disagree");
            Console.WriteLine("2: Disagree");
            Console.WriteLine("3: Neutral");
            Console.WriteLine("4: Agree");
            Console.WriteLine("5: Strongly Agree");

            string[] questions = {
               "Do you feel energized after spending time with a large group of people?",
               "Do you prefer one-on-one conversations over group activities?",
               "Do you enjoy spending time alone to recharge?",
               "Do you feel comfortable being the center of attention in social situations?",
               "Do you find it easy to strike up a conversation with new people?",
               "Do you prefer a few close friends over many acquaintances?",
               "Do you tend to think before you speak?",
               "Do you often feel lonely if you don't have social interaction for a while?",
               "Do you enjoy participating in group activities and events?",
               "Do you find it exhausting to be in social settings for long periods of time?"
            };

            List<int> responses = AskQuestions(questions);
            int totalScore = CalculateTotalScore(responses);
            string personalityType = DeterminePersonalityType(totalScore);

            Console.Clear();
            Console.WriteLine("\nPersonality Test Results:");
            Console.WriteLine($"Total Score: {totalScore}");
            Console.WriteLine($"Personality Type: {personalityType}");
            testResults["Personality Test"] = $"Total Score: {totalScore}, Type: {personalityType}";
            Console.ReadLine();
        }

        public void EQTest()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Emotional Intelligence Test!");
            Console.WriteLine("Answer each question to assess your emotional intelligence level.");
            Console.WriteLine("Please enter a number between 1 and 5 based on how well each statement applies to you.");
            Console.WriteLine("1: Strongly Disagree");
            Console.WriteLine("2: Disagree");
            Console.WriteLine("3: Neutral");
            Console.WriteLine("4: Agree");
            Console.WriteLine("5: Strongly Agree");

            string[] questions = {
                "I am aware of my emotions as I experience them.",
                "I can manage my emotions effectively, even in difficult situations.",
                "I am empathetic and can understand how others are feeling.",
                "I can build and maintain strong relationships with others.",
                "I am able to resolve conflicts in a positive manner."
            };

            List<int> responses = AskQuestions(questions);
            int totalScore = CalculateTotalScore(responses);
            string EQLevel = DetermineEQLevel(totalScore);

            Console.Clear();
            Console.WriteLine("\nEQ Test Results:");
            Console.WriteLine($"Total Score: {totalScore}");
            Console.WriteLine($"Emotional Intelligence Level: {EQLevel}");
            testResults["EQ Test"] = $"Total Score: {totalScore}, Level: {EQLevel}";
            Console.ReadLine();
        }

        public void CreativityTest()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Creativity Test!");
            Console.WriteLine("Answer the following questions to assess your creativity level.");
            Console.WriteLine("Please enter a number between 1 and 5 based on how well each statement applies to you.");
            Console.WriteLine("1: Strongly Disagree");
            Console.WriteLine("2: Disagree");
            Console.WriteLine("3: Neutral");
            Console.WriteLine("4: Agree");
            Console.WriteLine("5: Strongly Agree");

            string[] questions = {
                "When faced with a problem, I often come up with multiple solutions.",
                "I enjoy imagining new and unusual scenarios.",
                "I often find myself thinking outside the box.",
                "I like experimenting with different ideas to see what works.",
                "I feel confident in my ability to generate innovative ideas."
            };

            List<int> responses = AskQuestions(questions);
            int totalScore = CalculateTotalScore(responses);
            string creativityLevel = DetermineCreativityLevel(totalScore);

            Console.Clear();
            Console.WriteLine("\nCreativity Test Results:");
            Console.WriteLine($"Total Score: {totalScore}");
            Console.WriteLine($"Creativity Level: {creativityLevel}");
            testResults["Creativity Test"] = $"Total Score: {totalScore}, Level: {creativityLevel}";
            Console.ReadLine();
        }

        public void SocialTest()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Social Interaction Test!");
            Console.WriteLine("Answer the following questions to assess your social skills.");
            Console.WriteLine("Please enter a number between 1 and 5 based on how well each statement applies to you.");
            Console.WriteLine("1: Strongly Disagree");
            Console.WriteLine("2: Disagree");
            Console.WriteLine("3: Neutral");
            Console.WriteLine("4: Agree");
            Console.WriteLine("5: Strongly Agree");

            string[] questions = {
                "I find it easy to strike up a conversation with new people.",
                "I enjoy attending social gatherings and meeting new people.",
                "I feel comfortable being the center of attention in social situations.",
                "I can easily understand social cues and respond appropriately.",
                "I feel energized after spending time with a large group of people."
            };

            List<int> responses = AskQuestions(questions);
            int totalScore = CalculateTotalScore(responses);
            string socialLevel = DetermineSocialLevel(totalScore);

            Console.Clear();
            Console.WriteLine("\nSocial Test Results:");
            Console.WriteLine($"Total Score: {totalScore}");
            Console.WriteLine($"Social Interaction Level: {socialLevel}");
            testResults["Social Test"] = $"Total Score: {totalScore}, Level: {socialLevel}";
            Console.ReadLine();
        }

  

        private List<int> AskQuestions(string[] questions)
        {
            List<int> responses = new List<int>();

            for (int i = 0; i < questions.Length; i++)
            {
                Console.WriteLine($"\nQuestion {i + 1}: {questions[i]}");
                responses.Add(GetValidResponse());
            }

            return responses;
        }

        private int GetValidResponse()
        {
            int response;
            while (!int.TryParse(Console.ReadLine(), out response) || response < 1 || response > 5)
            {
                Console.WriteLine("Please enter a number between 1 and 5.");
            }
            return response;
        }

        private int CalculateTotalScore(List<int> responses)
        {
            int totalScore = 0;
            foreach (int response in responses)
            {
                totalScore += response;
            }
            return totalScore;
        }

        private string DeterminePersonalityType(int totalScore)
        {
            if (totalScore >= 10 && totalScore <= 24)
            {
                return "Introvert";
            }
            else if (totalScore >= 25 && totalScore <= 34)
            {
                return "Ambivert";
            }
            else if (totalScore >= 35 && totalScore <= 50)
            {
                return "Extrovert";
            }
            else
            {
                return "Unknown";
            }
        }

        private string DetermineEQLevel(int totalScore)
        {
            if (totalScore >= 20 && totalScore <= 25)
            {
                return "High EQ";
            }
            else if (totalScore >= 15 && totalScore <= 19)
            {
                return "Moderate EQ";
            }
            else
            {
                return "Low EQ";
            }
        }

        private string DetermineCreativityLevel(int totalScore)
        {
            if (totalScore >= 20 && totalScore <= 25)
            {
                return "Highly Creative";
            }
            else if (totalScore >= 15 && totalScore <= 19)
            {
                return "Moderately Creative";
            }
            else if (totalScore >= 10 && totalScore <= 14)
            {
                return "Somewhat Creative";
            }
            else
            {
                return "Not Very Creative";
            }
        }

        private string DetermineSocialLevel(int totalScore)
        {
            if (totalScore >= 20 && totalScore <= 25)
            {
                return "Highly Social";
            }
            else if (totalScore >= 15 && totalScore <= 19)
            {
                return "Moderately Social";
            }
            else if (totalScore >= 10 && totalScore <= 14)
            {
                return "Somewhat Social";
            }
            else
            {
                return "Not Very Social";
            }
        }

        private int CalculateAge(DateTime birthdate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthdate.Year;
            if (birthdate > today.AddYears(-age)) age--;
            return age;
        }

        private string GetZodiacSign(int month, int day)
        {
            if ((month == 1 && day >= 20) || (month == 2 && day <= 18))
                return "Aquarius";
            if ((month == 2 && day >= 19) || (month == 3 && day <= 20))
                return "Pisces";
            if ((month == 3 && day >= 21) || (month == 4 && day <= 19))
                return "Aries";
            if ((month == 4 && day >= 20) || (month == 5 && day <= 20))
                return "Taurus";
            if ((month == 5 && day >= 21) || (month == 6 && day <= 20))
                return "Gemini";
            if ((month == 6 && day >= 21) || (month == 7 && day <= 22))
                return "Cancer";
            if ((month == 7 && day >= 23) || (month == 8 && day <= 22))
                return "Leo";
            if ((month == 8 && day >= 23) || (month == 9 && day <= 22))
                return "Virgo";
            if ((month == 9 && day >= 23) || (month == 10 && day <= 22))
                return "Libra";
            if ((month == 10 && day >= 23) || (month == 11 && day <= 21))
                return "Scorpio";
            if ((month == 11 && day >= 22) || (month == 12 && day <= 21))
                return "Sagittarius";
            if ((month == 12 && day >= 22) || (month == 1 && day <= 19))
                return "Capricorn";

            return "Unknown";
        }
    }
}
