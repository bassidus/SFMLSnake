using SFML.System;
using System;
using System.Collections.Generic;

namespace SFMLSnake
{
    public class GameWorld
    {
        public int Score { get; private set; }
        public int Width { get; }
        public int Height { get; }
        public List<GameObject> GameObjects { get; }
        public GameWorld(int width, int height)
        {
            Width = width;
            Height = height;
            GameObjects = new List<GameObject>();
            Score = 100;
            AddFruitAtRandomLocation();
        }

        private void Clamp(GameObject gameObject)
        {

            if (gameObject.Location.X > Width - 1)
            {
                gameObject.Location = new Position(0, gameObject.Location.Y);
            }
            if (gameObject.Location.X < 0)
            {
                gameObject.Location = new Position(Width - 1, gameObject.Location.Y);
            }
            if (gameObject.Location.Y > Height - 1)
            {
                gameObject.Location = new Position(gameObject.Location.X, 0);
            }
            if (gameObject.Location.Y < 0)
            {
                gameObject.Location = new Position(gameObject.Location.X, Height - 1);
            }
        }

        private void AddFruitAtRandomLocation()
        {
            var random = new Random();
            var x = random.Next(Width);
            var y = random.Next(Height);
            var position = new Position(x, y);
            var fruit = new Fruit(position);
            GameObjects.Add(fruit);
        }
        public void Update()
        {
            Snake snake = GameObjects.Find(o => o is Snake) as Snake;
            Fruit fruit = GameObjects.Find(o => o is Fruit) as Fruit;
            GameObjects.Add(new Tail(snake.Location));

            foreach (var gameObject in GameObjects)
            {
                if (gameObject is Snake snake2)
                {
                    (gameObject as Snake).ChangeDirection(AI(snake, fruit));
                }
                gameObject.Update();
                Clamp(gameObject);
            }

            if (snake.Location == fruit.Location)
            {
                Score++;
                GameObjects.Remove(fruit);
                AddFruitAtRandomLocation();
            }

            var tailCount = GameObjects.FindAll(o => o is Tail).Count;
            if (tailCount > Score)
            {
                var tail = GameObjects.Find(o => o is Tail);
                GameObjects.Remove(tail);
            }
        }

        private Directions AI(Snake snake, Fruit fruit)
        {
            var xDifference = Difference(snake.Location.X, fruit.Location.X);
            var yDifference = Difference(snake.Location.Y, fruit.Location.Y);
            if (xDifference > yDifference)
            {
                if (snake.Location.X > fruit.Location.X)
                {
                    return Directions.Left;
                }
                else
                {
                    return Directions.Right;
                }

            }
            else
            {
                if (snake.Location.Y > fruit.Location.Y)
                {
                    return Directions.Up;
                }
                else
                {
                    return Directions.Down;
                }
            }
            static float Difference(float x1, float x2) => x1 > x2 ? x1 - x2 : x2 - x1;
        }
    }
}