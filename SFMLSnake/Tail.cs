using SFML.Graphics;

namespace SFMLSnake
{
    public class Tail : GameObject
    {
        public Tail(Position location) : base(location)
        {
            Sprite.Color = Color.Green;
        }
    }
}