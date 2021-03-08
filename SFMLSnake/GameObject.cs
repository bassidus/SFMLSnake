using SFML.Graphics;

namespace SFMLSnake
{
    public abstract class GameObject
    {
        public Position Position { get; protected set; }
        public Sprite Sprite { get; protected set; }
        public GameObject(Position position)
        {
            Position = position;
            Sprite = new Sprite(new Texture("images/white.png"));
        }

        public void SetPosition(Position position) => Position = position;

        public virtual void Update(int scale)
        {
        }
    }
}