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
            Score = 0;
            AddFruitAtRandomLocation();
        }

        private void Clamp(GameObject gameObject)
        {

            if (gameObject.Location.X > Width - 1)
            {
                gameObject.Location = new Location(0, gameObject.Location.Y);
            }
            if (gameObject.Location.X < 0)
            {
                gameObject.Location = new Location(Width - 1, gameObject.Location.Y);
            }
            if (gameObject.Location.Y > Height - 1)
            {
                gameObject.Location = new Location(gameObject.Location.X, 0);
            }
            if (gameObject.Location.Y < 0)
            {
                gameObject.Location = new Location(gameObject.Location.X, Height - 1);
            }
        }

        private void AddFruitAtRandomLocation()
        {
            var location = new Location(new Random().Next(Width), new Random().Next(Height));
            GameObjects.Add(new Fruit(location));
        }
        public void Update()
        {
            Snake snake = GameObjects.Find(o => o is Snake) as Snake;
            Fruit fruit = GameObjects.Find(o => o is Fruit) as Fruit;
            GameObjects.Add(new Tail(snake.Location));

            foreach (var gameObject in GameObjects)
            {
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
                var tail = GameObjects.Find(o=>o is Tail);
                GameObjects.Remove(tail);
            }
        }
    }
}