namespace InterviewTestQA.InterviewTestAutomation
{
    public class Calculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Subtract(int a, int b)
        {
            return a - b;
        }

        public int Multiply(int a, int b)
        {
            return a * b;
        }

        public int Divide(int a, int b)
        {
            if (b == 0)
                throw new ArgumentException("Cannot divide by zero.");
            return a / b;
        }

        public int Square(int a)
        {
            return a * a;
        }
        // Updated method as the exception only evaluates if the number was 0 and missing negative numbers and also the operation as it was a / a wich always will return 1 instead of the squareroot.
        public double SquareRoot(int a)
        {
            if (a <= 0) 
                throw new ArgumentException("Cannot square root zero.");
            return Math.Sqrt(a);
        }
    }
}
