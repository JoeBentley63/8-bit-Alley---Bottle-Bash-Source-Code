using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace _8_Bit_Alley___Bottle_Bash
{
    class TargetShooting
    {
        
        Random _random;
        Preloader _preloader;
        Texture2D _backwall;
        public TargetShooting()
        {
            _random = new Random();
            _preloader = Preloader.GetInstance();
            _backwall = _preloader.Load("targetWall");
        }

        public void Update()
        {
           

        }
        public void Draw(SpriteBatch _spriteBatch)
        {
         
            //_spriteBatch.Draw(_aim, new Rectangle((int)Mouse.GetState().X, (int)Mouse.GetState().Y, _aim.Width, _aim.Height), null, Color.White, 0f, new Vector2(_aim.Width / 2, _aim.Height / 2), SpriteEffects.None, 0.1f);
            //_spriteBatch.Draw(_backwall, Vector2.Zero, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 1f);

        }
    }
}
