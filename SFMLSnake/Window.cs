﻿using SFML.Graphics;
using SFML.System;
using SFML.Window;

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
            RenderWindow = new RenderWindow(new VideoMode((uint)World.Width, (uint)World.Height), "Snake");
            Grid = new Grid(new Position(0, 0));
        }

        public void SetTitle(string text) => RenderWindow.SetTitle(text);

        public void Close() => RenderWindow.Close();

        public void Render()
        {
            RenderWindow.Clear();
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
                    Grid.Sprite.Position = new Vector2f(i, j);
                    RenderWindow.Draw(Grid.Sprite);
                }
            }
        }

        private void DrawObjects()
        {
            foreach (var gameObject in World.GameObjects)
            {
                gameObject.Sprite.Position = new Vector2f(gameObject.Position.X, gameObject.Position.Y);
                RenderWindow.Draw(gameObject.Sprite);
            }
        }
    }
}