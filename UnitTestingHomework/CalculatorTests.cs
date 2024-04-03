using Xunit;

namespace UnitTestingHomework
{

    public class CalculatorTests
    {
        public class AddTests
        {
            [Fact]
            public void TestAddingPositiveIntegers()
            {
                var expected = 5;
                var actual = Calculator.Add(2, 3);

                Assert.Equal(expected,actual);
            }

            [Fact]
            public void TestAddingNegativeIntegers()
            {
                var actual = -1;
                var expected = Calculator.Add(-2, 1);

                Assert.Equal(actual,expected);
            }

            [Fact]
            public void TestAddingZeroToPositiveInteger()
            {
                var actual = 5;
                var expected = Calculator.Add(5, 0);

                Assert.Equal(actual,expected);
            }

            [Fact]
            public void TestAddingFloatingPointNumbers()
            {
                var actual = 4.5;
                var expected = Calculator.Add(2.5, 2);

                Assert.Equal(actual,expected);
            }

            [Fact]
            public void TestCommutativeProperty()
            {
                double a = 3, b = 5;

                var actual = Calculator.Add(a, b);
                var expected = Calculator.Add(b, a);

                Assert.Equal(actual,expected);
            }
        }

        public class SubtractTests
        {
            [Fact]
            public void TestSubtractingPositiveIntegers()
            {
                var actual = 1;
                var expected = Calculator.Subtract(3, 2);

                Assert.Equal(actual, expected);
            }

            [Fact]
            public void TestSubtractingNegativeIntegers()
            {
                var actual = -5;
                var expected = Calculator.Subtract(-1, 4);

                Assert.Equal(actual, expected);
            }

            [Fact]
            public void TestSubtractingZeroFromPositiveInteger()
            {
                var actual = 5;
                var expected = Calculator.Subtract(5,0);

                // Assert
                Assert.Equal(actual, expected);
            }

            [Fact]
            public void TestSubtractingFloatingPointNumbers()
            {
                var actual = 1.5;
                var expected = Calculator.Subtract(3.5, 2);

                // Assert
                Assert.Equal(actual, expected);
            }

            [Fact]
            public void TestXLessThanY()
            {
                var actual = -2;
                var expected = Calculator.Subtract(2, 4);

                Assert.Equal(actual, expected);
            }

            [Fact]
            public void TestYLessThanX()
            {
                var actual = 2;
                var expected = Calculator.Subtract(4, 2);

                Assert.Equal(actual,expected);
            }
        }

        public class MultiplyTests
        {
            [Fact]
            public void TestMultiplyingPositiveIntegers()
            {
                var actual = 6;
                var expected = Calculator.Multiply(2, 3);

                Assert.Equal(actual, expected);
            }

            [Fact]
            public void TestMultiplyingNegativeIntegers()
            {
                var actual = -6;
                var expected = Calculator.Multiply(-2, 3);

                Assert.Equal(actual, expected);
            }

            [Fact]
            public void TestMultiplyingAnIntegerWithZero()
            {
                var actual = 0;
                var expected = Calculator.Multiply(5, 0);

                Assert.Equal(actual, expected);
            }

            [Fact]
            public void TestMultiplyingFloatingPointNumbers()
            {
                var actual = 6.75;
                var expected = Calculator.Multiply(2.25, 3);

                Assert.Equal(actual, expected);
            }

            [Fact]
            public void TestCommutativeProperty()
            {
                double a = 3, b = 5;

                var actual = Calculator.Multiply(a, b);
                var expected = Calculator.Multiply(b, a);

                Assert.Equal(actual, expected);
            }
        }

        public class DivideTests
        {
            [Fact]
            public void TestDividingPositiveIntegers()
            {
                var actual = 2;
                var expected = Calculator.Divide(6, 3);

                Assert.Equal(actual, expected);
            }

            [Fact]
            public void TestDividingNegativeIntegers()
            {
                var actual = -2;
                var expected = Calculator.Divide(-6, 3);

                Assert.Equal(actual,expected);
            }

            [Fact]
            public void TestZeroDividendThrowingError()
            {              
                Assert.Throws<DivideByZeroException>(() => Calculator.Divide(5, 0));
            }

            [Fact]
            public void TestZeroDivisor()
            {
                var actual = 0;
                var expected = Calculator.Divide(0, 5);

                Assert.Equal(actual, expected);
            }

            [Fact]
            public void TestDividingFloatingPointNumbers()
            {
                var actual = 2.5;
                var expect4ed = Calculator.Divide(5, 2);

                Assert.Equal(actual, expect4ed);
            }
        }

        public class SquareRootTests
        {
            [Fact]
            public void TestSquareRootingPositiveNumber()
            {
                var actual = 2;
                var expected = Calculator.SquareRoot(4);

                Assert.Equal(actual, expected);
            }

            [Fact]
            public void TestSquareRootingZero()
            {

                var actual = 0;
                var expected = Calculator.SquareRoot(0);

                Assert.Equal(actual, expected);
            }

            [Fact]
            public void TestSquareRootingNegativeNumberThrowingError()
            {                
                Assert.Throws<ArgumentException>(() => Calculator.SquareRoot(-4));
            }
        }

        public class PowerTests
        {
            [Fact]
            public void TestPoweringPositiveIntegers()
            {
                var actual = 8;
                var expected = Calculator.Power(2, 3);

                Assert.Equal(actual, expected);
            }

            [Fact]
            public void TestPoweringNegativeIntegers()
            {
                var actual = -8;
                var expected = Calculator.Power(-2, 3);

                Assert.Equal(actual, expected);
            }

            [Fact]
            public void TestPoweringZeroExponent()
            {
                var actual = 1;
                var expected = Calculator.Power(5, 0);

                Assert.Equal(actual, expected);
            }

            [Fact]
            public void TestPoweringFloatingPointNumbers()
            {
                var actual = 27.0;
                var expected = Calculator.Power(3.0, 3.0);

                Assert.Equal(actual, expected);
            }
        }
    }
}
