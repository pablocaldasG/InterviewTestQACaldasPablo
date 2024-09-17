using InterviewTestQA.InterviewTestAutomation;
using Xunit;

namespace InterviewTestQA
{
    public class CalculatorTest
    {
        private readonly Calculator _calculator;

        public CalculatorTest()
        {
            _calculator = new Calculator();
        }

        [Fact]
        public void Add_PositiveNumbers_ReturnsCorrectResult()
        {
            int result = _calculator.Add(5, 3);
            Assert.Equal(8, result);
        }

        [Fact]
        public void Add_NegativeNumbers_ReturnsCorrectResult()
        {
            int result = _calculator.Add(-5, -3);
            Assert.Equal(-8, result);
        }

        [Fact]
        public void Subtract_PositiveNumbers_ReturnsCorrectResult()
        {
            int result = _calculator.Subtract(5, 3);
            Assert.Equal(2, result);
        }

        [Fact]
        public void Subtract_NegativeNumbers_ReturnsCorrectResult()
        {
            int result = _calculator.Subtract(-5, -3);
            Assert.Equal(-2, result);
        }

        [Fact]
        public void Multiply_PositiveNumbers_ReturnsCorrectResult()
        {
            int result = _calculator.Multiply(5, 3);
            Assert.Equal(15, result);
        }

        [Fact]
        public void Multiply_NegativeNumbers_ReturnsCorrectResult()
        {
            int result = _calculator.Multiply(-5, -3);
            Assert.Equal(15, result);
        }

        [Fact]
        public void Divide_PositiveNumbers_ReturnsCorrectResult()
        {
            int result = _calculator.Divide(6, 3);
            Assert.Equal(2, result);
        }

        [Fact]
        public void Divide_ByZero_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _calculator.Divide(6, 0));
        }

        [Fact]
        public void Square_PositiveNumber_ReturnsCorrectResult()
        {
            int result = _calculator.Square(5);
            Assert.Equal(25, result);
        }

        [Fact]
        public void SquareRoot_PositiveNumber_ReturnsCorrectResult()
        {
            double result = _calculator.SquareRoot(25);
            Assert.Equal(5, result);
        }

        [Fact]
        public void SquareRoot_NegativeNumber_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _calculator.SquareRoot(-25));
        }
    }
}
