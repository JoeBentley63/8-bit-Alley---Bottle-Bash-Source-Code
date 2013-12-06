using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace _8_Bit_Alley___Bottle_Bash
{
    class Egg : Shootable
    {
        public Egg(Vector2 _velocity, Vector2 _pos)
        {
            this._velocity = _velocity;
            this._texture = _preloader.Load("egg");
            this._pos = _pos;
        }

    }
}
