using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ZombieTD
{
    public abstract class BaseUpgrade : IEffect
    {
        string _upgradeName;
        protected int _ticksTillUpgrade;
        IMediator _mediator;
        SpriteFont _spr_font_Upgrages;
        Random r = new Random();
        List<Particle> textParticles = new List<Particle>();
        GraphicsDevice _graphicsDevice;
        Texture2D _particleTexture;
        Color _color = Color.Red;
        bool _display = false;
        ulong _offTicks;
        bool _isActive;
        bool _hasBeenDone = false;


        public BaseUpgrade(string upgradeName)
        {
            _upgradeName = upgradeName;
        }

        public void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            if (_display)
            {
                if (textParticles != null)
                {
                    // In Draw()
                    foreach (var particle in textParticles)
                    {
                        Vector2 pos = particle.Position * 4F;
                        Vector2 origin =
                            new Vector2(_particleTexture.Width, _particleTexture.Height) / 2f;

                        spriteBatch.Draw(_particleTexture, pos, null, _color, 0f, origin, 1f, SpriteEffects.None, 0);
                    }
                }
            }
        }

        public void LoadContent(IMediator mediator)
        {
            _mediator = mediator;
            _graphicsDevice = mediator.GetGraphicsDevice();
            _spr_font_Upgrages = mediator.GetContentManager().Load<SpriteFont>("Upgrade");
            ITexture  texture = mediator.GetAsset<EffectTextureType, ITexture>(EffectTextureType.Particle);
            _particleTexture = texture.GetTexture();
            SetUpParticles(_graphicsDevice, _spr_font_Upgrages, _upgradeName);
        }

        public void update()
        {
            if (GameMediator.numberofTicks % (ulong)_ticksTillUpgrade == 0 && !_hasBeenDone)
            {
                _display = true;
                _isActive = true;
                _hasBeenDone = true;
                _offTicks = GameMediator.numberofTicks + 700;
                PreformUpgrade(_mediator.GetGameElements());

            }

            if (_display)
            {
                if (textParticles != null)
                {
                    foreach (var particle in textParticles)
                        particle.Update();
                }

                if (GameMediator.numberofTicks % (ulong)_offTicks == 0)
                    _display = false;
            }
            
        }

        public abstract void PreformUpgrade(List<IGameElement> elementsToUpgrade);
        

        public virtual void PreformUpgrade(IGameElement elementToUpgrade)
        {
            if (_isActive)
            {
                List<IGameElement> list = new List<IGameElement>();

                list.Add(elementToUpgrade);

                PreformUpgrade(list);
            }
        }

        private List<Vector2> GetParticlePositions(GraphicsDevice device, SpriteFont font, string text)
        {
            Vector2 size = font.MeasureString(text) + new Vector2(0.5f);
            int width = (int)size.X;
            int height = (int)size.Y;

            // Create a temporary render target and draw the font on it.
            RenderTarget2D target = new RenderTarget2D(device, width, height);
            device.SetRenderTarget(target);
            device.Clear(Color.Transparent);

            SpriteBatch spriteBatch = new SpriteBatch(device);
            spriteBatch.Begin();
            spriteBatch.DrawString(font, text, new Vector2(0,0), Color.White);
            spriteBatch.End();

            device.SetRenderTarget(null);   // unset the render target

            // read back the pixels from the render target
            Color[] data = new Color[width * height];
            target.GetData(data);
            target.Dispose();

            // Return a list of points corresponding to pixels drawn by the
            // font. The font size will affect the number of points and the
            // quality of the text.
            List<Vector2> points = new List<Vector2>();
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    // Add all points that are lighter than 50% grey. The text
                    // is white, but due to anti-aliasing pixels on the border
                    // may be shades of grey.
                    if (data[width * y + x].R > 128)
                        points.Add(new Vector2(x + 40 , y + 2));
                }
            }

            return points;
        }

        private void SetUpParticles(GraphicsDevice graphicsDevice, SpriteFont font, string text)
        {
            var textPoints = GetParticlePositions(graphicsDevice, font, text);

            foreach (var point in textPoints)
            {
                var particle = new Particle()
                {
                    Position = new Vector2(r.Next(EngineConstants.ScreenWidth), r.Next(EngineConstants.ScreenHeight)),
                    Destination = point
                };

                textParticles.Add(particle);
            }
        }

    }

}
