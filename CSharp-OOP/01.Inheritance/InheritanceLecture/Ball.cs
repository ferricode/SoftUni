using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceLecture
{
    class Ball : GameObject
    {
        public Ball(Position position, Direction direction)
            :base (position)
        {
           
            Direction = direction;
        }
        public Direction Direction { get; set; }
        public override void Draw()
        {
            Console.SetCursorPosition(Position.Y, Position.X);
            Console.Write("@");
        }
    }
}
