using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace GameProject
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D backgroundlevel1,backgroundend;
        Map map,map2;
        Player spelerlvl1,spelerlvl2;
        Camera camera;
        Button play,again,home,exit;
        Song achtergrondmuziek;

        public static int screenWidth = 800;
        public static int screenHeight = 640;
        private SpriteFont font;
        GameState currentGameState = GameState.GameMenu;

        enum GameState
        {
            GameMenu = 0,
            Gamelevel1 = 1,
            Gamelevel2 = 2,
            GameLost = 3,
            GameWin = 4
        }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;
            graphics.ApplyChanges();

            map = new Map();
            map2 = new Map();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            camera = new Camera(GraphicsDevice.Viewport);
            home = new Button(Content.Load<Texture2D>("algemeen"), graphics.GraphicsDevice);
            home.setPosition(new Vector2(300, 175));
            play = new Button(Content.Load<Texture2D>("algemeen"), graphics.GraphicsDevice);
            play.setPosition(new Vector2(300, 250));
            again = new Button(Content.Load<Texture2D>("algemeen"), graphics.GraphicsDevice);
            again.setPosition(new Vector2(300, 250));
            exit = new Button(Content.Load<Texture2D>("algemeen"), graphics.GraphicsDevice);
            exit.setPosition(new Vector2(300, 325));
            font = Content.Load<SpriteFont>("MainMenu");
            backgroundlevel1 = Content.Load<Texture2D>("backgroundlevel1");
            backgroundend = Content.Load<Texture2D>("EndScreen");
            achtergrondmuziek = Content.Load<Song>("WinterMusic");
            MediaPlayer.Play(achtergrondmuziek);
            spelerlvl1 = new Player();
            spelerlvl2 = new Player();
            Objecten.Content = Content;

            map.Generate(new int[,]{
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,1,1,0,0,1,1,0,0,1,1,1,1,0,0,1,1,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,1,1,1,0,0,1,1,0,0,1,1,1,1,0,0,1,1,0,0,0,0,0,0,2 },
            { 0,0,0,0,0,0,1,1,1,1,0,0,1,1,0,0,1,1,1,1,0,0,1,1,0,0,0,0,1,1,1 },
            { 0,0,0,0,0,1,1,1,1,1,0,0,1,1,0,0,1,1,1,1,0,0,1,1,0,0,0,0,1,1,1 },
            { 1,1,1,1,1,1,1,1,1,1,0,0,1,1,0,0,1,1,1,1,0,0,1,1,0,0,0,0,1,1,1 },
            { 1,1,1,1,1,1,1,1,1,1,0,0,1,1,0,0,1,1,1,1,0,0,1,1,0,0,0,0,1,1,1 },
            },64);

            map2.Generate(new int[,]{
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,1,0,0,0,0,0,0,0,1,1,0,0,0,0,0 },
            { 0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,0,0,3,0 },
            { 1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1 },
            { 1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1 },
            },64);

            spelerlvl1.Load(Content);
            spelerlvl2.Load(Content);

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            MouseState mouse = Mouse.GetState();

            foreach (CollisionCrystal crystal in map.CollsionCrystal)
            {
                spelerlvl1.CollisionCrystal(crystal.Rectangle, map.Width, map.Height);
            }

            foreach (CollisionSnowMan snowman in map2.CollsionSnowMan)
            {
                spelerlvl2.CollisionSnowMan(snowman.Rectangle, map.Width, map.Height);
            }

            switch (currentGameState)
            {
                case GameState.GameMenu:
                    IsMouseVisible = true;
                    spelerlvl1.HasCrystal = false;
                    spelerlvl2.HasSnowMan = false;
                    spelerlvl1.levens = 2;
                    spelerlvl2.levens = 2;

                    if (play.isClicked == true)
                        currentGameState = GameState.Gamelevel1;

                    play.Update(mouse);
                    break;

                case GameState.Gamelevel1:
                    IsMouseVisible = false;

                    foreach (CollisionBlokken blok in map.CollsionBlokken)
                    {
                        spelerlvl1.Collision(blok.Rectangle, map.Width, map.Height);
                        camera.Update(spelerlvl1.Position, map.Width, map.Height);
                    }

                    if (spelerlvl1.HasCrystal)
                        currentGameState = GameState.Gamelevel2;
                    

                    if (spelerlvl1.levens <= 0)
                    {
                        UnloadContent();
                        currentGameState = GameState.GameLost;
                        LoadContent();
                    }
                    else if (again.isClicked && spelerlvl1.levens != 0)
                    {
                        UnloadContent();
                        currentGameState = GameState.Gamelevel2;
                        LoadContent();
                    }

                    break;

                case GameState.Gamelevel2:
                    IsMouseVisible = false;

                    if (spelerlvl2.levens <= 0)
                        currentGameState = GameState.GameLost;

                    foreach (CollisionBlokken blok in map2.CollsionBlokken)
                    {
                        spelerlvl2.Collision(blok.Rectangle, map2.Width, map2.Height);
                        camera.Update(spelerlvl2.Position, map2.Width, map2.Height);
                    }

                    if (spelerlvl2.HasSnowMan)
                        currentGameState = GameState.GameWin;

                    break;

                case GameState.GameLost:
                    IsMouseVisible = true;

                    if (again.isClicked)
                        currentGameState = GameState.Gamelevel1;

                    again.Update(mouse);

                    break;

                case GameState.GameWin:
                    IsMouseVisible = true;

                    if (home.isClicked == true)
                        currentGameState = GameState.GameMenu;

                    if (exit.isClicked == true)
                        Exit();

                    exit.Update(mouse);
                    home.Update(mouse);
                    break;
            }

            spelerlvl1.Update(gameTime);
            spelerlvl2.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            switch (currentGameState)
            {
                case GameState.GameMenu:

                    spriteBatch.Begin();

                    spriteBatch.Draw(backgroundlevel1, new Rectangle(0, 0, 800, 640), Color.White);
                    play.Draw(spriteBatch);
                    spriteBatch.DrawString(font, "MegaWoman", new Vector2((graphics.PreferredBackBufferWidth / 3) - 0, 50), Color.Black, 0, new Vector2(0, 0), 2f, SpriteEffects.None, 0);
                    spriteBatch.DrawString(font, "Play", new Vector2((graphics.PreferredBackBufferWidth / 2) - 25, 340), Color.White, 0, new Vector2(0, 0), 1f, SpriteEffects.None, 0);
                    
                    spriteBatch.End();
                    break;
                case GameState.Gamelevel1:
                    spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, camera.Transform);

                    spriteBatch.Draw(backgroundlevel1, new Rectangle(0, 0, 800, 640), Color.White);
                    spriteBatch.Draw(backgroundlevel1, new Rectangle(800, 0, 800, 640), Color.White);
                    spriteBatch.Draw(backgroundlevel1, new Rectangle(1600, 0, 800, 640), Color.White);
                    map.Draw(spriteBatch);
                    spelerlvl1.Draw(spriteBatch);

                    spriteBatch.End();

                    break;
                case GameState.Gamelevel2:
                    GraphicsDevice.Clear(Color.CornflowerBlue);

                    spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, camera.Transform);

                    spriteBatch.Draw(backgroundlevel1, new Rectangle(0, 0, 800, 640), Color.White);
                    spriteBatch.Draw(backgroundlevel1, new Rectangle(800, 0, 800, 640), Color.White);
                    spriteBatch.Draw(backgroundlevel1, new Rectangle(1600, 0, 800, 640), Color.White);
                    map2.Draw(spriteBatch);
                    spelerlvl2.Draw(spriteBatch);

                    spriteBatch.End();

                    break;
                case GameState.GameLost:
                    spriteBatch.Begin();

                    spriteBatch.Draw(backgroundend, new Rectangle(0, 0, 800, 640), Color.White);
                    spriteBatch.DrawString(font, "Game Over", new Vector2((graphics.PreferredBackBufferWidth / 3) - 0, 100), Color.White, 0, new Vector2(0, 0), 2f, SpriteEffects.None, 0);
                    again.Draw(spriteBatch);
                    spriteBatch.DrawString(font, "Play Again", new Vector2((graphics.PreferredBackBufferWidth / 2) - 65, 340), Color.White, 0, new Vector2(0, 0), 1f, SpriteEffects.None, 0);
                    
                    spriteBatch.End();
                    break;
                case GameState.GameWin:
                    spriteBatch.Begin();

                    spriteBatch.Draw(backgroundlevel1, new Rectangle(0, 0, 800, 640), Color.White);
                    spriteBatch.DrawString(font, "You won", new Vector2((graphics.PreferredBackBufferWidth / 3) - 0, 100), Color.White, 0, new Vector2(0, 0), 2f, SpriteEffects.None, 0);
                    home.Draw(spriteBatch);
                    exit.Draw(spriteBatch);
                    spriteBatch.DrawString(font, "Menu", new Vector2((graphics.PreferredBackBufferWidth / 2) - 35, 265), Color.White, 0, new Vector2(0, 0), 1f, SpriteEffects.None, 0);
                    spriteBatch.DrawString(font, "Exit", new Vector2((graphics.PreferredBackBufferWidth / 2) - 25, 415), Color.White, 0, new Vector2(0, 0), 1f, SpriteEffects.None, 0);

                    spriteBatch.End();
                    break;
            }

            base.Draw(gameTime);
        }
    }
}
