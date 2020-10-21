using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    class Player
    {
        const int BEGIN_X = 64;
        const int BEGIN_Y = 128;
        private Texture2D texture, currentTexture;
        Animation animationLeft, animationRight, animationIdle, currentAnimation;
        public Vector2 position = new Vector2(BEGIN_X, BEGIN_Y);
        private Vector2 velocity;
        private Rectangle rectangle;
        private SpriteEffects sprEff;
        private bool gesprongen;
        public bool HasCrystal;
        public bool HasSnowMan;
        public int levens = 2;

        public Vector2 Position
        {
            get { return position; }
        }
        public Player() {

            CreateAnimationLeft();
            CreateAnimationRight();
            CreateAnimationIdle();
        }

        private void CreateAnimationLeft()
        {
            animationLeft = new Animation();

            animationLeft.AddFrame(new Rectangle(115, 0, 75, 70));
            animationLeft.AddFrame(new Rectangle(190, 0, 67, 70));
            animationLeft.AddFrame(new Rectangle(257, 0, 68, 70));
            animationLeft.AddFrame(new Rectangle(325, 0, 62, 70));
            animationLeft.AddFrame(new Rectangle(387, 0, 74, 70));
            animationLeft.AddFrame(new Rectangle(452, 0, 68, 70));

            currentAnimation = animationLeft;

        }

        private void CreateAnimationIdle()
        {
            animationIdle = new Animation();

            animationIdle.AddFrame(new Rectangle(0, 0, 60, 70));

            currentAnimation = animationIdle;
        }

        private void CreateAnimationRight()
        {

            animationRight = new Animation();

            animationRight.AddFrame(new Rectangle(115, 0, 75, 70));
            animationRight.AddFrame(new Rectangle(190, 0, 67, 70));
            animationRight.AddFrame(new Rectangle(257, 0, 68, 70));
            animationRight.AddFrame(new Rectangle(325, 0, 62, 70));
            animationRight.AddFrame(new Rectangle(387, 0, 74, 70));
            animationRight.AddFrame(new Rectangle(452, 0, 68, 70));

            currentAnimation = animationRight;
        }
        
        public void Load(ContentManager Content)
        {
            texture = Content.Load<Texture2D>("Speler");
        }
        public void Update(GameTime gameTime)
        {
            isDead();
            Input(gameTime);

            position += velocity;
            rectangle = new Rectangle((int)position.X, (int)position.Y, currentAnimation.currentFrame.SourceRectangle.Width, currentAnimation.currentFrame.SourceRectangle.Height);

            if (velocity.Y < 10)
                velocity.Y += 0.4f;
        }
        private void Input(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Right) && !Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                velocity.X = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;
                sprEff = SpriteEffects.None;
                currentAnimation = animationRight;
                currentTexture = texture;
            }

            else if (Keyboard.GetState().IsKeyDown(Keys.Left) && !Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                velocity.X = -(float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;
                sprEff = SpriteEffects.FlipHorizontally;
                currentAnimation = animationLeft;
                currentTexture = texture;
            }

            else
            {
                velocity.X = 0f;
                currentAnimation = animationIdle;
                currentTexture = texture;
            } 

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && gesprongen == false)
            {
                position.Y -= 5f;
                velocity.Y = -8f;
                gesprongen = true;
            }
        }

        public void CollisionCrystal(Rectangle newRectangle, int xOffset, int yOffset)
        {
            if (rectangle.isOnTopOf(newRectangle) || rectangle.IsOnLeftOf(newRectangle) || rectangle.IsOnRightOf(newRectangle) || rectangle.IsOnBottomOf(newRectangle))
                HasCrystal = true;  
        }

        public void CollisionSnowMan(Rectangle newRectangle, int xOffset, int yOffset)
        {
            if (rectangle.isOnTopOf(newRectangle) || rectangle.IsOnLeftOf(newRectangle) || rectangle.IsOnRightOf(newRectangle) || rectangle.IsOnBottomOf(newRectangle))
                HasSnowMan = true;
        }

        public void Collision(Rectangle newRectangle, int xOffset, int yOffset)
        {
            if (rectangle.isOnTopOf(newRectangle))
            {
                rectangle.Y = newRectangle.Y - rectangle.Height;
                velocity.Y = 0f;
                gesprongen = false;
            }

            if (rectangle.IsOnLeftOf(newRectangle))
                position.X = newRectangle.X - rectangle.Width - 1;

            if (rectangle.IsOnRightOf(newRectangle))
                position.X = newRectangle.X + newRectangle.Width + 1;

            if (rectangle.IsOnBottomOf(newRectangle))
                velocity.Y = 1f;

            if (position.X < 0)
                position.X = 0;
            if (position.X > xOffset - rectangle.Width)
                position.X = xOffset - rectangle.Width;
            if (position.Y < 0)
                velocity.Y = 1f;
            if (position.Y > yOffset - rectangle.Height)
                position.Y = yOffset - rectangle.Height;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(currentTexture, position, currentAnimation.currentFrame.SourceRectangle, Color.AliceBlue, 0f, new Vector2(0, 0), 1, sprEff, 1);
        }

        private void isDead()
        {
            if(position.Y > 569)
            {
                position.X = BEGIN_X;
                position.Y = BEGIN_Y;
                levens--;
            }
        }
    }
}
