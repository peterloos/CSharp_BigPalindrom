using System;

class Digit : IComparable, ICloneable
{
    // private member data
    private int digit;

    // c'tors
    public Digit()
    {
        this.digit = 0;
    }

    public Digit(int digit) : this()
    {
        if (digit >= 0 && digit <= 9)
            this.digit = digit;
    }

    // properties
    public int Value
    {
        get
        {
            return this.digit;
        }
    }

    // type conversion operators
    public static implicit operator char(Digit d)
    {
        return (char) (d.Value + '0');
    }

    // contract with base class 'Object'
    public override bool Equals(Object o)
    {
        if (!(o is Digit))
            return false;

        return this.digit == ((Digit)o).digit;
    }

    public override String ToString()
    {
        return String.Format("{0}", this.digit);
    }

    public override int GetHashCode()
    {
        return this.digit;
    }

    // operators
    public static bool operator==(Digit d1, Digit d2)
    {
        return d1.Equals(d2);
    }

    public static bool operator!=(Digit d1, Digit d2)
    {
        return !(d1 == d2);
    }

    // implementation of interface 'ICloneable'
    public Object Clone()
    {
        return new Digit(this.digit);
    }

    // implementation of interface 'IComparable'
    public int CompareTo(Object o)
    {
        Digit d = (Digit)o;
        return (this.digit < d.digit) ? -1 : (this.digit > d.digit) ? 1 : 0;
    }
}
