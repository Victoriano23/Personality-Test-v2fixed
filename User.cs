using System;

namespace Reflection
{
    class User
    {
        public string UserName { get; set; }
        public Dictionary<string, string> TestResults { get; private set; }

        public User(string userName)
        {
            UserName = string.IsNullOrWhiteSpace(userName) ? "Anonymous" : userName;
            TestResults = new Dictionary<string, string>();
        }

        public void AddTestResult(string testName, string result)
        {
            if (TestResults.ContainsKey(testName))
            {
                TestResults[testName] = result; // Update existing result
            }
            else
            {
                TestResults.Add(testName, result); // Add new result
            }
        }
    }
}
