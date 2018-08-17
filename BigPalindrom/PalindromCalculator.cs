// using NumberUsingArray;
using NumberUsingList;

class PalindromCalculator
{
    private Number start;        // start number
    private Number palindrom;    // palindrom, if any
    private int limit;           // maximum number of additions
    private int steps;           // number of needed additions

    // c'tors
    public PalindromCalculator()
    {
        this.start = null;
        this.palindrom = null;
        this.limit = 1000;
        this.steps = 0;
    }

    // properties
    public Number Start
    {
        get
        {
            return this.start;
        }

        set
        {
            this.start = value;
        }
    }

    public Number Palindrom
    {
        get
        {
            return this.palindrom;
        }
    }

    public int Limit
    {
        get
        {
            return this.limit;
        }

        set
        {
            this.limit = value;
        }
    }

    public int Steps
    {
        get
        {
            return this.steps;
        }
    }

    // public methods
    public bool CalcPalindrom()
    {
        this.palindrom = null;
        this.steps = 0;

        Number n = this.start;
        for (int i = 0; i < this.limit; i++)
        {
            if (n.IsSymmetric)
            {
                this.palindrom = (Number)n.Clone();
                this.steps = i;
                return true;
            }

            Number m = n.Reverse();
            n = n.Add(m);
        }

        this.palindrom = null;
        return false;
    }
}
