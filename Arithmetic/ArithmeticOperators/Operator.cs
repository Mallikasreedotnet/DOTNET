namespace ArithmeticOperators
{
    public class Operator
    {
        public static int Operations(int i, char j, int k)
        {
            switch (j)
            {
                case '+':
                    return Addition(i, k);
                case '-':
                    return Subtraction(i, k);
                case '*':
                    return Multiplication(i, k);
                case '/':
                    return Division(i, k);
                case '%':
                    return Modulus(i, k);
                default:
                    throw new Exception("Enter arithmetic operator only");
            }
        }
        public static int Addition(int a, int b)
        {
            return (a + b);
        }
        public static int Subtraction(int a, int b)
        {
            return (a - b);
        }
        public static int Multiplication(int a, int b)
        {
            return (a * b);
        }
        public static int Division(int a, int b)
        {
            return (a / b);
        }
        public static int Modulus(int a, int b)
        {
            return (a % b);
        }

    }
}