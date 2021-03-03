using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;

        }

        public double Length
        {
            get => this.length;
            private set
            {
                this.ThrowIfInvalidSide(value, nameof(Length));
                this.length = value;
            }
        }



        public double Width
        {
            get => this.width;
            private set
            {

                this.ThrowIfInvalidSide(value, nameof(Width));
                this.width = value;
            }
        }
        public double Height
        {
            get => this.height;
            private set
            {

                this.ThrowIfInvalidSide(value, nameof(Height));
                this.height = value;
            }
        }
        public double CalculateVolue()
        {
            return Width * Height * Length;
        }
        public double CalculateLateralSurfaceArea()
        {
            return 2 * Height * Length + 2 * Width * Height;
        }
        public double CalculateSurfaceArea()
        {
            return 2 * Height * Length + 2 * Width * Height + 2*Length*Width;
        }

        private void ThrowIfInvalidSide(double value, string side)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{side} cannot be zero or negative.");
            }
        }
    }
}
