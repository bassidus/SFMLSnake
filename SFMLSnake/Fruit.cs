using SFML.Graphics;

namespace SFMLSnake
{
    public class Fruit : GameObject
    {
        public Fruit(Position location) : base(location)
        {
            Sprite.Color = Color.Red;
            Circle.FillColor = new Color(255, 10, 10, 200);
            Circle.OutlineColor = new Color(200, 200, 200, 200);
            Circle.OutlineThickness = -3;
        }
    }
}