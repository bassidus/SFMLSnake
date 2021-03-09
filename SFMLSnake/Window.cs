using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections;

namespace SFMLSnake
{

    public class Window
    {
        public bool IsOpen => RenderWindow.IsOpen;
        public RenderWindow RenderWindow { get; }
        public GameWorld World { get; }
        private Grid Grid { get; }

        public Window(GameWorld world)
        {
            World = world;
            RenderWindow = new RenderWindow(new VideoMode((uint)world.Width, (uint)world.Height), "Snake");
            Grid = new Grid(new Position(0, 0));
        }

        public void SetTitle(string text) => RenderWindow.SetTitle(text);

        public void Close() => RenderWindow.Close();

        public void DispatchEvents() => RenderWindow.DispatchEvents();

        public void Render()
        {
            RenderWindow.Clear(new Color(25, 25, 25));
            DrawGrid();
            DrawObjects();
            RenderWindow.Display();
        }

        private void DrawGrid()
        {
            for (int i = 0; i < World.Width; i += World.Scale)
            {
                for (int j = 0; j < World.Height; j += World.Scale)
                {
                    //Grid.Sprite.Position = new Vector2f(i, j);
                    //RenderWindow.Draw(Grid.Sprite);
                    if (new Random().Next(100) < 1)
                    {
                        var circle = new CircleShape(1);
                        circle.Position = new Vector2f(i, j);
                        RenderWindow.Draw(circle);
                    }
                }
            }
        }

        private void DrawObjects()
        {
            foreach (var gameObject in World.GameObjects)
            {
                gameObject.Circle.Position = new Vector2f(gameObject.Position.X, gameObject.Position.Y);
                RenderWindow.Draw(gameObject.Circle);
            }
        }
    }
}