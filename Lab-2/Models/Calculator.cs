namespace Labolatorium2.Models
{
    public class Calculator
    {
        public double? A { get; set; }
        public double? B { get; set; }
        public Operators? Op { get; set; }

        public bool IsValid()
        {
            return A != null && B != null && Op !=null;
        }
        public double Calculate()
        {
            switch (Op) 
            {
                case Operators.Add:
                    return (double)(A + B);
                case Operators.Sub:
                    return (double)(A - B);
                case Operators.Mul:
                    return (double)(A * B);
                case Operators.Div:
                    return (double)(A / B);
                default: return double.NaN;
            }
        }
    }
}
