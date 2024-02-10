namespace GeometricShapesProcessor.Shapes;

public class Circle: IShape
{
    private double Radius { get; }

    public Circle(double radius)
    {
        if (radius < 0)
            throw new ArgumentOutOfRangeException(nameof(radius), "Radius cannot be a negative value.");
        Radius = radius;
    }

    public double Area => Radius * Radius * Math.PI;
}