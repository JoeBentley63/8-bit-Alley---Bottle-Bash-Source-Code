using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace _8_Bit_Alley___Bottle_Bash
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D _overLay;
        Preloader _preloader;
        SceneManager _sceneManager;
        bool _clicked = false;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 480;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            _preloader = Preloader.GetInstance();
            _preloader.setContentManager(Content);
            _sceneManager = SceneManager.GetInstance();
            _sceneManager.SetGraphicsDevice(GraphicsDevice);
            
            _overLay = _preloader.Load("overlay");
            // TODO: use this.Content to load your game content here

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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

            _sceneManager.Update();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            {
                if (_sceneManager._currentScene is Menu)
                {
                    BottleBash._paused = true;

                    Guide.BeginShowMessageBox("App Quit", "Do you want to quit this app?", new List<string> { "Yep!", "NO!!" }, 0, MessageBoxIcon.None,
                 asyncResult =>
                 {
                     int? returned = Guide.EndShowMessageBox(asyncResult);
                     if (returned == 0)
                     {
                         quit();
                     }
                     else
                     {
                         BottleBash._paused = false;
                     }
                 }, null);
                }
                else
                {
                    
                        BottleBash._paused = true;
                        Guide.BeginShowMessageBox("Main Menu", "Do you want to quit to Menu?", new List<string> { "Yep!", "NO!!" }, 0, MessageBoxIcon.None,
                     asyncResult =>
                     {
                         int? returned = Guide.EndShowMessageBox(asyncResult);
                         if (returned == 0)
                         {
                             _sceneManager.ChangeScene(SceneManager.Scenes.MENU);
                         }
                         else
                         {
                             BottleBash._paused = false;
                         }
                     }, null);
                    
                }
            }
           


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        /// 
        public void quit()
        {
            Exit();
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(39, 00, 106));
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
           // spriteBatch.Draw(_backwall, Vector2.Zero, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 1f);
            
            spriteBatch.Draw(_overLay, Vector2.Zero - new Vector2(2,2), null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.1f);

            _sceneManager.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
