using Xunit;

namespace UnitTestingHomework
{

    public class CalculatorTests
    {
        public class AddTests
        {
            [Fact]
            public void TestPositiveIntegers()
            {
                Assert.Equal(5, Calculator.Add(2, 3));
            }

            [Fact]
            public void TestNegativeIntegers()
            {
                Assert.Equal(-1, Calculator.Add(-2, 1));
            }

            [Fact]
            public void TestZero()
            {
                Assert.Equal(5, Calculator.Add(5, 0));
            }

            [Fact]
            public void TestFloatingPointNumbers()
            {
                Assert.Equal(4.5, Calculator.Add(2.5, 2));
            }

            [Fact]
            public void TestCommutativeProperty()
            {
                double a = 3, b = 5;
                Assert.Equal(Calculator.Add(a, b), Calculator.Add(b, a));
            }
        }

        public class SubtractTests
        {
            [Fact]
            public void TestPositiveIntegers()
            {
                Assert.Equal(1, Calculator.Subtract(3, 2));
            }

            [Fact]
            public void TestNegativeIntegers()
            {
                Assert.Equal(-5, Calculator.Subtract(-2, 3));
            }

            [Fact]
            public void TestZero()
            {
                Assert.Equal(5, Calculator.Subtract(5, 0));
            }

            [Fact]
            public void TestFloatingPointNumbers()
            {
                Assert.Equal(1.5, Calculator.Subtract(3.5, 2));
            }

            [Fact]
            public void TestXLessThanY()
            {
                Assert.Equal(-2, Calculator.Subtract(2, 4));
            }

            [Fact]
            public void TestYLessThanX()
            {
                Assert.Equal(2, Calculator.Subtract(4, 2));
            }
        }

        public class MultiplyTests
        {
            [Fact]
            public void TestPositiveIntegers()
            {
                Assert.Equal(6, Calculator.Multiply(2, 3));
            }

            [Fact]
            public void TestNegativeIntegers()
            {
                Assert.Equal(-6, Calculator.Multiply(-2, 3));
            }

            [Fact]
            public void TestZero()
            {
                Assert.Equal(0, Calculator.Multiply(5, 0));
            }

            [Fact]
            public void TestFloatingPointNumbers()
            {
                Assert.Equal(6.75, Calculator.Multiply(2.25, 3));
            }

            [Fact]
            public void TestCommutativeProperty()
            {
                double a = 3, b = 5;
                Assert.Equal(Calculator.Multiply(a, b), Calculator.Multiply(b, a));
            }
        }

        public class DivideTests
        {
            [Fact]
            public void TestPositiveIntegers()
            {
                Assert.Equal(2, Calculator.Divide(6, 3));
            }

            [Fact]
            public void TestNegativeIntegers()
            {
                Assert.Equal(-2, Calculator.Divide(-6, 3));
            }

            [Fact]
            public void TestZeroDividend()
            {
                Assert.Throws<DivideByZeroException>(() => Calculator.Divide(5, 0));
            }

            [Fact]
            public void TestZeroDivisor()
            {
                Assert.Equal(0, Calculator.Divide(0, 5));
            }

            [Fact]
            public void TestFloatingPointNumbers()
            {
                Assert.Equal(2.5, Calculator.Divide(5, 2));
            }
        }

        public class SquareRootTests
        {
            [Fact]
            public void TestPositiveNumber()
            {
                Assert.Equal(2, Calculator.SquareRoot(4));
            }

            [Fact]
            public void TestZero()
            {
                Assert.Equal(0, Calculator.SquareRoot(0));
            }

            [Fact]
            public void TestNegativeNumber()
            {
                Assert.Throws<ArgumentException>(() => Calculator.SquareRoot(-4));
            }
        }

        public class PowerTests
        {
            [Fact]
            public void TestPositiveIntegers()
            {
                Assert.Equal(8, Calculator.Power(2, 3));
            }

            [Fact]
            public void TestNegativeIntegers()
            {
                Assert.Equal(-8, Calculator.Power(-2, 3));
            }

            [Fact]
            public void TestZeroExponent()
            {
                Assert.Equal(1, Calculator.Power(5, 0));
            }

            [Fact]
            public void TestFloatingPointNumbers()
            {
                Assert.Equal(27.0, Calculator.Power(3.0, 3.0));
            }
        }


    }
}
