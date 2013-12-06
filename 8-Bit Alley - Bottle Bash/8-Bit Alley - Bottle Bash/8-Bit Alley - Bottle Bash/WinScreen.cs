using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace _8_Bit_Alley___Bottle_Bash
{
    class WinScreen : Scene
    {
        SceneManager _sceneManager;
       
      //  private Texture2D _cursor;
        private Texture2D _scenery;
        Preloader _preloader;
        List<Button> _buttons = new List<Button>();
        
        
        public WinScreen()
        {
            _preloader = Preloader.GetInstance();
            _sceneManager = SceneManager.GetInstance();
          //  _cursor = _preloader.Load("cursor");
            _scenery = _preloader.Load("scene");
            _buttons.Add(new Button(new Vector2(150, 400), SceneManager.Scenes.MENU, "Back",true));
           
            
        }

        public override void Update()
        {

           
            foreach (Button item in _buttons)
            {
                item.Update();
            }
            
        }
       
        public override void Draw(SpriteBatch _spriteBatch)
        {
           
         //   _spriteBatch.Draw(_cursor, new Vector2(Mouse.GetState().X, Mouse.GetState().Y), null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
             _spriteBatch.DrawString(_preloader._spriteFont, "YAY!!! , you got a score of :  "+ (int) BottleBash._score + "\n and made it to wave : "  , new Vector2(0, 100), Color.Black);
            foreach (Button item in _buttons)
            {
                 item.Draw(_spriteBatch);
            }
        }
    }
}
