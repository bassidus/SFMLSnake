using SFML.Graphics;

namespace SFMLSnake
{
    public class Tail : GameObject
    {
        public Tail(Location location) : base(location)
        {
            Location = location;
            Sprite = new Sprite(new Texture("images/green.png"));
        }
    }
}