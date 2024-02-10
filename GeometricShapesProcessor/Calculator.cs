namespace GeometricShapesProcessor;

public class Calculator
{
    private IShape Shape { get; }

    public Calculator(IShape shape)
    {
        Shape = shape;
    }

    public double GetShapeArea()
    {
        return Shape.Area;
    }
}