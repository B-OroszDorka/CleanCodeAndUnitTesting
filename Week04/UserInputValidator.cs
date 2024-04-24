using System.Text.RegularExpressions;

namespace Week04
{
    internal class UserInputValidator
    {
        //Maintainability index: 70
        //Cyclomatic complexity: 5
        public bool ValidateUserInputGiven(string userInput)
        {
            if(userInput.Trim() != "")
            {
                if(userInput.Length >= 5 && userInput.Length <= 20)
                {
                    if (Regex.IsMatch(userInput, @"^[a-zA-Z0-9]+$"))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        //Maintainability index: 76
        //Cyclomatic complexity: 4
        public bool ValidateUserInputRefactored(string userInput)
        {
            if (string.IsNullOrWhiteSpace(userInput) || userInput.Length < 5 || userInput.Length > 20)
            {
                return false;
            }
            return Regex.IsMatch(userInput, @"^[a-zA-Z0-9]+$");
        }

    }
}
