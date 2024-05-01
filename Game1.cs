using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Reflection.Metadata;

namespace Monogame_3___Animation
{
    enum Screen
    {
        Intro, MainAnimation
    }
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D tribbleBrownTexture, tribbleCreamTexture, tribbleGreyTexture, tribbleOrangeTexture, introTexture;
        Rectangle tribbleBrownRectangle, tribbleCreamRectangle, tribbleGreyRectangle, tribbleOrangeRectangle;
        Rectangle window;
        Vector2 tribbleBrownSpeed, tribbleCreamSpeed, tribbleGreySpeed, tribbleOrangeSpeed;
        MouseState mouseState;
        Screen screen;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            screen = Screen.Intro;
            window = new Rectangle(0, 0, 800, 600);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            tribbleBrownRectangle = new Rectangle(10, 10, 150, 150);
            tribbleCreamRectangle = new Rectangle(10, 10, 100, 100);
            tribbleGreyRectangle = new Rectangle(100, 30, 75, 75);
            tribbleOrangeRectangle = new Rectangle(40, 400, 100, 100);
            tribbleBrownSpeed = new Vector2(5,2);
            tribbleCreamSpeed = new Vector2(10,1);
            tribbleGreySpeed = new Vector2(9,1);
            tribbleOrangeSpeed = new Vector2(2,10);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            tribbleBrownTexture = Content.Load<Texture2D>("tribbleBrown");
            tribbleCreamTexture = Content.Load<Texture2D>("tribbleCream");
            tribbleGreyTexture = Content.Load<Texture2D>("tribbleGrey");
            tribbleOrangeTexture = Content.Load<Texture2D>("tribbleOrange");
            introTexture = Content.Load<Texture2D>("Intro");
        }

        protected override void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            if (screen == Screen.Intro)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    screen = Screen.MainAnimation;
                }
            }

            if (screen == Screen.MainAnimation)
            {
                tribbleBrownRectangle.X += (int)tribbleBrownSpeed.X;
                tribbleCreamRectangle.X += (int)tribbleCreamSpeed.X;
                tribbleGreyRectangle.X += (int)tribbleGreySpeed.X;
                tribbleOrangeRectangle.X += (int)tribbleOrangeSpeed.X;
                if (tribbleBrownRectangle.Right >= window.Width || tribbleBrownRectangle.Left <= 0)
                {
                    tribbleBrownSpeed.X *= -1;
                }
                tribbleBrownRectangle.Y += (int)tribbleBrownSpeed.Y;
                tribbleCreamRectangle.Y += (int)tribbleCreamSpeed.Y;
                tribbleGreyRectangle.Y += (int)tribbleGreySpeed.Y;
                tribbleOrangeRectangle.Y += (int)tribbleOrangeSpeed.Y;
                if (tribbleBrownRectangle.Bottom >= window.Height || tribbleBrownRectangle.Top <= 0)
                {
                    tribbleBrownSpeed.Y *= -1;
                }


                if (tribbleCreamRectangle.Right >= window.Width || tribbleCreamRectangle.Left <= 0)
                {
                    tribbleCreamSpeed.X *= -1;
                }
                if (tribbleCreamRectangle.Bottom >= window.Height || tribbleCreamRectangle.Top <= 0)
                {
                    tribbleCreamSpeed.Y *= -1;
                }


                if (tribbleGreyRectangle.Right >= window.Width || tribbleGreyRectangle.Left <= 0)
                {
                    tribbleGreySpeed.X *= -1;
                }

                if (tribbleGreyRectangle.Bottom >= window.Height || tribbleGreyRectangle.Top <= 0)
                {
                    tribbleGreySpeed.Y *= -1;
                }


                if (tribbleOrangeRectangle.Right >= window.Width || tribbleOrangeRectangle.Left <= 0)
                {
                    tribbleOrangeSpeed.X *= -1;
                }

                if (tribbleOrangeRectangle.Bottom >= window.Height || tribbleOrangeRectangle.Top <= 0)
                {
                    tribbleOrangeSpeed.Y *= -1;
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LemonChiffon);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            if (screen == Screen.Intro)
            {
                _spriteBatch.Draw(introTexture, window, Color.White);
            }

            else if (screen == Screen.MainAnimation)
            {
                _spriteBatch.Draw(tribbleBrownTexture, tribbleBrownRectangle, Color.White);
                _spriteBatch.Draw(tribbleCreamTexture, tribbleCreamRectangle, Color.White);
                _spriteBatch.Draw(tribbleGreyTexture, tribbleGreyRectangle, Color.White);
                _spriteBatch.Draw(tribbleOrangeTexture, tribbleOrangeRectangle, Color.White);
            }
            _spriteBatch.End();

            base.Draw(gameTime);
            
        }
    }
}