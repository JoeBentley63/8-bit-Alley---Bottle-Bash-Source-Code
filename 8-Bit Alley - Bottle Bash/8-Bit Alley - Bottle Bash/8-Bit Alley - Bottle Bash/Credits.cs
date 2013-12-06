using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;
using Microsoft.Xna.Framework;

namespace _8_Bit_Alley___Bottle_Bash
{
    class Credits : Scene
    {
        SceneManager _sceneManager;
        
        private Texture2D _cursor;
        private Texture2D _scenery;
        Preloader _preloader;
        List<Button> _buttons = new List<Button>();
        public Credits()
        {
            _preloader = Preloader.GetInstance();
            _sceneManager = SceneManager.GetInstance();
            _cursor = _preloader.Load("cursor");
            _scenery = _preloader.Load("scene");


            _buttons.Add(new Button(new Vector2(500, 300), SceneManager.Scenes.MENU, "Back", true));
        }

        public override void Update()
        {
           
          
            CollisionDetection();
           
            foreach (Button item in _buttons)
            {
                item.Update();
            }

        }
        public void CollisionDetection()
        {
           
        }
        public override void Draw(SpriteBatch _spriteBatch)
        {
           
            _spriteBatch.DrawString(_preloader._spriteFont, " Art and Code by Joseph Bentley(SeppyB63) \n Follow me on Twitter @seppyb \n or find me on Newgrounds, Username : SeppyB63 \n\n Don't be shy, say hey!!", new Vector2(100, 100), Color.Black);
            foreach (Button item in _buttons)
            {
                item.Draw(_spriteBatch);
            }
        }
    }
}
