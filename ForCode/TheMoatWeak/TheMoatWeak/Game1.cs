using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading;

namespace TheMoatWeak
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch spriteBatch;
        int screen = 0;
        bool start = false;
        bool cam = false;
        bool back = false;
        Texture2D camUi;
        Texture2D R1;
        Texture2D R2;
        Texture2D camSbh;
        Texture2D Menu;
        Texture2D camUnder;
        Vector2 pos = Vector2.Zero;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferHeight = 720; 
            _graphics.PreferredBackBufferWidth = 1200;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            camUi = Content.Load<Texture2D>("camera");
            R1 = Content.Load<Texture2D>("Room_1");
            R2 = Content.Load<Texture2D>("Room_2");
            camSbh = Content.Load<Texture2D>("SuanBuakHaad");
            Menu = Content.Load<Texture2D>("TMW");
            camUnder = Content.Load<Texture2D>("Underground");

        }
        private KeyboardState _keyboardState;

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            _keyboardState = Keyboard.GetState();

            if (_keyboardState.IsKeyDown(Keys.Back))
                start = false;
            if (_keyboardState.IsKeyDown(Keys.Enter))
            {
                start = true;
                screen = 0;
            }
            if (start == true)
            {
                if (_keyboardState.IsKeyDown(Keys.W))
                {
                    screen = 0;
                    back = false;
                }
                if (_keyboardState.IsKeyDown(Keys.S))
                {
                    screen = 1;
                    back = true;
                }

                if (back == true)
                {
                    if (_keyboardState.IsKeyDown(Keys.Up))
                    {
                        cam = true;
                    }
                    if (_keyboardState.IsKeyDown(Keys.Down))
                    {
                        cam = false;
                        screen = 1;
                    }
                }

                if (cam == true)
                {
                    if (_keyboardState.IsKeyDown(Keys.NumPad1))
                    {
                        screen = 2;
                    }
                    if (_keyboardState.IsKeyDown(Keys.NumPad2))
                    {
                        screen = 3;
                    }
                    //if (_keyboardState.IsKeyDown(Keys.NumPad3))
                    //{
                    //    screen = 4;
                    //}
                    //if (_keyboardState.IsKeyDown(Keys.NumPad4))
                    //{
                    //    screen = 5;
                    //}
                    //if (_keyboardState.IsKeyDown(Keys.NumPad5))
                    //{
                    //    screen = 6;
                    //}
                    //if (_keyboardState.IsKeyDown(Keys.NumPad6))
                    //{
                    //    screen = 7;
                    //}
                    //if (_keyboardState.IsKeyDown(Keys.NumPad7))
                    //{
                    //    screen = 8;
                    //}
                    //if (_keyboardState.IsKeyDown(Keys.NumPad8))
                    //{
                    //    screen = 9;
                    //}
                }
            }
            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice device = _graphics.GraphicsDevice;

            spriteBatch.Begin();

            if (start == false)
            {
                screen = 99;
                spriteBatch.Draw(Menu, pos, Color.White);
            }

            if (screen == 0)
            {
                spriteBatch.Draw(R1, pos, Color.White);
            }
            if (screen == 1)
            {
                spriteBatch.Draw(R2, pos, Color.White);
            }
            if (screen == 2)
            {
               spriteBatch.Draw(camSbh, pos, Color.White);
               spriteBatch.Draw(camUi, pos, Color.White);
            }
            if (screen == 3)
            {
                spriteBatch.Draw(camUnder, pos, Color.White);
                spriteBatch.Draw(camUi, pos, Color.White);
            }
            //if (screen == 4)
            //{
            //    GraphicsDevice.Clear(Color.Pink);
            //}
            //if (screen == 5)
            //{
            //    GraphicsDevice.Clear(Color.Blue);
            //}
            //if (screen == 6)
            //{
            //    GraphicsDevice.Clear(Color.Purple);
            //}
            //if (screen == 7)
            //{
            //    GraphicsDevice.Clear(Color.Orange);
            //}
            //if (screen == 8)
            //{
            //    GraphicsDevice.Clear(Color.Gray);
            //}
            //if (screen == 9)
            //{
            //    GraphicsDevice.Clear(Color.SandyBrown);

            //    spriteBatch.Begin();

            //    //spriteBatch.Draw(myTexture, spritePosition, Color.White);

            //    spriteBatch.End();

            //}
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}