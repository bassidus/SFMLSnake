namespace SFMLSnake
{
    public class GameWorld
    {
        public uint Width { get; }
        public uint Height { get; }

        public GameWorld(uint width, uint height)
        {
            Height = height;
            Width = width;
        }
    }
}