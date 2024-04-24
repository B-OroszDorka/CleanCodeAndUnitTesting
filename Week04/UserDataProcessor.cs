using System.Reflection.Metadata.Ecma335;

namespace Week04
{
    internal class UserDataProcessor
    {
        //Maintainability index: 58
        //Cyclomatic complexity: 8
        public string ProcessUserDataGiven(int x, int y, bool z, string[] a, int b, bool c, string d, int e)
        {
            var result = "";

            if (z && c)
            {
                for (var i = 0; i < a.Length; i++)
                {
                    if (a[i] == d)
                    {
                        result += "User found: " + d + " at index " + i.ToString();
                        break;
                    }
                }
            }
            else if (!z && c)
            {
                var count = 0;
                while (count < e)
                {
                    result += "Processing...";
                    count++;
                }
            }
            else
            {
                result = "No action taken";
            }
            return result;
        }

        //Maintainability index: 67
        //Cyclomatic complexity: 4
        public string ProcessUserDataRefactored(bool shouldFindUser, bool shouldFindUser2, string[] allUserData, string userToFind, int iterations)
        {
            var result = "";

            if (ShouldFindUser(shouldFindUser, shouldFindUser2))
            {
                result = FindUser(allUserData, userToFind);
            }
            else if (!shouldFindUser && shouldFindUser2)
            {
                result = ProcessData(iterations);
            }
            else
            {
                result = "No action taken";
            }

            return result;
        }

        //Maintainability index: 94
        //Cyclomatic complexity: 2
        private bool ShouldFindUser(bool shouldFindUser, bool shouldFindUser2)
        {
            return shouldFindUser && shouldFindUser2;
        }

        //Maintainability index: 72
        //Cyclomatic complexity: 3
        private string FindUser(string[] allUserData, string userToFind)
        {
            for (var i = 0; i < allUserData.Length; i++)
            {
                if (allUserData[i] == userToFind)
                {
                    return "User found: " + userToFind + " at index " + i.ToString();
                }
            }
            return "";
        }

        //Maintainability index: 75
        //Cyclomatic complexity: 2
        private string ProcessData(int iterations)
        {
            var result = "";
            for (var i = 0; i < iterations; i++)
            {
                result += "Processing...";
            }
            return result;
        }

    }
}