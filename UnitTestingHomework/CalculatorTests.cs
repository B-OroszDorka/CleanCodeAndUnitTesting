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

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void TestAddingNegativeIntegers()
            {
                var expected = -1;
                var actual = Calculator.Add(-2, 1);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void TestAddingZeroToPositiveInteger()
            {
                var expected = 5;
                var actual = Calculator.Add(5, 0);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void TestAddingFloatingPointNumbers()
            {
                var expected = 4.5;
                var actual = Calculator.Add(2.5, 2);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void TestCommutativeProperty()
            {
                double a = 3, b = 5;

                var actual = Calculator.Add(a, b);
                var expected = Calculator.Add(b, a);

                Assert.Equal(expected, actual);

            }

        }

        public class SubtractTests
        {
            [Fact]
            public void TestSubtractingPositiveIntegers()
            {
                var expected = 1;
                var actual = Calculator.Subtract(3, 2);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void TestSubtractingNegativeIntegers()
            {
                var expected = -5;
                var actual = Calculator.Subtract(-1, 4);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void TestSubtractingZeroFromPositiveInteger()
            {
                var expected = 5;
                var actual = Calculator.Subtract(5, 0);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void TestSubtractingFloatingPointNumbers()
            {
                var expected = 1.5;
                var actual = Calculator.Subtract(3.5, 2);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void TestXLessThanY()
            {
                var expected = -2;
                var actual = Calculator.Subtract(2, 4);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void TestYLessThanX()
            {
                var expected = 2;
                var actual = Calculator.Subtract(4, 2);

                Assert.Equal(expected, actual);
            }
        }

        public class MultiplyTests
        {
            [Fact]
            public void TestMultiplyingPositiveIntegers()
            {
                var expected = 6;
                var actual = Calculator.Multiply(2, 3);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void TestMultiplyingNegativeIntegers()
            {
                var expected = -6;
                var actual = Calculator.Multiply(-2, 3);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void TestMultiplyingAnIntegerWithZero()
            {
                var expected = 0;
                var actual = Calculator.Multiply(5, 0);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void TestMultiplyingFloatingPointNumbers()
            {
                var expected = 6.75;
                var actual = Calculator.Multiply(2.25, 3);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void TestCommutativeProperty()
            {
                double a = 3, b = 5;

                var expected = Calculator.Multiply(a, b);
                var actual = Calculator.Multiply(b, a);

                Assert.Equal(expected, actual);
            }
        }

        public class DivideTests
        {
            [Fact]
            public void TestDividingPositiveIntegers()
            {
                var expected = 2;
                var actual = Calculator.Divide(6, 3);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void TestDividingNegativeIntegers()
            {
                var expected = -2;
                var actual = Calculator.Divide(-6, 3);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void TestZeroDividendThrowingError()
            {
                Assert.Throws<DivideByZeroException>(() => Calculator.Divide(5, 0));
            }

            [Fact]
            public void TestZeroDivisor()
            {
                var expected = 0;
                var actual = Calculator.Divide(0, 5);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void TestDividingFloatingPointNumbers()
            {
                var expected = 2.5;
                var actual = Calculator.Divide(5, 2);

                Assert.Equal(expected, actual);
            }
        }

        public class SquareRootTests
        {
            [Fact]
            public void TestSquareRootingPositiveNumber()
            {
                var expected = 2;
                var actual = Calculator.SquareRoot(4);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void TestSquareRootingZero()
            {
                var expected = 0;
                var actual = Calculator.SquareRoot(0);

                Assert.Equal(expected, actual);
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
                var expected = 8;
                var actual = Calculator.Power(2, 3);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void TestPoweringNegativeIntegers()
            {
                var expected = -8;
                var actual = Calculator.Power(-2, 3);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void TestPoweringZeroExponent()
            {
                var expected = 1;
                var actual = Calculator.Power(5, 0);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void TestPoweringFloatingPointNumbers()
            {
                var expected = 27.0;
                var actual = Calculator.Power(3.0, 3.0);

                Assert.Equal(expected, actual);
            }
        }
    }
}
