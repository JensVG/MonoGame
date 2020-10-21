using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    class Map
    {


        private int width, height;
        private List<CollisionBlokken> collsionBlokken = new List<CollisionBlokken>();
        private List<CollisionCrystal> collisionCrystal = new List<CollisionCrystal>();
        private List<CollisionSnowMan> collisionSnowMan = new List<CollisionSnowMan>();
        public List<CollisionBlokken> CollsionBlokken
        {
            get { return collsionBlokken; }
        }
        public List<CollisionCrystal> CollsionCrystal
        {
            get { return collisionCrystal; }
        }
        public List<CollisionSnowMan> CollsionSnowMan
        {
            get { return collisionSnowMan; }
        }
        public int Width
        {
            get { return width; }
        }

        public int Height
        {
            get { return height; }
        }

        public Map() { }
        public void Generate(int[,] map,int size)
        {
            for(int x = 0; x<map.GetLength(1);x++)
                for(int y = 0; y < map.GetLength(0); y++)
                {
                    int number = map[y, x];

                    if(number == 1)
                        collsionBlokken.Add(new CollisionBlokken(number, new Rectangle(x * size, y * size, size, size)));
                    if(number == 2)
                        collisionCrystal.Add(new CollisionCrystal(number, new Rectangle(x * size, y * size, size, size)));
                    if(number == 3)
                        collisionSnowMan.Add(new CollisionSnowMan(number, new Rectangle(x * size, y * size, size, size)));

                    width = (x + 1) * size;
                    height = (y + 1) * size;
                }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (CollisionBlokken blok in collsionBlokken)
                blok.Draw(spriteBatch);
            foreach (CollisionCrystal crystal in collisionCrystal)
                crystal.Draw(spriteBatch);
            foreach (CollisionSnowMan snowman in collisionSnowMan)
                snowman.Draw(spriteBatch);
        }
    }
}
