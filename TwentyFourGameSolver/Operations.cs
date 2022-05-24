namespace TwentyFourGameSolver
{
    public static class Operation
    {
        public static double calculate(this Operations op, double a, double b) =>
            op switch
            {
                Operations.Sum => a + b,
                Operations.Subtract => a - b,
                Operations.Divide => a / b,
                Operations.Multiply => a * b,
                _ => -1,
            };


        public static string ToString(this Operations op, bool overrideMe) =>
            op switch
            {
                Operations.Sum => "+",
                Operations.Subtract => "-",
                Operations.Divide => "/",
                Operations.Multiply => "*",
                _ => "NaN",
            };


        public enum Operations
        {
            Sum,
            Subtract,
            Divide,
            Multiply
        }
    }

}
