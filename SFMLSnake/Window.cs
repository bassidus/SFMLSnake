using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace SFMLSnake {

    public class Window {
        public bool IsOpen => RenderWindow.IsOpen;
        public RenderWindow RenderWindow { get; }
        public int Scale { get; }
        public GameWorld World { get; }
        private Grid Grid { get; }

        public Window(GameWorld world, int scale) {
            Scale = scale;
            World = world;
            RenderWindow = new RenderWindow(new VideoMode((uint)(Scale * World.Width), (uint)(Scale * World.Height)), "Snake");
            Grid = new Grid(new Position(0, 0));
        }

        public void SetTitle(string text) => RenderWindow.SetTitle(text);

        public void Close() => RenderWindow.Close();

        public void Render() {
            RenderWindow.Clear();
            DrawGrid();
            DrawObjects();
            RenderWindow.Display();
        }

        private void DrawGrid() {
            for (int i = 0; i < World.Width; i++) {
                for (int j = 0; j < World.Height; j++) {
                    Grid.Sprite.Position = new Vector2f(i, j) * Scale;
                    RenderWindow.Draw(Grid.Sprite);
                }
            }
        }

        private void DrawObjects() {
            foreach (var gameObject in World.GameObjects) {
                gameObject.Sprite.Position = new Vector2f(gameObject.Location.X, gameObject.Location.Y) * Scale;
                RenderWindow.Draw(gameObject.Sprite);
            }
        }
    }
}