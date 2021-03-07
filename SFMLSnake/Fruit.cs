using SFML.Graphics;
using SFML.System;

namespace SFMLSnake
{
    public class Fruit : GameObject
    {

        public Fruit(Location location):base(location)
        {
            Sprite = new Sprite(new Texture("images/red.png"));
        }
    }
}