using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using _8_Bit_Alley___Bottle_Bash;
using Microsoft.Xna.Framework;

namespace _8_Bit_Alley___Bottle_Bash
{
    class ItemLauncher
    {
        Random r1 = new Random();
        public static int _currentWaveNum = 1;
        float _timer = 0;
        List<Wave> _waves = new List<Wave>();
        Wave _currentWave = null;
        public List<Shootable> _shootables;

        public ItemLauncher()
        {
            _currentWaveNum = 1;
            _shootables = new List<Shootable>();
            _waves.Add(new Wave(new List<WaveItem> { 
                       new WaveItem(1, 0f, new Microsoft.Xna.Framework.Vector2(2, -4)),
                       new WaveItem(2, 4f, new Microsoft.Xna.Framework.Vector2(3, -4)),
                       new WaveItem(3, 8f, new Microsoft.Xna.Framework.Vector2(2, -4)),
                       new WaveItem(4, 14f, new Microsoft.Xna.Framework.Vector2(3, -4)),
                       new WaveItem(5, 18f, new Microsoft.Xna.Framework.Vector2(2, -4)),
                       new WaveItem(1, 19f, new Microsoft.Xna.Framework.Vector2(3, -4)),
                       new WaveItem(1, 25f, new Microsoft.Xna.Framework.Vector2(3, -3))
                        }));
            _waves.Add(new Wave(new List<WaveItem> { 
                       new WaveItem(2, 0f, new Microsoft.Xna.Framework.Vector2(2, -3)),
                       new WaveItem(1, 4f, new Microsoft.Xna.Framework.Vector2(3, -4)),
                       new WaveItem(1, 8f, new Microsoft.Xna.Framework.Vector2(2, -3)),
                       new WaveItem(1, 14f, new Microsoft.Xna.Framework.Vector2(3, -4)),
                       new WaveItem(1, 18f, new Microsoft.Xna.Framework.Vector2(2, -4)),
                       new WaveItem(1, 19f, new Microsoft.Xna.Framework.Vector2(3, -2)),
                       new WaveItem(5, 25f, new Microsoft.Xna.Framework.Vector2(1, -3))
                        }));
            _waves.Add(new Wave(new List<WaveItem> { 
                       new WaveItem(2, 2f, new Microsoft.Xna.Framework.Vector2(2, -6)),
                       new WaveItem(1, 2f, new Microsoft.Xna.Framework.Vector2(3, -4)),
                       new WaveItem(2, 2f, new Microsoft.Xna.Framework.Vector2(4, -3)),
                       new WaveItem(2, 2f, new Microsoft.Xna.Framework.Vector2(5, -2)),
                       new WaveItem(3, 10f, new Microsoft.Xna.Framework.Vector2(3, -4)),
                       new WaveItem(5, 14f, new Microsoft.Xna.Framework.Vector2(1, -4)),
                       new WaveItem(2, 19f, new Microsoft.Xna.Framework.Vector2(3, -2)),
                       new WaveItem(1, 25f, new Microsoft.Xna.Framework.Vector2(3, -3))
                        }));
            _waves.Add(new Wave(new List<WaveItem> { 
                       new WaveItem(1, 3f, new Microsoft.Xna.Framework.Vector2(2, -6)),
                       new WaveItem(1, 4f, new Microsoft.Xna.Framework.Vector2(3, -4)),
                       new WaveItem(1, 5f, new Microsoft.Xna.Framework.Vector2(4, -3)),
                       new WaveItem(3, 10f, new Microsoft.Xna.Framework.Vector2(3, -4)),
                       new WaveItem(5, 14f, new Microsoft.Xna.Framework.Vector2(0.5f, -4)),
                       new WaveItem(2, 19f, new Microsoft.Xna.Framework.Vector2(3, -2)),
                       new WaveItem(1, 25f, new Microsoft.Xna.Framework.Vector2(3, -3))
                        }));
            _waves.Add(new Wave(new List<WaveItem> { 
                       new WaveItem(3, 0f, new Microsoft.Xna.Framework.Vector2(2, -3)),
                       new WaveItem(2, 4f, new Microsoft.Xna.Framework.Vector2(3, -4)),
                       new WaveItem(1, 8f, new Microsoft.Xna.Framework.Vector2(2, -3)),
                       new WaveItem(1, 14f, new Microsoft.Xna.Framework.Vector2(3, -4)),
                       new WaveItem(2, 18f, new Microsoft.Xna.Framework.Vector2(2, -4)),
                       new WaveItem(1, 19f, new Microsoft.Xna.Framework.Vector2(3, -2)),
                       new WaveItem(1, 25f, new Microsoft.Xna.Framework.Vector2(3, -3))
                        }));
            _waves.Add(new Wave(new List<WaveItem> { 
                       new WaveItem(2, 1f, new Microsoft.Xna.Framework.Vector2(2, -6)),
                       new WaveItem(1, 1f, new Microsoft.Xna.Framework.Vector2(3, -4)),
                       new WaveItem(2, 1f, new Microsoft.Xna.Framework.Vector2(4, -3)),
                       new WaveItem(1, 1f, new Microsoft.Xna.Framework.Vector2(5, -2)),
                       new WaveItem(2, 1.5f, new Microsoft.Xna.Framework.Vector2(3, -4)),
                       new WaveItem(1, 1.5f, new Microsoft.Xna.Framework.Vector2(2, -4)),
                       new WaveItem(2, 2f, new Microsoft.Xna.Framework.Vector2(3, -2)),
                       new WaveItem(1, 2f, new Microsoft.Xna.Framework.Vector2(3, -3))
                        }));
            _waves.Add(new Wave(new List<WaveItem> { 
                       new WaveItem(4, 3f, new Microsoft.Xna.Framework.Vector2(2, -6)),
                       new WaveItem(2, 4f, new Microsoft.Xna.Framework.Vector2(3, -4)),
                       new WaveItem(1, 8f, new Microsoft.Xna.Framework.Vector2(2, -3)),
                       new WaveItem(1, 14f, new Microsoft.Xna.Framework.Vector2(3, -4)),
                       new WaveItem(5, 18f, new Microsoft.Xna.Framework.Vector2(1, -4)),
                       new WaveItem(2, 19f, new Microsoft.Xna.Framework.Vector2(3, -2)),
                       new WaveItem(1, 25f, new Microsoft.Xna.Framework.Vector2(3, -3))
                        }));
            _waves.Add(new Wave(new List<WaveItem> { 
                       new WaveItem(1, 3f, new Microsoft.Xna.Framework.Vector2(2, -6)),
                       new WaveItem(1, 4f, new Microsoft.Xna.Framework.Vector2(3, -4)),
                       new WaveItem(1, 5f, new Microsoft.Xna.Framework.Vector2(4, -3)),
                       new WaveItem(3, 10f, new Microsoft.Xna.Framework.Vector2(3, -4)),
                       new WaveItem(5, 14f, new Microsoft.Xna.Framework.Vector2(1, -4)),
                       new WaveItem(2, 19f, new Microsoft.Xna.Framework.Vector2(3, -2)),
                       new WaveItem(1, 25f, new Microsoft.Xna.Framework.Vector2(3, -3))
                        }));
            _waves.Add(new Wave(new List<WaveItem> { 
                       new WaveItem(2, 2f, new Microsoft.Xna.Framework.Vector2(2, -6)),
                       new WaveItem(1, 2f, new Microsoft.Xna.Framework.Vector2(3, -4)),
                       new WaveItem(2, 2f, new Microsoft.Xna.Framework.Vector2(4, -3)),
                       new WaveItem(2, 2f, new Microsoft.Xna.Framework.Vector2(5, -2)),
                       new WaveItem(3, 10f, new Microsoft.Xna.Framework.Vector2(3, -4)),
                       new WaveItem(5, 14f, new Microsoft.Xna.Framework.Vector2(1, -4)),
                       new WaveItem(2, 19f, new Microsoft.Xna.Framework.Vector2(3, -2)),
                       new WaveItem(1, 25f, new Microsoft.Xna.Framework.Vector2(3, -3))
                        }));
            _waves.Add(new Wave(new List<WaveItem> { 
                       new WaveItem(1, 3f, new Microsoft.Xna.Framework.Vector2(2, -6)),
                       new WaveItem(1, 4f, new Microsoft.Xna.Framework.Vector2(3, -4)),
                       new WaveItem(1, 5f, new Microsoft.Xna.Framework.Vector2(4, -3)),
                       new WaveItem(3, 10f, new Microsoft.Xna.Framework.Vector2(3, -4)),
                       new WaveItem(5, 14f, new Microsoft.Xna.Framework.Vector2(1, -4)),
                       new WaveItem(2, 19f, new Microsoft.Xna.Framework.Vector2(3, -2)),
                       new WaveItem(1, 25f, new Microsoft.Xna.Framework.Vector2(3, -3))
                        }));
            _waves.Add(new Wave(new List<WaveItem> { 
                       new WaveItem(2, 1f, new Microsoft.Xna.Framework.Vector2(2, -6)),
                       new WaveItem(1, 1f, new Microsoft.Xna.Framework.Vector2(3, -4)),
                       new WaveItem(2, 1f, new Microsoft.Xna.Framework.Vector2(4, -3)),
                       new WaveItem(1, 1f, new Microsoft.Xna.Framework.Vector2(5, -2)),
                       new WaveItem(2, 1.5f, new Microsoft.Xna.Framework.Vector2(3, -4)),
                       new WaveItem(1, 1.5f, new Microsoft.Xna.Framework.Vector2(2, -4)),
                       new WaveItem(2, 2f, new Microsoft.Xna.Framework.Vector2(3, -2)),
                       new WaveItem(1, 2f, new Microsoft.Xna.Framework.Vector2(3, -3))
                        }));
            _waves.Add(new Wave(new List<WaveItem> { 
                       new WaveItem(2, 0f, new Microsoft.Xna.Framework.Vector2(2, -3)),
                       new WaveItem(4, 4f, new Microsoft.Xna.Framework.Vector2(3, -4)),
                       new WaveItem(1, 8f, new Microsoft.Xna.Framework.Vector2(2, -3)),
                       new WaveItem(1, 14f, new Microsoft.Xna.Framework.Vector2(3, -4)),
                       new WaveItem(1, 18f, new Microsoft.Xna.Framework.Vector2(2, -4)),
                       new WaveItem(1, 19f, new Microsoft.Xna.Framework.Vector2(3, -2)),
                       new WaveItem(5, 25f, new Microsoft.Xna.Framework.Vector2(1, -3))
                        }));
            _waves.Add(new Wave(new List<WaveItem> { 
                       new WaveItem(2, 2f, new Microsoft.Xna.Framework.Vector2(2, -6)),
                       new WaveItem(1, 2f, new Microsoft.Xna.Framework.Vector2(3, -4)),
                       new WaveItem(2, 2f, new Microsoft.Xna.Framework.Vector2(4, -3)),
                       new WaveItem(2, 2f, new Microsoft.Xna.Framework.Vector2(5, -2)),
                       new WaveItem(3, 10f, new Microsoft.Xna.Framework.Vector2(3, -4)),
                       new WaveItem(5, 14f, new Microsoft.Xna.Framework.Vector2(1, -4)),
                       new WaveItem(2, 19f, new Microsoft.Xna.Framework.Vector2(3, -2)),
                       new WaveItem(1, 25f, new Microsoft.Xna.Framework.Vector2(3, -3))
                        }));
            _waves.Add(new Wave(new List<WaveItem> { 
                       new WaveItem(3, 0f, new Microsoft.Xna.Framework.Vector2(2, -3)),
                       new WaveItem(2, 4f, new Microsoft.Xna.Framework.Vector2(3, -4)),
                       new WaveItem(1, 8f, new Microsoft.Xna.Framework.Vector2(2, -3)),
                       new WaveItem(1, 14f, new Microsoft.Xna.Framework.Vector2(3, -4)),
                       new WaveItem(2, 18f, new Microsoft.Xna.Framework.Vector2(2, -4)),
                       new WaveItem(5, 19f, new Microsoft.Xna.Framework.Vector2(1, -2)),
                       new WaveItem(1, 25f, new Microsoft.Xna.Framework.Vector2(3, -3))
                        }));
            _waves.Add(new Wave(new List<WaveItem> { 
                       new WaveItem(4, 3f, new Microsoft.Xna.Framework.Vector2(2, -6)),
                       new WaveItem(2, 4f, new Microsoft.Xna.Framework.Vector2(3, -4)),
                       new WaveItem(1, 8f, new Microsoft.Xna.Framework.Vector2(2, -3)),
                       new WaveItem(1, 14f, new Microsoft.Xna.Framework.Vector2(3, -4)),
                       new WaveItem(5, 18f, new Microsoft.Xna.Framework.Vector2(1, -4)),
                       new WaveItem(2, 19f, new Microsoft.Xna.Framework.Vector2(3, -2)),
                       new WaveItem(1, 25f, new Microsoft.Xna.Framework.Vector2(3, -3))
                        }));
            _waves.Add(new Wave(new List<WaveItem> { 
                       new WaveItem(1, 3f, new Microsoft.Xna.Framework.Vector2(2, -6)),
                       new WaveItem(1, 4f, new Microsoft.Xna.Framework.Vector2(3, -4)),
                       new WaveItem(1, 5f, new Microsoft.Xna.Framework.Vector2(4, -3)),
                       new WaveItem(3, 10f, new Microsoft.Xna.Framework.Vector2(3, -4)),
                       new WaveItem(5, 14f, new Microsoft.Xna.Framework.Vector2(1, -4)),
                       new WaveItem(2, 19f, new Microsoft.Xna.Framework.Vector2(3, -2)),
                       new WaveItem(1, 25f, new Microsoft.Xna.Framework.Vector2(3, -3))
                        }));
            _waves.Add(new Wave(new List<WaveItem> { 
                       new WaveItem(2, 2f, new Microsoft.Xna.Framework.Vector2(2, -6)),
                       new WaveItem(5, 2f, new Microsoft.Xna.Framework.Vector2(1, -4)),
                       new WaveItem(2, 2f, new Microsoft.Xna.Framework.Vector2(4, -3)),
                       new WaveItem(2, 2f, new Microsoft.Xna.Framework.Vector2(1, -2)),
                       new WaveItem(2, 2.5f, new Microsoft.Xna.Framework.Vector2(3, -4)),
                       new WaveItem(2, 2.5f, new Microsoft.Xna.Framework.Vector2(2, -4)),
                       new WaveItem(4, 3f, new Microsoft.Xna.Framework.Vector2(3, -2)),
                       new WaveItem(2, 3f, new Microsoft.Xna.Framework.Vector2(3, -3))
                        }));
            _waves.Add(new Wave(new List<WaveItem> { 
                       new WaveItem(2, 1f, new Microsoft.Xna.Framework.Vector2(2, -6)),
                       new WaveItem(1, 1f, new Microsoft.Xna.Framework.Vector2(3, -4)),
                       new WaveItem(2, 1f, new Microsoft.Xna.Framework.Vector2(4, -3)),
                       new WaveItem(1, 1f, new Microsoft.Xna.Framework.Vector2(5, -2)),
                       new WaveItem(2, 1.5f, new Microsoft.Xna.Framework.Vector2(3, -4)),
                       new WaveItem(1, 1.5f, new Microsoft.Xna.Framework.Vector2(2, -4)),
                       new WaveItem(2, 2f, new Microsoft.Xna.Framework.Vector2(3, -2)),
                       new WaveItem(1, 2f, new Microsoft.Xna.Framework.Vector2(3, -3))
                        }));
            _waves.Add(new Wave(new List<WaveItem> { 
                       new WaveItem(2, 1f, new Microsoft.Xna.Framework.Vector2(2, -6)),
                       new WaveItem(1, 1f, new Microsoft.Xna.Framework.Vector2(3, -4)),
                       new WaveItem(2, 1f, new Microsoft.Xna.Framework.Vector2(4, -3)),
                       new WaveItem(1, 1f, new Microsoft.Xna.Framework.Vector2(5, -2)),
                       new WaveItem(2, 1.5f, new Microsoft.Xna.Framework.Vector2(3, -4)),
                       new WaveItem(1, 1.5f, new Microsoft.Xna.Framework.Vector2(2, -4)),
                       new WaveItem(2, 2f, new Microsoft.Xna.Framework.Vector2(3, -2)),
                       new WaveItem(1, 2f, new Microsoft.Xna.Framework.Vector2(3, -3))
                        }));
            _waves.Add(new Wave(new List<WaveItem> { 
                       new WaveItem(2, 1f, new Microsoft.Xna.Framework.Vector2(2, -6)),
                       new WaveItem(1, 1f, new Microsoft.Xna.Framework.Vector2(3, -4)),
                       new WaveItem(2, 1f, new Microsoft.Xna.Framework.Vector2(4, -3)),
                       new WaveItem(1, 1f, new Microsoft.Xna.Framework.Vector2(5, -2)),
                       new WaveItem(2, 1.5f, new Microsoft.Xna.Framework.Vector2(3, -4)),
                       new WaveItem(1, 1.5f, new Microsoft.Xna.Framework.Vector2(2, -4)),
                       new WaveItem(2, 2f, new Microsoft.Xna.Framework.Vector2(3, -2)),
                       new WaveItem(1, 2f, new Microsoft.Xna.Framework.Vector2(3, -3))
                        }));
            _currentWave = _waves[0];
        }

