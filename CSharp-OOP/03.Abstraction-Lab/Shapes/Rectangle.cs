using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : IDrawable
    {
        private int height;
        private int width;

        public Rectangle(int height, int width)
        {

            Height = height;
            Width = width;
        }

        public int Width { get => width; set => width = value; }

        public int Height { get => height; set => height = value; }

        public void Drow()
        {
            for (int row = 0; row < Height; row++)
            {
                for (int col = 0; col < Width; col++)
                {
                    Console.Write('*');
                }
                Console.WriteLine();
            }
        }
    }
}
