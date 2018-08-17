using System;
using System.Text;

namespace NumberUsingArray
{
    class Number : IComparable, ICloneable
    {
        private Digit[] digits;

        // c'tors
        public Number()
        {
            this.digits = new Digit[0];
        }

        public Number(String s)
        {
            // count digits
            int count = 0;
            for (int i = 0; i < s.Length; i++)
                if (Char.IsDigit(s[i]))
                    count++;

            // copy digits into array in reverse order
            this.digits = new Digit[count];
            for (int k = 0, i = s.Length - 1; i >= 0; i--)
            {
                if (Char.IsDigit(s[i]))
                {
                    this.digits[k] = new Digit(s[i] - '0');
                    k++;
                }
            }
        }

        public Number(int n)
        {
            // count digits
            int tmp = n;
            int count = 0;
            while (tmp != 0)
            {
                count++;
                tmp = tmp / 10;
            }

            this.digits = new Digit[count];
            tmp = n;

            for (int i = 0; i < this.digits.Length; i++)
            {
                int rem = tmp % 10;
                Digit d = new Digit(rem);
                this.digits[i] = d;
                tmp = tmp / 10;
            }
        }

        private Number(Digit[] digits)
        {
            this.digits = digits;
        }

        // properties
        public int Count
        {
            get
            {
                return this.digits.Length;
            }
        }

        // indexer
        private Digit this[int i]
        {
            get
            {
                Digit d = new Digit(0);
                if (i >= 0 && i < this.digits.Length)
                    d = this.digits[i];
                return d;
            }
        }

        public bool IsSymmetric
        {
            get
            {
                for (int i = 0; i < this.digits.Length / 2; i++)
                    if (this.digits[i] != this.digits[this.digits.Length - 1 - i])
                        return false;

                return true;
            }
        }

        public Number Reverse()
        {
            Digit[] digits = new Digit[this.digits.Length];
            for (int i = 0; i < this.digits.Length; i++)
                digits[i] = (Digit)this.digits[this.digits.Length - 1 - i].Clone();

            return new Number(digits);
        }

        public void AddDigit(Digit d)
        {
            Digit[] tmp = new Digit[this.digits.Length + 1];

            // copy old digits
            for (int i = 0; i < this.digits.Length; i++)
            {
                tmp[i] = this.digits[i];
            }

            // add new digit
            tmp[this.digits.Length] = d;

            // switch to new array
            this.digits = tmp;
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
                result.AddDigit(d);
            }
            if (carry == 1)
            {
                Digit d = new Digit(1);
                result.AddDigit(d);
            }

            return result;
        }

        // overloading operators
        public static bool operator== (Number n1, Number n2)
        {
            return n1.Equals(n2);
        }

        public static bool operator !=(Number n1, Number n2)
        {
            return ! n1.Equals(n2);
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
            Digit[] digits = new Digit[this.digits.Length];
            for (int i = 0; i < this.digits.Length; i++)
                digits[i] = (Digit)this.digits[i].Clone();

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
                if (!this.digits[i].Equals(n.digits[i]))
                    return this.digits[i].CompareTo(n.digits[i]);

            return 0;
        }
    }
}
