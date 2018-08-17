using System;
using System.Linq;

// using NumberUsingArray;
using NumberUsingList;

class PalindromTestCases
{
    public static void Test10()
    {
        Digit d1 = new Digit(9);
        Console.WriteLine(d1);

        int n = d1.Value;
        Console.WriteLine(n);

        Digit d2 = new Digit(8);
        Console.WriteLine(d2);
        Console.WriteLine(d1 == d2);

        Digit d3 = (Digit)d1.Clone();
        Console.WriteLine(d3);
        Console.WriteLine(d1 == d3);

        Console.WriteLine(d1.CompareTo(d2));

        Digit d4 = (Digit)d1.Clone();
        Console.WriteLine(d1.Equals(d4));
        Console.WriteLine(d1 == d4);

        Digit d5 = new Digit(5);
        char ch = d5;
        Console.WriteLine("ch: {0}", ch);
    }

    public static void Test21()
    {
        Number n1 = new Number("911218");
        Console.WriteLine("Number:      {0}", n1);
        Console.WriteLine("Reverse:     {0}", n1.Reverse());

        Number n2 = new Number("1723337");
        Console.WriteLine("Number:      {0}", n2);
        Console.WriteLine("Count:       {0}", n2.Count);

        Number sum = n1.Add(n2);
        Console.WriteLine("Sum:         {0}", sum);
        Console.WriteLine("Symmetric:   {0}", sum.IsSymmetric);

        Number n3 = new Number("88255288");
        Console.WriteLine("Number:      {0}", n3);
        Console.WriteLine("Symmetric:   {0}", n3.IsSymmetric);
    }

    public static void Test22()
    {
        Number n1 = new Number("999");
        Console.WriteLine("Number:      {0}", n1);

        Number n2 = new Number("1");
        Console.WriteLine("Number:      {0}", n2);

        Number sum = n1.Add(n2);
        Console.WriteLine("Sum:         {0}", sum);

        bool b = sum.IsSymmetric;
        Console.WriteLine("Symmetric:   {0}", b);

        Number n3 = new Number("9999999999999");
        Console.WriteLine("Number:      {0}", n3);

        Number n4 = new Number("1");
        Console.WriteLine("Number:      {0}", n4);

        sum = n3.Add(n4);
        Console.WriteLine("Sum:         {0}", sum);

        b = n3.IsSymmetric;
        Console.WriteLine("Symmetric:   {0}", b);
        b = n4.IsSymmetric;
        Console.WriteLine("Symmetric:   {0}", b);
        b = sum.IsSymmetric;
        Console.WriteLine("Symmetric:   {0}", b);
    }

    public static void Test23()
    {
        Number n1 = new Number("123");
        Console.WriteLine("Number:      {0}", n1);

        Number n2 = (Number)n1.Clone();
        Console.WriteLine("Number:      {0}", n2);

        Console.WriteLine("{0} == {1}:  {2}", n1, n2, n1.Equals(n2));
        Console.WriteLine("{0} == {1}:  {2}", n1, n2, n1 == n2);
    }

    public static void Test31()
    {
        PalindromCalculator cal = new PalindromCalculator();
        cal.Start = new Number("89");
        cal.Limit = 1000;
        if (cal.CalcPalindrom())
            Console.WriteLine("Start {0} --> {1} steps:  Palindrom {2}",
                cal.Start, cal.Steps, cal.Palindrom);

        cal.Start = new Number("196");
        cal.Limit = 1000;
        if (!cal.CalcPalindrom())
            Console.WriteLine("Number {0} seems not to generate a palindrom (tried {1} steps) !",
                cal.Start, cal.Limit);

        cal.Start = new Number("789");
        cal.Limit = 1000;
        if (cal.CalcPalindrom())
            Console.WriteLine("Start {0} --> {1} steps:  Palindrom {2}",
                cal.Start, cal.Steps, cal.Palindrom);

        cal.Start = new Number("53978");
        if (cal.CalcPalindrom())
            Console.WriteLine("Start {0} --> {1} steps:  Palindrom {2}",
                cal.Start, cal.Steps, cal.Palindrom);

        cal.Start = new Number("52007615407");
        if (cal.CalcPalindrom())
            Console.WriteLine("Start {0} --> {1} steps:  Palindrom {2}",
                cal.Start, cal.Steps, cal.Palindrom);

        // may run very very long ......
        cal.Start = new Number("456789900345345");
        cal.Limit = 50000;
        if (!cal.CalcPalindrom())
            Console.WriteLine("Start {0}: No result after {1} steps!",
                cal.Start, cal.Limit);
        else
            Console.WriteLine("Start {0} --> {1} steps:  Palindrom {2}",
                cal.Start, cal.Steps, cal.Palindrom);
    }

    public static void Test40()
    {
        PalindromCalculator cal = new PalindromCalculator();
        cal.Limit = 1000;

        bool verbose = false;

        int foundPalindroms = 0;
        int maxSteps = -1;
        for (int i = 1; i <= 10000; i++)
        {
            String s = i.ToString();
            cal.Start = new Number(s);
            bool b = cal.CalcPalindrom();
            if (b)
            {
                foundPalindroms++;

                if (cal.Steps > maxSteps)
                    maxSteps = cal.Steps;

                if (verbose)
                {
                    Console.WriteLine("Found Palindrom: Start = {0} -- Palindrom = {1} -- Steps: {2}",
                        cal.Start, cal.Palindrom, cal.Steps);
                }
                else
                {
                    if (i % 1000 == 0)
                        Console.Write(".");
                }
            }
            else
            {
                if (verbose)
                {
                    Console.WriteLine("No Palindrom: Start = {0}", cal.Start);
                }
            }
        }

        Console.WriteLine();
        Console.WriteLine("Total Palindroms: {0}      Max Steps: {1}",
            foundPalindroms, maxSteps);
    }

    public static void MostDelayedPalindromicNumberRecord()
    {
        PalindromCalculator cal = new PalindromCalculator();
        cal.Limit = 300;
        cal.Start = new Number("1186060307891929990");
        if (cal.CalcPalindrom())
        {
            Console.WriteLine("Most Delayed Palindromic Number Record:");
            Console.WriteLine("Start:     {0}", cal.Start);
            Console.WriteLine("Palindrom: {0}", cal.Palindrom, cal.Steps);
            Console.WriteLine("Steps:     {0}", cal.Steps);
        }
    }

    // Fourth Euler problem
    public static void FourthEulerProblem()
    {
        int i = 1, j = 1;
        int candidate = 1;

        for (int n = 111; n < 999; n++)
        {
            for (int m = 111; m < 999; m++)
            {
                if (n < m)
                {
                    int prod = n * m;
                    String s = prod.ToString();
                    Number num = new Number(s);
                    if (num.IsSymmetric)
                    {
                        if (prod > candidate)
                        {
                            i = n;
                            j = m;
                            candidate = i * j;
                        }
                    }
                }
            }
        }

        Console.WriteLine("Solution of fourth Euler problem:");
        Console.WriteLine("{0} * {1} = {2}", i, j, i * j);
    }

    public static void FourthEulerProblem_LINQ()
    {
        var allProducts =
            from x in Enumerable.Range(100, 900)
            from y in Enumerable.Range(100, 900)
            where x <= y
            let product = x * y
            orderby product descending
            select new { x, y, product };

        var palindrome = (
            from n in allProducts
            let chars = n.product.ToString()
            let reverse = new string(chars.Reverse().ToArray())
            where chars == reverse
            select n
        ).First();

        Console.WriteLine("{0} * {1} = {2}",
            palindrome.x, palindrome.y, palindrome.product);
    }
}
