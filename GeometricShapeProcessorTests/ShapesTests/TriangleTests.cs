using GeometricShapesProcessor;
using GeometricShapesProcessor.Shapes;

namespace GeometricShapeProcessorTests.ShapesTests;

public class TriangleTests
{
    [SetUp]
    public void Setup()
    {
    }
    
    [Test]
    public void ConstructorNonPositiveSides()
    {
        void Constructor() => new Triangle(5, -5, 5);
        Assert.Catch(typeof(ArgumentOutOfRangeException), Constructor);
    }

    [Test]
    public void ConstructorImpossibleSides()
    {
        void Constructor() => new Triangle(5, 15, 5);
        Assert.Catch(typeof(ArgumentException), Constructor);
    }
    
    [Test]
    public void Area()
    {
        var calc = new Calculator(new Triangle(3, 4, 5));
        Assert.AreEqual(6, calc.GetShapeArea(), 0.000001);
    }
    
    [Test]
    public void AreaLargeOrderDifference()
    {
        var calc = new Calculator(new Triangle(3e50, 3e50, 5e-50));
        Assert.AreEqual(0, calc.GetShapeArea(), 0.000001);
    }

    [Test]
    public void OrthogonalTrue()
    {
        Triangle triangle;
        
        triangle = new Triangle(3, 4, 5);
        Assert.IsTrue(triangle.IsOrthogonal);
        
        triangle = new Triangle(3.33333333333333333333333, 4.44444444444444444444444, 5.555555555555555555555555555);
        Assert.IsTrue(triangle.IsOrthogonal);
        
        triangle = new Triangle(5, 12, 13);
        Assert.IsTrue(triangle.IsOrthogonal);
        
        triangle = new Triangle(8, 15, 17);
        Assert.IsTrue(triangle.IsOrthogonal);
    }
    
    [Test]
    public void OrthogonalFalse()
    {
        Triangle triangle;
        
        triangle = new Triangle(3, 4, 6);
        Assert.IsFalse(triangle.IsOrthogonal);
        
        triangle = new Triangle(5, 13, 13);
        Assert.IsFalse(triangle.IsOrthogonal);
        
        triangle = new Triangle(3.33333333333333333333333, 4.44444444444444444444444, 5.655555555555555555555555555);
        Assert.IsFalse(triangle.IsOrthogonal);
    }
}