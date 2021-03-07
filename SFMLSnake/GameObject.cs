using SFML.Graphics;
using SFML.System;

namespace SFMLSnake
{
    public abstract class GameObject
    {
        public Location Location;
        public Sprite Sprite { get; protected set; }
        public GameObject(Location location)
        {
            Location = location;
        }

        public virtual void Update()
        {

        }
    }
}