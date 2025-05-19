using System;

public class Fraction
{
    private int _numerator;
    private int _denominator;
    public Fraction()
    {
        _numerator = 1;
        _denominator = 1;
    }
    public Fraction(int primeiro)
    {
        _numerator = primeiro;
        _denominator = 1;
    }
    public Fraction(int primeiro, int segundo)
    {
        _numerator = primeiro;
        _denominator = segundo;
    }

    public int GetNumerator()
    {
        return _numerator;
    }
    public int GetDenominator()
    {
        return _denominator;
    }
    public string GetFractionString()
    {
        return $"{_numerator}/{_denominator}";
    }
    public double GetDecimalValue()
    {
        return Convert.ToDouble(_numerator) / Convert.ToDouble(_denominator);
    }
}


class Program
{
    static void Main(string[] args)
    {
        Fraction fraction = new Fraction(10,3);
        Console.WriteLine(fraction.GetNumerator());
        Console.WriteLine(fraction.GetDenominator());
        Console.WriteLine(fraction.GetFractionString());
        Console.WriteLine(fraction.GetDecimalValue());
    }
}
