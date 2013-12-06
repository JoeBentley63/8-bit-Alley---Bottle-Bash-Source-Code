using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace _8_Bit_Alley___Bottle_Bash
{
    class WaveItem
    {
        public int _itemType;
        public float _timeToComeIn;
        public Vector2 _velocity;

        public WaveItem(int _itemType, float _timeToComeIn, Vector2 _velocity)
        {
            this._itemType = _itemType;
            this._timeToComeIn = _timeToComeIn;
            this._velocity = _velocity;
        }
    }
}
