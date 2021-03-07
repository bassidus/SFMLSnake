using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace SFMLSnake {

    internal class Program {
        private static readonly uint Width = 30, Height = 20;
        private static readonly uint grid = 16;
        private static readonly uint horizontalBlock = grid * Width;
        private static readonly uint verticalBlock = grid * Height;
        private static int score = 4;
        private static Directions direction;
        private static readonly Random random = new Random();

        private static void Main() {
            RenderWindow window = new RenderWindow(new VideoMode(horizontalBlock, verticalBlock), "Snake");

            Texture textureBlock, textureHead, textureFruit, textureSnake;
            textureBlock = new Texture("white.png");
            textureFruit = new Texture("red.png");
            textureHead = new Texture("red.png");
            textureSnake = new Texture("green.png");

            Sprite spriteBlock = new Sprite(textureBlock);
            Sprite spriteFruit = new Sprite(textureFruit);
            Sprite spriteSnake = new Sprite(textureSnake);
            Sprite spriteHead = new Sprite(textureHead);

            Clock clock = new Clock();
            float timer = 0, delay = 0.1f;

            Fruit fruit = new Fruit();
            Snake[] snake = new Snake[100];
            for (int i = 0; i < snake.Length; i++) {
                snake[i] = new Snake();
            }

            fruit.Location = new Location(10, 10);

            while (window.IsOpen) {
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

                Renderer(window, spriteBlock, spriteFruit, spriteSnake, spriteHead, fruit, snake);
            }
        }

        private static void Renderer(RenderWindow window, Sprite spriteBlock, Sprite spriteFruit, Sprite spriteSnake, Sprite spriteHead, Fruit fruit, Snake[] snake) {
            window.Clear();

            for (int i = 0; i < Width; i++)
                for (int j = 0; j < Height; j++) {
                    spriteBlock.Position = new Vector2f(i * grid, j * grid);
                    window.Draw(spriteBlock);
                }

            // draw snake
            for (int i = 0; i < score; i++) {
                if (i == 0) {
                    spriteHead.Position = new Vector2f(snake[i].Location.X * grid, snake[i].Location.Y * grid);
                    window.Draw(spriteHead);
                } else {
                    spriteSnake.Position = new Vector2f(snake[i].Location.X * grid, snake[i].Location.Y * grid);
                    window.Draw(spriteSnake);
                }
            }

            // draw fruit
            spriteFruit.Position = new Vector2f(fruit.Location.X * grid, fruit.Location.Y * grid);
            window.Draw(spriteFruit);

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