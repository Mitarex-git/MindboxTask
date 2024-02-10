namespace GeometricShapesProcessor.Utility;

public static class DoubleMath
{
    public static double ChooseEpsilon(IEnumerable<double> values, double epsilonMantissa)
    {
        return epsilonMantissa * Math.Pow(10, values.Max().GetExponent());
    }

    public static double GetExponent(this double value)
    {
        return (int)Math.Floor(Math.Log10(Math.Abs(value)));
    }
}