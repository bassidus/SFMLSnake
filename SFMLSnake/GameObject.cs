using SFML.Graphics;
using SFML.System;

namespace SFMLSnake
{
    public abstract class GameObject
    {
        public Position Location;
        public Sprite Sprite { get; protected set; }
        public GameObject(Position location)
        {
            Location = location;
        }

        public virtual void Update()
        {

        }
    }
}