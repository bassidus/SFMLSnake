using SFML.Graphics;

namespace SFMLSnake
{
    public class Tail : GameObject
    {
        public Tail(Position location) : base(location)
        {
            Sprite.Color = Color.Green;
            Circle.FillColor = new Color(100, 255, 10, 200);
            Circle.OutlineColor = new Color(200, 200, 200, 200);
            Circle.OutlineThickness = -3;
        }
    }
}