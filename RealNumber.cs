using System;

namespace Task1
{
    public class RealNumber
    {
        public double Value { get; }

        public RealNumber(double value)
        {
            Value = value;
        }

        public override string ToString() => Value.ToString();

        public static bool operator >(RealNumber a, RealNumber b) => a.Value > b.Value;
        public static bool operator <(RealNumber a, RealNumber b) => a.Value < b.Value;
        public static bool operator ==(RealNumber a, RealNumber b) => a.Value == b.Value;
        public static bool operator !=(RealNumber a, RealNumber b) => a.Value != b.Value;

        public static RealNumber operator +(RealNumber a, RealNumber b) => new(a.Value + b.Value);
        public static RealNumber operator -(RealNumber a, RealNumber b) => new(a.Value - b.Value);
        public static RealNumber operator *(RealNumber a, RealNumber b) => new(a.Value * b.Value);
        public static RealNumber operator /(RealNumber a, RealNumber b)
        {
            if (b.Value == 0) throw new DivideByZeroException("Деление на ноль!");
            return new(a.Value / b.Value);
        }

        public string Compare(RealNumber other)
        {
            if (this > other)
                return "Первое число больше";
            else if (this < other)
                return "Второе число больше";
            else
                return "Числа одинаковые";
        }

        public string ToScientificString()
        {
            if (Value == 0)
                return "+0 × 10^0"; // Ноль в научной нотации

            double mantissa = Value;
            int exponent = 0;

            while (Math.Abs(mantissa) >= 10)
            {
                mantissa /= 10;
                exponent++;
            }
            while (Math.Abs(mantissa) < 1)
            {
                mantissa *= 10;
                exponent--;
            }

            string sign = mantissa >= 0 ? "+" : "-";
            return $"{sign}{Math.Abs(mantissa):0.###} × 10^{exponent}";
        }

        public override bool Equals(object obj)
        {
            if (obj is RealNumber number)
                return Value == number.Value;
            return false;
        }

        public override int GetHashCode() => Value.GetHashCode();
    }
}
