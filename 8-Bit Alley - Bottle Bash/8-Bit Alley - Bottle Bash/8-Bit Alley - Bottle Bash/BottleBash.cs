using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;


namespace _8_Bit_Alley___Bottle_Bash
{
    class BottleBash : Scene
    {
        public static bool _paused = false;
        Random _random;
        Preloader _preloader;
        Texture2D _aim;
        int _lives = 3;
        Texture2D _filledHeart;
        Texture2D _emptyHeart;
        Texture2D _notch;
        Texture2D _eggedOverlay;
        Texture2D _springOverlay;
        public static int _score = 0;
        bool _clicked = false;
        string[] _prizes;
        
        bool _egged = false;
        float _eggTimer = 5f;
        bool _springy = false;
        float _springTimer = 15f;
        float _chanceOfItemBeingThrown = 400f;
        ItemLauncher _launcher;
        SceneManager _sceneManager;
        public BottleBash()
        {
            _score = 0;
            _random = new Random();
            _preloader = Preloader.GetInstance();
            _launcher = new ItemLauncher();
            _aim = _preloader.Load("aim");
            _filledHeart = _preloader.Load("filledheart");
            _emptyHeart = _preloader.Load("emptyheart");
            _notch = _preloader.Load("notch");
            _eggedOverlay = _preloader.Load("EggOverlay");
            _springOverlay = _preloader.Load("springOverlay");
            _score = 0;
            _lives = 3;
            _prizes = new string[3];
            _prizes[0] = "1,000";
            _prizes[1] = "100";
            _prizes[2] = "10,000";
            _sceneManager = SceneManager.GetInstance();
        }

