using System;
using System.Collections.Generic;
using System.Text;

namespace NumberUsingList
{
    class Number : IComparable, ICloneable
    {
        private List<Digit> digits;

        // c'tors
        public Number()
        {
            this.digits = new List<Digit>();
        }

        public Number(String s) : this()
        {
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (Char.IsDigit(s[i]))
                {
                    Digit d = new Digit(s[i] - '0');
                    this.digits.Add(d);
                }
            }
        }

        private Number(List<Digit> digits)
        {
            this.digits = digits;
        }

        // properties
        public int Count
        {
            get
            {
                return this.digits.Count;
            }
        }

        // indexer
        private Digit this[int i]
        {
            get
            {
                Digit d = new Digit(0);
                if (i >= 0 && i < this.digits.Count)
                    d = (Digit)this.digits[i];
                return d;
            }
        }

        public bool IsSymmetric
        {
            get
            {
                for (int i = 0; i < this.digits.Count / 2; i++)
                    if (this.digits[i] != this.digits[this.digits.Count - 1 - i])
                        return false;

                return true;
            }
        }

        public Number Reverse()
        {
            List<Digit> digits = new List<Digit>();
            for (int i = 0; i < this.digits.Count; i++)
            {
                Digit d = (Digit)this.digits[this.digits.Count - 1 - i].Clone();
                digits.Add(d);
            }

            return new Number(digits);
        }

        public Number Add(Number n)
        {
            Number result = new Number();

            int carry = 0;
            int maxDigits = Math.Max(this.Count, n.Count);
            for (int i = 0; i < maxDigits; i++)
            {
                int sum = this[i].Value + n[i].Value + carry;
                carry = (sum >= 10) ? 1 : 0;
                Digit d = new Digit(sum % 10);
                result.digits.Add(d);
            }
            if (carry == 1)
            {
                Digit d = new Digit(1);
                result.digits.Add(d);
            }

            return result;
        }

        public static bool operator ==(Number n1, Number n2)
        {
            return n1.Equals(n2);
        }

        public static bool operator !=(Number n1, Number n2)
        {
            return !n1.Equals(n2);
        }

        // contract with base class 'Object'
        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = this.Count - 1; i >= 0; i--)
                sb.Append(this.digits[i]);

            return sb.ToString();
        }

        public override bool Equals(Object o)
        {
            Number n = (Number)o;

            if (this.Count != n.Count)
                return false;

            for (int i = 0; i < this.Count; i++)
                if (!this.digits[i].Equals(n.digits[i]))
                    return false;

            return true;
        }

        public override int GetHashCode()
        {
            return this.digits.GetHashCode();
        }

        // implementation of interface 'ICloneable'
        public Object Clone()
        {
            List<Digit> digits = new List<Digit>();
            for (int i = 0; i < this.digits.Count; i++)
            {
                Digit d = (Digit)this.digits[i].Clone();
                digits.Add(d);
            }

            return new Number(digits);
        }

        // implementation of interface 'IComparable'
        public int CompareTo(Object o)
        {
            Number n = (Number)o;

            if (this.Count < n.Count)
                return -1;
            if (this.Count > n.Count)
                return 1;

            for (int i = this.Count - 1; i >= 0; i--)
            {
                Digit d1 = (Digit)this.digits[i];
                Digit d2 = (Digit)n.digits[i];

                if (!d1.Equals(d2))
                    return d1.CompareTo(d2);
            }

            return 0;
        }
    }
}
