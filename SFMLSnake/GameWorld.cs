using SFML.System;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SFMLSnake
{
    public class GameWorld
    {
        public List<GameObject> GameObjects = new List<GameObject>();
        public int Score { get; private set; }
        public int Width { get; }
        public int Height { get; }
        public GameWorld(int width, int height)
        {
            Width = width;
            Height = height;
            Score = 0;
            Add(new Fruit(RandomPosition()));
        }

        public T Add<T>(T gameObject) where T : GameObject
        {
            GameObjects.Add(gameObject);
            return gameObject;
        }
        private void Clamp(GameObject gameObject)
        {

            if (gameObject.Position.X > Width - 1)
            {
                gameObject.SetPosition(new Position(0, gameObject.Position.Y));
            }
            if (gameObject.Position.X < 0)
            {
                gameObject.SetPosition(new Position(Width - 1, gameObject.Position.Y));
            }
            if (gameObject.Position.Y > Height - 1)
            {
                gameObject.SetPosition(new Position(gameObject.Position.X, 0));
            }
            if (gameObject.Position.Y < 0)
            {
                gameObject.SetPosition(new Position(gameObject.Position.X, Height - 1));
            }
        }

        public Position RandomPosition()
        {
            var random = new Random();
            var position = new Position(random.Next(Width), random.Next(Height));
            foreach (var gameObject in GameObjects)
            {
                if (position == gameObject.Position)
                {
                    position = RandomPosition();
                }
            }
            return position;
        }

        public void Update()
        {
            Snake snake = GameObjects.Find(o => o is Snake) as Snake;
            Fruit fruit = GameObjects.Find(o => o is Fruit) as Fruit;
            Add(new Tail(snake.Position));

            foreach (var gameObject in GameObjects)
            {
                if (gameObject is Snake snake2)
                {
                    (gameObject as Snake).ChangeDirection(AI(snake, fruit));
                }
                gameObject.Update();
                Clamp(gameObject);
            }

            if (snake.Position == fruit.Position)
            {
                Score++;
                GameObjects.Remove(fruit);
                Add(new Fruit(RandomPosition()));
            }

            var tailCount = GameObjects.FindAll(o => o is Tail).Count;
            if (tailCount > Score)
            {
                GameObjects.Remove(GameObjects.Find(o => o is Tail));
            }
        }

        private Directions AI(Snake snake, Fruit fruit)
        {
            var xDifference = Difference(snake.Position.X, fruit.Position.X);
            var yDifference = Difference(snake.Position.Y, fruit.Position.Y);
            if (xDifference > yDifference)
            {
                if (snake.Position.X > fruit.Position.X)
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
                if (snake.Position.Y > fruit.Position.Y)
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