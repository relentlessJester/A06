using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GME1003_A06_Viktor
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //dog
        private Texture2D _tailDown;
        private Texture2D _tailUp;

        //bone
        private Texture2D _bone;

        private float _boneX;
        private float _boneY;
        private float _boneScale;

        //star effects
        private Texture2D _stars;

        //background
#pragma warning disable CS0169 // The field 'Game1._backgroundTime' is never used
        private Texture2D _backgroundTime;
#pragma warning restore CS0169 // The field 'Game1._backgroundTime' is never used

        //list of x-cord
        private List<int> _starX;

        //list of y-cord
        private List<int> _starY;

        // star colors
        private List<Color> _starColors;

        //star size
        private List<float> _starSize;

        //star rotation
        private List<float> _starRotation;

        //rng
        private Random _rng;
        private int _starRecount;

        //number of stars spawned when move mouse (0-1)
        private int _numStars;

        //does mouse move
        private int _moveX, _moveY;

        //mouse state
        private bool _shmoovin = false;
#pragma warning disable CS0414 // The field 'Game1._starTime' is assigned but its value is never used
        private bool _starTime = false;
#pragma warning restore CS0414 // The field 'Game1._starTime' is assigned but its value is never used

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;


        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _rng = new Random(); //random
            _numStars = _rng.Next(1, 2); //1-2 star each time mouse moves

            _starX = new List<int>(); //star x
            _starY = new List<int>(); //star y

            _starColors = new List<Color>(); //colours

            _starSize = new List<float>(); //size
            _starRotation = new List<float>(); //rotation

            _shmoovin = false;

            _boneX = 600;
            _boneY = 200;

            _boneScale = 0.25f;

            while (_shmoovin == true) ;
            {
                for (int i = 0; i <= _numStars; i++)
                {
                    _starRecount++;
                }

            }

            if (_starRecount == _numStars)
            {
                _numStars = _rng.Next(1, 2);
            }


            //x list
            for (int i = 0; i < _numStars; i++)
            {
                _starX.Add(_rng.Next(0, 801));
            }

            //y list
            for (int i = 0; i < _numStars; ++i)
            {
                _starY.Add(_rng.Next(0, 481));
            }

            //colours list 
            for (int i = 0; i < _numStars; i++)
            {
                _starColors.Add(new Color(128 + _rng.Next(0, 129), 128 + _rng.Next(0, 129), 128 + _rng.Next(0, 129)));
            }

            //size list
            for (int i = 0; i < _numStars; i++)
            {
                _starSize.Add(_rng.Next(5, 20));
            }

            //rotation list
            for (int i = 0; i < _numStars; i++)
            {
                _starRotation.Add(_rng.Next(0, 101) / 100f);
            }


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //load dog "animations"
            _tailUp = Content.Load<Texture2D>("dog2");
            _tailDown = Content.Load<Texture2D>("dog01");

            //load star
            _stars = Content.Load<Texture2D>("starWhite");

            //load Bone
            _bone = Content.Load<Texture2D>("b0ne");



            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here


            if (Mouse.GetState().LeftButton == ButtonState.Pressed) ;

            {
                _moveX = Mouse.GetState().X;
                _moveY = Mouse.GetState().Y;
            }

            _boneX = _moveX;
            _boneY = _moveY;

            while (_moveX >= 1 || _moveY >= 1)
            {
                _shmoovin = true;
            }




            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            //backgroung


            _spriteBatch.Draw(_bone,
             new Vector2(_boneX, _boneY),
             null,
             Color.White,
             0,
             new Vector2(0, 0),
             _boneScale,
             SpriteEffects.None,
             0
             );





            {
               



                _spriteBatch.End();
                base.Draw(gameTime);
            }
        }
    }
}