        public void Update()
        {
            _timer += 0.016f;
            try
            {
                if ((int)(_currentWave._waveItems[0]._timeToComeIn) == (int)_timer)
                {
                    switch (_currentWave._waveItems[0]._itemType)
                    {
                        case 1:
                            _shootables.Add(new Bottle(_currentWave._waveItems[0]._velocity, new Vector2(-10, 300)));
                            break;

                        case 2:
                            _shootables.Add(new Egg(_currentWave._waveItems[0]._velocity, new Vector2(-10, 300)));
                            break;

                        case 3:
                            _shootables.Add(new Life(_currentWave._waveItems[0]._velocity, new Vector2(-10, 300)));
                            break;

                        case 4:
                            _shootables.Add(new spring(_currentWave._waveItems[0]._velocity, new Vector2(-10, 300)));
                            break;
                        case 5:
                            _shootables.Add(new TinCan(_currentWave._waveItems[0]._velocity, new Vector2(-10, 300)));
                            break;
                    }

                    _currentWave._waveItems.RemoveAt(0);

                }
                if (_currentWave._waveItems.Count == 0)
                {
                    _currentWaveNum++;
                    _currentWave = _waves[_currentWaveNum - 1];
                    _timer = 0;
                }
                Console.WriteLine((int)_timer);
            }
            catch (ArgumentOutOfRangeException e)
            {
                //say na'hin
            }
        }

       

        public void Draw(SpriteBatch _spriteBatch)
        {
            foreach (Shootable item in _shootables)
            {
                item.Draw(_spriteBatch);
            }
        }
    }
}
