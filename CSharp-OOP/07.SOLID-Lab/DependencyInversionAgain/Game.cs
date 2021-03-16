using DependencyInversionAgain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInversionAgain
{
    class Game
    {
        //private IWriter writer;

        //public Game(IWriter writer)
        //{
        //    this.writer = writer;
        //}
        public Game()
        {
        
        }
        public IWriter Writer { get; set; }
        public void DrawCircle()
        {
           //writer.Write($"  *");
           //writer.Write($"*   *");
           //writer.Write($"  *");

            Writer.Write($"  *");
            Writer.Write($"*   *");
            Writer.Write($"  *");
        }
    }
}
