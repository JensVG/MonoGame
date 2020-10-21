using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    class CollisionBlokken : Objecten
    {
        public CollisionBlokken(int i, Rectangle newRectangle)
        {
            texture = Content.Load<Texture2D>("Blok" + i);
            this.Rectangle = newRectangle;
        }
    }
}
