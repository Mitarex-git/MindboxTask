using GeometricShapesProcessor;
using GeometricShapesProcessor.Shapes;

namespace GeometricShapeProcessorTests.ShapesTests;

public class CircleTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ConstructorNegativeRadius()
    {
        void Constructor() => new Circle(-5);
        Assert.Catch(typeof(ArgumentOutOfRangeException), Constructor);
    }
    
    [Test]
    public void AreaExpectedRadius()
    {
        var calc = new Calculator(new Circle(5));
        Assert.AreEqual(78.539816339744830961566084581988, calc.GetShapeArea(), 0.000001);
    }
    
    [Test]
    public void AreaSmallRadius()
    {
        var calc = new Calculator(new Circle(5E-100));
        Assert.AreEqual(78.539816339744830961566084581988e-200, calc.GetShapeArea(), 0.000001e-200);
    }
    
    [Test]
    public void AreaLargeRadius()
    {
        var calc = new Calculator(new Circle(1.59e+50));
        Assert.AreEqual(7.9422603875403562861574087372689e+100, calc.GetShapeArea(), 0.000001e+100);
    }
    
    [Test]
    public void AreaZeroRadius()
    {
        var calc = new Calculator(new Circle(0));
        Assert.AreEqual(0, calc.GetShapeArea(), 0.000001);
    }
}