using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.GamerServices;


namespace _8_Bit_Alley___Bottle_Bash
{
    class Menu : Scene
    {
        SceneManager _sceneManager ;
        public static String _song = "song1";
     
        //private Texture2D _cursor;
        private Texture2D _scenery;
        private Texture2D _title;
        private Vector2 _titlePos = new Vector2(20, 200);
        Preloader _preloader;
        List<Button> _buttons = new List<Button>();
        string _highScores;
        public static bool _once = false;
        public Menu()
        {
            if (_once == false)
            {
                _once = true;
                DisplayMusicRequest(true);
            }
           
            _preloader = Preloader.GetInstance();
            _sceneManager = SceneManager.GetInstance();
           // _cursor = _preloader.Load("cursor");
            _scenery = _preloader.Load("scene");
            _title = _preloader.Load("title");
            _buttons.Add(new Button(new Vector2(550, 100), SceneManager.Scenes.PLAYSTATE, "Play", true));
            _buttons.Add(new Button(new Vector2(550, 200), SceneManager.Scenes.CREDITS, "Credits", true));
            _buttons.Add(new Button(new Vector2(550, 300), SceneManager.Scenes.HOWTO, "How To", true));
      
        }

        public override void Update()
        {

            foreach (Button item in _buttons)
            {
                item.Update();
            }

        }
        
        public void DisplayMusicRequest(bool _ingame)
        {
            Guide.BeginShowMessageBox("SOUND","Would you like to play with sound?", new List<string> { "Yes!!", "NO!!" }, 0, MessageBoxIcon.None,
            asyncResult =>
            {
                int? returned = Guide.EndShowMessageBox(asyncResult);
                if (returned == 0)
                {
                    Preloader._MusicAllowed = true;
                    
                }
                else
                {
                    if (_ingame)
                    {
                        _preloader.StopMusic();
                    }
                    Preloader._MusicAllowed = false;
                }
            }, null);
        }

        public override void Draw(SpriteBatch _spriteBatch)
        {
           
            //_spriteBatch.Draw(_cursor, new Vector2(Mouse.GetState().X, Mouse.GetState().Y), null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            //_spriteBatch.Draw(_scenery,  new Vector2(-10,0), null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 1f);
            _spriteBatch.Draw(_title,_titlePos, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
           // _spriteBatch.DrawString(_preloader._spriteFont, _highScores, new Vector2(0, 300), Color.Black);
            _spriteBatch.DrawString(_preloader._spriteFont, "Current Music : " + _song, new Vector2(20, 640), Color.Black);
            _spriteBatch.DrawString(_preloader._spriteFont, "Music by Isak Martinsson", new Vector2(20, 720), Color.Black);
          
            foreach (Button item in _buttons)
            {
                item.Draw(_spriteBatch);
            }
        }
    }
}
