using SFML.Graphics;

namespace SFMLSnake
{
    public class Grid : GameObject
    {
        public Grid(Position position) : base(position)
        {
            Position = position;
            Sprite = new Sprite(new Texture("images/white.png"));
        }
    }
}