namespace Figures;

public class Triangle: Figure
{
    private readonly double _firstSide;

    private readonly double _secondSide;

    private readonly double _thirdSide;

    public Triangle(double firstSide, double secondSide, double thirdSide)
    {
        if (firstSide <= 0 || secondSide <= 0 || thirdSide <= 0)
            throw new ArgumentException("Error. Sides of the triangle must be greater than zero.");
        
        _firstSide = firstSide;
        _secondSide = secondSide;
        _thirdSide = thirdSide;
        
        var maxSide = Math.Max(firstSide, Math.Max(secondSide, thirdSide));
        var perimeter = firstSide + secondSide + thirdSide;
        
        if ((perimeter - maxSide) - maxSide < 0)
            throw new ArgumentException("The greatest side of the triangle must be greater than sum of others.");
    }

    private bool IsRightAngled()
    {
        var maxSide = Math.Max(_firstSide, Math.Max(_secondSide, _thirdSide));
        var minSide = Math.Min(_firstSide, Math.Min(_secondSide, _thirdSide));
        var perimeter = _firstSide + _secondSide + _thirdSide;

        return Math.Pow((perimeter - maxSide - minSide), 2) + Math.Pow(minSide, 2) == Math.Pow(maxSide, 2);
    }

    public override double CalculateArea()
    {
        var halfPerimetr = (_firstSide + _secondSide + _thirdSide) / 2;
        var area = Math.Sqrt(halfPerimetr * (halfPerimetr - _firstSide)
                                      * (halfPerimetr - _secondSide)
                                      * (halfPerimetr - _thirdSide));
        
        return area;
    }
}