using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.GamerServices;

namespace _8_Bit_Alley___Bottle_Bash
{
    class SceneManager
    {
        public enum Scenes
        {
            SPLASH,
            MENU,
            PLAYSTATE,
            CREDITS,
            SCORE,
            HOWTO,
            PAUSED,
            UNPAUSED,
            MUSIC,
        };
        public Scene _currentScene = null;
        private static SceneManager _me;
        private GraphicsDevice _graphicsDevice = null;
        private Preloader _preloader;

        public static SceneManager GetInstance()
        {
            if (_me == null)
            {
                _me = new SceneManager();
            }
            return _me;
        }


        public SceneManager()
        {

            _preloader = Preloader.GetInstance();
            
        }
        public void Update()
        {
            _currentScene.Update();
           
        }
        public void SetGraphicsDevice(GraphicsDevice _graphicsDevice)
        {
            this._graphicsDevice = _graphicsDevice;
            _me._graphicsDevice = _graphicsDevice;
            _currentScene = new Splash();
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _currentScene.Draw(_spriteBatch);
        }
        public void ChangeScene(Scenes _scene)
        {
            BottleBash._paused = false;
            switch (_scene)
            {
                case Scenes.SPLASH:

                    _currentScene = new Splash();
                   
                    break;
                case Scenes.MENU:

                    _currentScene = new Menu();

                    break;
                case Scenes.PLAYSTATE:

                    _currentScene = new BottleBash();

                    break;

                case Scenes.CREDITS:

                    _currentScene = new Credits();

                    break;

                case Scenes.HOWTO:

                    _currentScene = new TutorialScreen();

                    break;

                case Scenes.SCORE:
                    _currentScene = new WinScreen();
                    //();

                    break;
                case Scenes.PAUSED:
                    BottleBash._paused = true;

                    break;

                case Scenes.UNPAUSED:
                    BottleBash._paused = false;

                    break;

               
                case Scenes.MUSIC:

                    Menu _tempMenu = _currentScene as Menu;
                    _tempMenu.DisplayMusicRequest(true);

                    break;
            }
        }
    }
}
