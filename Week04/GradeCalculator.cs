public class GradeCalculator
{
    //Maintainability index: 70
    //Cyclomatic complexity: 4
    public string CalculateGradeGiven(int score)
    {
        if (score >= 90)
        {
            return "A";
        }
        else
        {
            if (score >= 80)
            {
                return "B";
            }
            else
            {
                if (score >= 70)
                {
                    return "C";
                }
                else
                    return "D";
            }
        }
    }

    //Maintainablitiy index: 74
    //Cyclomatic complexity: 4
    public string CalculateGradeRefactored(int score)
    {
        if (score >= 90) return "A";
        
        if (score >= 80) return "B";
        
        if (score >= 70) return "C";
        
        return "D";
    }
}


