using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IDrawable rectangle = new Rectangle(4, 5);
            rectangle.Drow();

            IDrawable circle = new Circle(5);
            circle.Drow();
        }

    }
}
