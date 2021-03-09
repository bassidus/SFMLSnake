using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace SFMLSnake
{

    public class Game
    {
        private GameWorld World { get; }
        private RenderWindow Window { get; }

        public Game()
        {
            World = new GameWorld(30, 20, 16, 5);
            Window = new RenderWindow(new VideoMode((uint)World.Width, (uint)World.Height), "Snake");
            Window.KeyPressed += Window_KeyPressed;
        }

        private void Window_KeyPressed(object sender, KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.Escape || e.Code == Keyboard.Key.Q)
            {
                Window.Close();
            }
        }

        public void RunGame()
        {
            var timer = 0f;
            var delay = 0.1f;
            var clock = new Clock();
            var snake = World.Add(new Snake(World.RandomPosition()));
            while (Window.IsOpen)
            {
                Window.SetTitle($"SFML Snake by Bassidus and Han 2021 - Score: {World.Score}");
                timer += clock.ElapsedTime.AsSeconds();
                clock.Restart();

                Window.DispatchEvents();
                // exit check

                if (timer > delay / World.FrameRate)
                {
                    timer = 0;
                    World.Update();
                }
                Window.Clear(new Color(25, 25, 25));
                DrawGrid();
                DrawObjects();
                Window.Display();
            }
        }

        private void DrawObjects()
        {
            foreach (var gameObject in World.GameObjects)
            {
                gameObject.Circle.Position = new Vector2f(gameObject.Position.X, gameObject.Position.Y);
                Window.Draw(gameObject.Circle);
            }
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
                        Window.Draw(circle);
                    }
                }
            }
        }
    }
}