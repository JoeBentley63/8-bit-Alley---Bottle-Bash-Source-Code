using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Collections;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;


namespace _8_Bit_Alley___Bottle_Bash //might want to change this, depending on your own projects namespace
{
    public class Preloader
    {
        public Random r1 = new Random();
        public static bool _MusicAllowed = false;
        private static Preloader _me; //make it a singleton so we only load our Texture2D's the once.
        public SpriteFont _spriteFont;
        Dictionary<String, Texture2D> _sprites = new Dictionary<String, Texture2D>(); //Dictionary to store our Texture2D's
        Dictionary<String, SoundEffect> _sounds = new Dictionary<String, SoundEffect>(); //Dictionary to store our Texture2D's
        Dictionary<String, Song> _songs = new Dictionary<String, Song>(); //Dictionary to store our Texture2D's
        SoundEffectInstance instance;
        SoundEffect bgEffect;
        private Preloader()
        {
            
        }
        public void setContentManager(ContentManager _content)
        {
            LoadAll(_content);//on creation, load our assets
        }
        public static Preloader GetInstance()// singleton
        {
            if (_me == null)
            {
                _me = new Preloader();
            }
            return _me;
        }


        private void LoadAll(ContentManager _content)
        {
            _sprites.Add("wall", _content.Load<Texture2D>("Wall"));
            _sprites.Add("targetwall", _content.Load<Texture2D>("TargetFrame"));
            _sprites.Add("bottle", _content.Load<Texture2D>("bottle"));
            _sprites.Add("tincan", _content.Load<Texture2D>("tinCan"));
            _sprites.Add("aim", _content.Load<Texture2D>("Aim"));
            _sprites.Add("bullethole", _content.Load<Texture2D>("BulletHole"));
            _sprites.Add("overlay", _content.Load<Texture2D>("Overlay"));
            _sprites.Add("emptyheart", _content.Load<Texture2D>("EmptyHeart"));
            _sprites.Add("filledheart", _content.Load<Texture2D>("Heart"));

            _sprites.Add("egg", _content.Load<Texture2D>("Egg"));
            _sprites.Add("eggoverlay", _content.Load<Texture2D>("EggedOverlay"));

            _sprites.Add("spring", _content.Load<Texture2D>("spring"));
            _sprites.Add("springoverlay", _content.Load<Texture2D>("SpringOverlay"));
            
            _sprites.Add("notch", _content.Load<Texture2D>("notch"));


            _sprites.Add("title", _content.Load<Texture2D>("Title"));

            _sprites.Add("button", _content.Load<Texture2D>("Button"));
            _sprites.Add("smallbutton", _content.Load<Texture2D>("SmallButton"));
            _sprites.Add("page1", _content.Load<Texture2D>("TutorialPage1Colours"));
            _sprites.Add("splash", _content.Load<Texture2D>("Splash"));

            _sounds.Add("clink", _content.Load<SoundEffect>("GlassClink"));
            _sounds.Add("smash", _content.Load<SoundEffect>("GlassBreak"));
            _sounds.Add("egg", _content.Load<SoundEffect>("EggNoise"));
            _sounds.Add("boing", _content.Load<SoundEffect>("Boing"));
            _sounds.Add("clank", _content.Load<SoundEffect>("CanClink"));
            _sounds.Add("win", _content.Load<SoundEffect>("Win"));

            _spriteFont = _content.Load<SpriteFont>("Font");
        }
        public SoundEffect LoadEffect(String _string)
        {
            _string = _string.ToLower();
            SoundEffect _sound;
            _sounds.TryGetValue(_string, out _sound);//get the sprite from the dictionary and return it.
            return _sound;
        }
        public void PlayEffect(String _string)
        {
            if (_MusicAllowed)
            {
                if (instance != null)
                {
                    instance.Dispose();
                }

                _sounds.TryGetValue(_string, out bgEffect);
                bgEffect.Play();
            }

        }
        public void StopMusic()
        {
            if (_MusicAllowed)
            {
                if (instance != null)
                {
                    instance.Dispose();
                }
            }
        }
        public void PlayMusic(String _string)
        {
            if (_MusicAllowed)
            {
                if (instance != null)
                {
                    instance.Dispose();
                }

                _sounds.TryGetValue(_string, out bgEffect);
                instance = bgEffect.CreateInstance();
                instance.IsLooped = true;
                instance.Volume = 0.5f;
                instance.Play();
            }
        }
        public Texture2D Load(String _string)//function that lets you refrence your sprites in a class after they have been loaded
        {
            _string = _string.ToLower();
            Texture2D _tex;
            _sprites.TryGetValue(_string, out _tex);//get the sprite from the dictionary and return it.
            return _tex;
        }
    }
}

