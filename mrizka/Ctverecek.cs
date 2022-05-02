using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mrizka
{
    public class Ctverecek
    {

       
        public Point position;
        public Pen outlineColor = Pens.Black;
        public Brush color = Brushes.Green;
        public bool Locked = false;
        public Brush CurrentColor;
        public int ColorsChanged = 0;
        public int size;

        public Ctverecek(Point position)
        {
            this.size = 50;
            this.position = position;
           CurrentColor = color;
            
        }

        public void Draw(Graphics g)
        {
            g.FillRectangle(CurrentColor, position.X, position.Y, size, size);
            g.DrawRectangle(outlineColor, position.X, position.Y, size, size);
            
        }

        public bool isMouseOverObject(Point mousePos)
        {


            return mousePos.X > position.X && mousePos.X < position.X + size && mousePos.Y > position.Y && mousePos.Y < position.Y + size;
        }

        

    }
}
