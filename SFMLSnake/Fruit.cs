using SFML.Graphics;
using SFML.System;

namespace SFMLSnake
{
    public class Fruit : GameObject
    {
        public Fruit(Position location) : base(location)
        {
            Sprite.Color = Color.Red;
        }
    }
}