using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;

namespace SFMLSnake {

    internal class Program {
        private static readonly uint Width = 30, Height = 20;
        private static readonly uint grid = 16;
        private static int score = 0;
        private static Directions direction;
        private static readonly Random random = new Random();

        private static void Main() {
            var timer = 0f;
            var delay = 0.1f;
            var window = new RenderWindow(new VideoMode(grid * Width, grid * Height), "Snake");
            var clock = new Clock();
            var fruit = new Fruit(new Location(10, 10));
            var block = new Grid(new Location(0, 0));
            var snake = new Snake[100];

            for (int i = 0; i < snake.Length; i++) {
                snake[i] = new Snake(new Location(20, 20));
            }

            while (window.IsOpen) {
                window.SetTitle($"SFML Snake by bassidus 2021 - Points: {score}");
                float time = clock.ElapsedTime.AsSeconds();
                clock.Restart();
                timer += time;
                ChangeDirection();

                // exit check
                if (Keyboard.IsKeyPressed(Keyboard.Key.Q) || Keyboard.IsKeyPressed(Keyboard.Key.Escape)) {
                    window.Close();
                }

                if (timer > delay) {
                    timer = 0;
                    Tick(ref snake, ref fruit);
                }

                Renderer(window, block, fruit, snake);
            }
        }

        private static void Renderer(RenderWindow window, Grid block, Fruit fruit, Snake[] snake) {
            window.Clear();

            // draw grid
            for (int i = 0; i < Width; i++)
                for (int j = 0; j < Height; j++) {
                    block.Sprite.Position = new Vector2f(i * grid, j * grid);
                    window.Draw(block.Sprite);
                }

            // draw snake head
            snake[0].Head.Position = new Vector2f(snake[0].Location.X * grid, snake[0].Location.Y * grid);
            window.Draw(snake[0].Head);

            // draw tail
            for (int i = 1; i <= score; i++) {
                snake[i].Body.Position = new Vector2f(snake[i].Location.X * grid, snake[i].Location.Y * grid);
                window.Draw(snake[i].Body);
            }

            // draw fruit
            fruit.Sprite.Position = new Vector2f(fruit.Location.X * grid, fruit.Location.Y * grid);
            window.Draw(fruit.Sprite);

            window.Display();
        }

        private static void ChangeDirection() {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Up) && direction != Directions.Down) {
                direction = Directions.Up;
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.Down) && direction != Directions.Up) {
                direction = Directions.Down;
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.Left) && direction != Directions.Right) {
                direction = Directions.Left;
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.Right) && direction != Directions.Left) {
                direction = Directions.Right;
            }
        }

        private static void Tick(ref Snake[] snake, ref Fruit fruit) {
            for (int i = score; i > 0; --i) {
                snake[i].Location = snake[i - 1].Location;
            }

            switch (direction) {
                case Directions.Up:
                    snake[0].Location -= new Location(0, 1);
                    break;

                case Directions.Down:
                    snake[0].Location += new Location(0, 1);
                    break;

                case Directions.Left:
                    snake[0].Location -= new Location(1, 0);
                    break;

                case Directions.Right:
                    snake[0].Location += new Location(1, 0);
                    break;

                default:
                    break;
            }

            if ((snake[0].Location == fruit.Location)) {
                score++;
                fruit.Location = new Location(random.Next() % Width, random.Next() % Height);
            }

            if (snake[0].Location.X > Width) {
                snake[0].Location = new Location(0, snake[0].Location.Y);
            }
            if (snake[0].Location.X < 0) {
                snake[0].Location = new Location(Width, snake[0].Location.Y);
            }
            if (snake[0].Location.Y > Height) {
                snake[0].Location = new Location(snake[0].Location.X, 0);
            }
            if (snake[0].Location.Y < 0) {
                snake[0].Location = new Location(snake[0].Location.X, Height);
            }

            for (int i = 1; i < score; i++) {
                if (snake[0].Location.X == snake[i].Location.X && snake[0].Location.Y == snake[i].Location.Y) {
                    score = i;
                }
            }
        }
    }
}