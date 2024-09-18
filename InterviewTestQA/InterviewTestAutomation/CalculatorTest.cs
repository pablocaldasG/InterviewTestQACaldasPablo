using InterviewTestQA.InterviewTestAutomation;
using Xunit;

namespace InterviewTestQA
{
    // Unit tests for the Calculator class, including both happy and unhappy paths.
    public class CalculatorTest
    {
        // Instance of the Calculator class to be tested.
        private readonly Calculator _calculator;

        // Constructor initializes the Calculator instance before each test is run.
        public CalculatorTest()
        {
            _calculator = new Calculator();
        }

        // Test case: Verifies that adding two positive numbers returns the correct result.
        [Fact]
        public void Add_PositiveNumbers_ReturnsCorrectResult()
        {
            int result = _calculator.Add(5, 3);
            Assert.Equal(8, result); // Asserts that 5 + 3 equals 8.
        }

        // Unhappy path: Verifies that adding two positive numbers does not return an incorrect result.
        [Fact]
        public void Add_PositiveNumbers_ReturnsIncorrectResult()
        {
            int result = _calculator.Add(5, 3);
            Assert.NotEqual(10, result); // Asserts that 5 + 3 does NOT equal 10.
        }

        // Test case: Verifies that adding two negative numbers returns the correct result.
        [Fact]
        public void Add_NegativeNumbers_ReturnsCorrectResult()
        {
            int result = _calculator.Add(-5, -3);
            Assert.Equal(-8, result); // Asserts that -5 + -3 equals -8.
        }

        // Unhappy path: Verifies that adding two negative numbers does not return an incorrect result.
        [Fact]
        public void Add_NegativeNumbers_ReturnsIncorrectResult()
        {
            int result = _calculator.Add(-5, -3);
            Assert.NotEqual(-10, result); // Asserts that -5 + -3 does NOT equal -10.
        }

        // Test case: Verifies that subtracting two positive numbers returns the correct result.
        [Fact]
        public void Subtract_PositiveNumbers_ReturnsCorrectResult()
        {
            int result = _calculator.Subtract(5, 3);
            Assert.Equal(2, result); // Asserts that 5 - 3 equals 2.
        }

        // Unhappy path: Verifies that subtracting two positive numbers does not return an incorrect result.
        [Fact]
        public void Subtract_PositiveNumbers_ReturnsIncorrectResult()
        {
            int result = _calculator.Subtract(5, 3);
            Assert.NotEqual(5, result); // Asserts that 5 - 3 does NOT equal 5.
        }

        // Test case: Verifies that subtracting two negative numbers returns the correct result.
        [Fact]
        public void Subtract_NegativeNumbers_ReturnsCorrectResult()
        {
            int result = _calculator.Subtract(-5, -3);
            Assert.Equal(-2, result); // Asserts that -5 - -3 equals -2.
        }

        // Unhappy path: Verifies that subtracting two negative numbers does not return an incorrect result.
        [Fact]
        public void Subtract_NegativeNumbers_ReturnsIncorrectResult()
        {
            int result = _calculator.Subtract(-5, -3);
            Assert.NotEqual(0, result); // Asserts that -5 - -3 does NOT equal 0.
        }

        // Test case: Verifies that multiplying two positive numbers returns the correct result.
        [Fact]
        public void Multiply_PositiveNumbers_ReturnsCorrectResult()
        {
            int result = _calculator.Multiply(5, 3);
            Assert.Equal(15, result); // Asserts that 5 * 3 equals 15.
        }

        // Unhappy path: Verifies that multiplying two positive numbers does not return an incorrect result.
        [Fact]
        public void Multiply_PositiveNumbers_ReturnsIncorrectResult()
        {
            int result = _calculator.Multiply(5, 3);
            Assert.NotEqual(20, result); // Asserts that 5 * 3 does NOT equal 20.
        }

        // Test case: Verifies that dividing two positive numbers returns the correct result.
        [Fact]
        public void Divide_PositiveNumbers_ReturnsCorrectResult()
        {
            int result = _calculator.Divide(6, 3);
            Assert.Equal(2, result); // Asserts that 6 / 3 equals 2.
        }

        // Unhappy path: Verifies that dividing two positive numbers does not return an incorrect result.
        [Fact]
        public void Divide_PositiveNumbers_ReturnsIncorrectResult()
        {
            int result = _calculator.Divide(6, 3);
            Assert.NotEqual(4, result); // Asserts that 6 / 3 does NOT equal 4.
        }

        // Test case: Verifies that dividing by zero throws an ArgumentException.
        [Fact]
        public void Divide_ByZero_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _calculator.Divide(6, 0)); // Asserts that division by zero throws an exception.
        }

        // Test case: Verifies that squaring a positive number returns the correct result.
        [Fact]
        public void Square_PositiveNumber_ReturnsCorrectResult()
        {
            int result = _calculator.Square(5);
            Assert.Equal(25, result); // Asserts that the square of 5 is 25.
        }

        // Unhappy path: Verifies that squaring a positive number does not return an incorrect result.
        [Fact]
        public void Square_PositiveNumber_ReturnsIncorrectResult()
        {
            int result = _calculator.Square(5);
            Assert.NotEqual(20, result); // Asserts that the square of 5 does NOT equal 20.
        }

        // Test case: Verifies that finding the square root of a positive number returns the correct result.
        [Fact]
        public void SquareRoot_PositiveNumber_ReturnsCorrectResult()
        {
            double result = _calculator.SquareRoot(25);
            Assert.Equal(5, result); // Asserts that the square root of 25 is 5.
        }

        // Unhappy path: Verifies that finding the square root of a positive number does not return an incorrect result.
        [Fact]
        public void SquareRoot_PositiveNumber_ReturnsIncorrectResult()
        {
            double result = _calculator.SquareRoot(25);
            Assert.NotEqual(6, result); // Asserts that the square root of 25 does NOT equal 6.
        }

        // Test case: Verifies that finding the square root of a negative number throws an ArgumentException.
        [Fact]
        public void SquareRoot_NegativeNumber_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _calculator.SquareRoot(-25)); // Asserts that finding the square root of a negative number throws an exception.
        }
    }
}
