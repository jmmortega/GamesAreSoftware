using GamesAreSoftware.Services;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.ComponentModel;

namespace GamesAreSoftware.Base
{
    public abstract class DrawableEntity : NotifyChanged, IDrawableEntity
    {
        private GameTime _lastDrawGameTime;
        private int _drawOrder;
        private bool _visible;
        private Vector2 _position;
        private Texture2D _texture;
        private Color _color;
        private Rectangle _rectangle;

        public DrawableEntity(Texture2D texture, Vector2 position, Color color)
        {
            Texture = texture;
            Position = position;
            Color = color;

            this.PropertyChanged -= DrawablePropertiesAffectedChanged;
            this.PropertyChanged += DrawablePropertiesAffectedChanged;
        }
        
        public int DrawOrder
        {
            get => _drawOrder;
            set
            {
                _drawOrder = value;
                RaiseDrawOrder();
                RaiseProperty();
            }
        }

        public bool Visible
        {
            get => _visible;
            set
            {
                _visible = value;
                RaiseVisible();
                RaiseProperty();
            }
        }

        public Vector2 Position
        {
            get => _position;
            set
            {
                _position = value;
                this.Rectangle = new Rectangle(Position.ToPoint(), new Point(_texture.Width, _texture.Height));
                RaiseProperty();
            }
        }
        public Texture2D Texture
        {
            get => _texture;
            private set
            {
                _texture = value;
                this.Rectangle = new Rectangle(Position.ToPoint(), new Point(_texture.Width, _texture.Height));
                RaiseProperty();
            }
        }
        public Color Color
        {
            get => _color;
            set
            {
                _color = value;
                RaiseProperty();
            }            
        }

        public Rectangle Rectangle
        {
            get => _rectangle;
            set
            {
                _rectangle = value;
                RaiseProperty();
            }
        }

        public event EventHandler<EventArgs> DrawOrderChanged;
        public event EventHandler<EventArgs> VisibleChanged;

        public void RaiseDrawOrder()
        {
            DrawOrderChanged?.Invoke(this, new EventArgs());
        }

        public void RaiseVisible()
        {
            VisibleChanged?.Invoke(this, new EventArgs());
        }

        public void Draw(GameTime gameTime)
        {            
            if(_lastDrawGameTime != gameTime)
            {
                _lastDrawGameTime = gameTime;
                Locator.Get<IDrawableService>().Draw(gameTime, this);
            }            
        }

        public abstract void Update(GameTime gameTime);

        private void DrawablePropertiesAffectedChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(Visible) || 
               e.PropertyName == nameof(DrawOrder) || 
               e.PropertyName == nameof(Texture) ||
               e.PropertyName == nameof(Color) ||
               e.PropertyName == nameof(Position) ||
               e.PropertyName == nameof(Rectangle))
            {
                Draw(_lastDrawGameTime);
            }
        }
    }
}
