using SFML.Graphics;
using SFML.Window;

namespace SFMLSnake
{
    public class Renderer
    {
        public RenderWindow RenderWindow { get; }
        public uint Size { get; }
        public GameWorld World { get; }
        public Renderer(GameWorld world)
        {
            Size = 16;
            World = world;
            RenderWindow= new RenderWindow(new VideoMode(Size * World.Width, Size * World.Height), "Snake");
        }

    }
}