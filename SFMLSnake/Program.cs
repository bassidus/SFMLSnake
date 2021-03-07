using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;

namespace SFMLSnake {

    internal class Program {
        public static readonly uint Width = 30, Height = 20;
        private static readonly uint gridSize = 16;
        private static int score = 0;

        private static void Main() {
            var timer = 0f;
            var delay = 0.1f;
            var window = new RenderWindow(new VideoMode(gridSize * Width, gridSize * Height), "Snake");
            var clock = new Clock();
            var fruit = new Fruit(new Location(10, 10));
            var grid = new Grid(new Location(0, 0));
            var snake = new Snake[100];

            for (int i = 0; i < snake.Length; i++) {
                snake[i] = new Snake(new Location(20, 20));
            }

            while (window.IsOpen) {
                window.SetTitle($"SFML Snake by bassidus 2021 - Score: {score}");
                float time = clock.ElapsedTime.AsSeconds();
                clock.Restart();
                timer += time;

                if (Keyboard.IsKeyPressed(Keyboard.Key.Up)) { snake[0].ChangeDirection(Directions.Up); }
                if (Keyboard.IsKeyPressed(Keyboard.Key.Down)) { snake[0].ChangeDirection(Directions.Down); }
                if (Keyboard.IsKeyPressed(Keyboard.Key.Left)) { snake[0].ChangeDirection(Directions.Left); }
                if (Keyboard.IsKeyPressed(Keyboard.Key.Right)) { snake[0].ChangeDirection(Directions.Right); }

                // exit check
                if (Keyboard.IsKeyPressed(Keyboard.Key.Q) || Keyboard.IsKeyPressed(Keyboard.Key.Escape)) {
                    window.Close();
                }

                if (timer > delay) {
                    timer = 0;
                    Tick(ref snake, ref fruit);
                }

                Renderer(window, grid, fruit, snake);
            }
        }

        private static void Renderer(RenderWindow window, Grid grid, Fruit fruit, Snake[] snake) {
            window.Clear();

            // draw grid
            for (int i = 0; i < Width; i++)
                for (int j = 0; j < Height; j++) {
                    grid.Sprite.Position = new Vector2f(i * gridSize, j * gridSize);
                    window.Draw(grid.Sprite);
                }

            // draw snake head
            snake[0].Head.Position = new Vector2f(snake[0].Location.X * gridSize, snake[0].Location.Y * gridSize);
            window.Draw(snake[0].Head);

            // draw tail
            for (int i = 1; i <= score; i++) {
                snake[i].Body.Position = new Vector2f(snake[i].Location.X * gridSize, snake[i].Location.Y * gridSize);
                window.Draw(snake[i].Body);
            }

            // draw fruit
            fruit.Sprite.Position = new Vector2f(fruit.Location.X * gridSize, fruit.Location.Y * gridSize);
            window.Draw(fruit.Sprite);

            window.Display();
        }

        private static void Tick(ref Snake[] snake, ref Fruit fruit) {
            for (int i = score; i > 0; --i) {
                snake[i].Location = snake[i - 1].Location;
            }

            snake[0].Update();

            // food check
            if ((snake[0].Location == fruit.Location)) {
                var random = new Random();
                fruit.Location = new Location(random.Next((int)Width), random.Next((int)Height));
                score++;
            }

            // tail collision
            for (int i = 1; i < score; i++) {
                if (snake[0].Location == snake[i].Location) {
                    score = i;
                }
            }
        }
    }
}