using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _8_Bit_Alley___Bottle_Bash
{
    class Shootable
    {
        protected Preloader _preloader = Preloader.GetInstance();
        protected Texture2D _texture;
        public Vector2 _pos;
        public Vector2 _velocity = Vector2.Zero;
        protected float _rotation = 0f;
        public Rectangle _boundingBox
        {
            get
            {
                return new Rectangle((int)_pos.X - (_texture.Width / 2), (int)_pos.Y - (_texture.Height / 2), _texture.Width, _texture.Height);
            }
        }

        public virtual void Update()
        {
            _pos += _velocity;
            if (_velocity.X > 0)
            {
               // _velocity.X -= .05f;
            }
            if (_velocity.X < 0)
            {
               // _velocity.X += .05f;
            }
            _velocity.Y += 0.05f;
        }
        public virtual void Draw(SpriteBatch _spriteBatch)
        {
            _rotation += _velocity.Length()/25;
            _spriteBatch.Draw(_texture, new Rectangle((int)_pos.X, (int)_pos.Y, _texture.Width, _texture.Height), null, Color.White,_rotation, new Vector2(_texture.Width / 2, _texture.Height / 2), SpriteEffects.None, 0.2f);
        }
    }
}
