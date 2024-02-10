using GeometricShapesProcessor.Utility;

namespace GeometricShapesProcessor.Shapes;

public class Triangle: IShape
{
    private double Side1 { get; }
    private double Side2 { get; }
    private double Side3 { get; }

    public Triangle(double side1, double side2, double side3)
    {
        if (side1 <= 0 || side2 <= 0 || side3 <= 0)
            throw new ArgumentOutOfRangeException();
        
        var epsilon = DoubleMath.ChooseEpsilon(new[] { side1, side2, side3 }, 0.000001);
        if (side1 + side2 + epsilon < side3 || side1 + side3 + epsilon < side2 || side2 + side3 + epsilon < side1)
            throw new ArgumentException("Impossible side lengths for a triangle.");
        
        Side1 = side1;
        Side2 = side2;
        Side3 = side3;
    }

    public double Area
    {
        get
        {
            double p = (Side1 + Side2 + Side3) / 2;
            return Math.Sqrt(p * (p - Side1) * (p - Side2) * (p - Side3)); //Heron's formula
        }
    }

    public bool IsOrthogonal
    {
        get
        {
            var epsilon = DoubleMath.ChooseEpsilon(new[] { Side1, Side2, Side3 }, 0.000001);
            var squared1 = Side1 * Side1; var squared2 = Side2 * Side2; var squared3 = Side3 * Side3;
            return (Math.Abs(squared1 - (squared2 + squared3)) < epsilon
                    || Math.Abs(squared2 - (squared1 + squared3)) < epsilon
                    || Math.Abs(squared3 - (squared1 + squared2)) < epsilon);
        }
    }
}