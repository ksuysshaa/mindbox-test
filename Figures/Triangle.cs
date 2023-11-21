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
    }

    private bool IsRightAngled(out List<double> sides)
    {
        sides = new List<double>{_firstSide, _secondSide, _thirdSide};
        sides.Sort();

        return Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2) == Math.Pow(sides[2], 2);
    }

    public override double CalculateArea()
    {
        double area;
        var halfPerimetr = (_firstSide + _secondSide + _thirdSide) / 2;

        if (IsRightAngled(out var sides))
            area = sides[0] * sides[1] / 2;
        else
            area = Math.Sqrt(halfPerimetr * (halfPerimetr - _firstSide)
                                          * (halfPerimetr - _secondSide)
                                          * (halfPerimetr - _thirdSide));
        
        return area;
    }
}