using SFML.Graphics;
using SFML.Window;

namespace SFMLSnake
{
    public class Renderer
    {
        public uint PixelSize { get; }
        public RenderWindow RenderWindow { get; }
        public GameWorld World { get; }
        public Renderer(GameWorld world)
        {
            PixelSize = 16;
            World = world;
            RenderWindow = new RenderWindow(new VideoMode(PixelSize * World.Width, PixelSize * World.Height), "Snake");
        }

        public void Render()
        {

        }
    }
}