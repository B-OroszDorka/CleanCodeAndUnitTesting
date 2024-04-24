
using Xunit;

namespace Week04
{
    public class GradeCalculatorTest
    {
        [Fact]
        public void CalculateGradeWithPositiveInts()
        {
            // Arrange
            var calculator = new GradeCalculator();

            // Act
            var gradeA = calculator.CalculateGradeRefactored(95);
            var gradeB = calculator.CalculateGradeRefactored(85);
            var gradeC = calculator.CalculateGradeRefactored(75);
            var gradeD = calculator.CalculateGradeRefactored(65);

            // Assert
            Assert.Equal("A", gradeA);
            Assert.Equal("B", gradeB);
            Assert.Equal("C", gradeC);
            Assert.Equal("D", gradeD);
        }

        [Fact]
        public void CalculateGradeWithNegativeInt()
        {
            // Arrange
            var calculator = new GradeCalculator();

            // Act
            var gradeA = calculator.CalculateGradeRefactored(-10);

            // Assert
            Assert.Equal("D", gradeA);
        }
    }
}