        public override void Update()
        {
            if (_lives <= 0)
            {
                _sceneManager.ChangeScene(SceneManager.Scenes.SCORE);
            }
            if (ItemLauncher._currentWaveNum > 20)
            {
                _sceneManager.ChangeScene(SceneManager.Scenes.SCORE);
            }
            if (_paused == false)
            {
                _launcher.Update();
                if (_egged)
                {
                    _eggTimer -= 0.02f;
                    if (_eggTimer < 0)
                    {
                        _egged = false;
                    }
                }
                if (_springy)
                {
                    _springTimer -= 0.02f;
                    if (_springTimer < 0)
                    {
                        _springy = false;
                    }

                }
                _chanceOfItemBeingThrown -= 0.01f;
                Console.WriteLine("Chance : " + _chanceOfItemBeingThrown);

                for (int i = 0; i < _launcher._shootables.Count; i++)
                {
                    _launcher._shootables[i].Update();
                    if (_springy)
                    {
                        if (_launcher._shootables[i]._pos.Y > 360)
                        {
                            if (_launcher._shootables[i]._velocity.Y > 0)
                            {
                                _launcher._shootables[i]._velocity.Y *= -1;
                                _preloader.PlayEffect("boing");
                            }
                        }
                    }
                    if (Mouse.GetState().LeftButton == ButtonState.Pressed && _launcher._shootables[i]._boundingBox.Contains(new Point(Mouse.GetState().X, Mouse.GetState().Y)) && _clicked == false)
                    {
                        _launcher._shootables[i]._velocity.Y = -3;

                        _clicked = true;
                        if (_launcher._shootables[i] is spring)
                        {

                            _preloader.PlayEffect("boing");
                        }
                        else if (_launcher._shootables[i] is Egg)
                        {
                            _preloader.PlayEffect("egg");
                            _egged = true;
                            _eggTimer = 5;
                            _launcher._shootables.RemoveAt(i);
                        }
                        else if (_launcher._shootables[i] is TinCan)
                        {
                            _preloader.PlayEffect("clank");

                        }
                        else
                        {
                            _preloader.PlayEffect("clink");
                        }

                    }
                    if (Mouse.GetState().LeftButton == ButtonState.Released && _clicked == true)
                    {
                        _clicked = false;
                    }
                    try
                    {
                        if (_launcher._shootables[i]._pos.X > 800 && _launcher._shootables[i]._pos.Y < 480)
                        {

                            if (_launcher._shootables[i]._pos.Y < 160 && _launcher._shootables[i]._pos.Y > 0)
                            {
                                _preloader.PlayEffect("win");
                                if (_launcher._shootables[i] is TinCan)
                                {
                                    _score += 2000;
                                }
                                else
                                {
                                    _score += 1000;
                                }
                            }
                            else if (_launcher._shootables[i]._pos.Y >= 160 && _launcher._shootables[i]._pos.Y < 320)
                            {
                                _preloader.PlayEffect("win");
                                if (_launcher._shootables[i] is TinCan)
                                {
                                    _score += 100;
                                }
                                else
                                {
                                    _score += 200;
                                }
                            }
                            else if (_launcher._shootables[i]._pos.Y > 320 && _launcher._shootables[i]._pos.Y < 400)
                            {
                                _preloader.PlayEffect("win");
                                if (_launcher._shootables[i] is TinCan)
                                {
                                    _score += 20000;
                                }
                                else
                                {
                                    _score += 10000;
                                }
                            }
                            else
                            {
                                _lives--;
                                _preloader.PlayEffect("smash");
                            }

                            if (_launcher._shootables[i] is spring)
                            {
                                _springy = true;
                                _springTimer = 15;
                            }
                            if (_launcher._shootables[i] is Life)
                            {
                                _lives++;
                                if (_lives > 5)
                                {
                                    _lives = 5;
                                }
                            }

                            _launcher._shootables.RemoveAt(i);
                        }
                    }
                    catch (ArgumentOutOfRangeException e)
                    {
                    }
                    try
                    {
                        if (_launcher._shootables[i]._pos.Y > 500)
                        {
                            if (_launcher._shootables[i] is Bottle || _launcher._shootables[i] is TinCan)
                            {
                                _lives--;
                                _preloader.PlayEffect("smash");
                            }
                            _launcher._shootables.RemoveAt(i);

                        }
                    }
                    catch (ArgumentOutOfRangeException e)
                    {

                    }

                }
            }
        }
        public override void Draw(SpriteBatch _spriteBatch)
        {
            _launcher.Draw(_spriteBatch);
            for (int i = 0; i < 3; i++)
            {
                _spriteBatch.Draw(_emptyHeart, new Rectangle(20 + (i * 66), 20, _filledHeart.Width, _filledHeart.Height), null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.1f);
              
            }
            for (int i = 0; i < _lives; i++)
            {
               
                _spriteBatch.Draw(_filledHeart, new Rectangle(20 + (i * 66), 20, _filledHeart.Width, _filledHeart.Height), null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0f);
                
            }
            if (_egged)
            {
                _spriteBatch.Draw(_eggedOverlay, Vector2.Zero, null, Color.White * (_eggTimer/5), 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.1f);
            }
            if (_springy)
            {
                _spriteBatch.Draw(_springOverlay, Vector2.Zero, null, Color.White * (_springTimer / 5), 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.1f);
            }
            _spriteBatch.DrawString(_preloader._spriteFont, "" + _prizes[0], new Vector2(710, 80), Color.Black);
        
            _spriteBatch.Draw(_notch, new Rectangle(770, 160, _notch.Width, _notch.Height), null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, .5f);
            _spriteBatch.DrawString(_preloader._spriteFont, "" + _prizes[1], new Vector2(710, 240), Color.Black);
        
            _spriteBatch.Draw(_notch, new Rectangle(770, 320, _notch.Width, _notch.Height), null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, .5f);
            _spriteBatch.DrawString(_preloader._spriteFont, "" + _prizes[2], new Vector2(710, 340), Color.Black);
        
            //_spriteBatch.Draw(_aim, new Rectangle((int)Mouse.GetState().X, (int)Mouse.GetState().Y, _aim.Width, _aim.Height), null, Color.White, 0f, new Vector2(_aim.Width / 2, _aim.Height / 2), SpriteEffects.None, 0.1f);
            _spriteBatch.DrawString(_preloader._spriteFont, "Level : " + _score + "\nWave : " + ItemLauncher._currentWaveNum, new Vector2(20, 410), Color.White);
        }
    }
}
