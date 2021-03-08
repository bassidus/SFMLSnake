using System;
using System.Collections.Generic;

namespace SFMLSnake
{
    public class GameWorld
    {
        private int Counter { get; set; }
        public int FrameRate { get; }
        public List<GameObject> GameObjects { get; }
        public int Height { get; }
        public int Scale { get; }
        public int Score { get; private set; }
        public int Width { get; }
        public GameWorld(int width, int height, int scale, int frameRate)
        {
            Counter = 1;
            FrameRate = frameRate;
            GameObjects = new List<GameObject>();
            Score = 0;
            Scale = scale;
            Height = height * scale;
            Width = width * scale;
            Add(new Fruit(RandomPosition()));
        }

        public T Add<T>(T gameObject) where T : GameObject
        {
            GameObjects.Add(gameObject);
            return gameObject;
        }
        private void Clamp(GameObject gameObject)
        {

            if (gameObject.Position.X > Width)
            {
                gameObject.SetPosition(new Position(0, gameObject.Position.Y));
            }
            if (gameObject.Position.X < 0)
            {
                gameObject.SetPosition(new Position(Width - Scale / FrameRate, gameObject.Position.Y));
            }
            if (gameObject.Position.Y > Height)
            {
                gameObject.SetPosition(new Position(gameObject.Position.X, 0));
            }
            if (gameObject.Position.Y < 0)
            {
                gameObject.SetPosition(new Position(gameObject.Position.X, Height - Scale / FrameRate));
            }
        }

        public Position RandomPosition()
        {
            var random = new Random();
            var x = random.Next(Width / Scale) * Scale;
            var y = random.Next(Height / Scale) * Scale;
            var position = new Position(x, y);
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
            if (Counter % FrameRate == 0)
            {
                Counter = 0;
                Add(new Tail(snake.Position));
            }
            Counter++;

            foreach (var gameObject in GameObjects)
            {
                if (gameObject is Snake)
                {
                    (gameObject as Snake).KeyScanner();
                    //(gameObject as Snake).ChangeDirection(AI(snake, fruit));
                }
                gameObject.Update(Scale/FrameRate);
                Clamp(gameObject);
            }

            if (CheckCollision(snake.Position, fruit.Position))
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

        private bool CheckCollision(Position p1, Position p2)
        {
            if (p1.X + Scale > p2.X && p1.X < p2.X + Scale)
                if (p1.Y + Scale > p2.Y && p1.Y < p2.Y + Scale)
                    return true;
            return false;
        }

        private Direction AI(Snake snake, Fruit fruit)
        {
            var xDifference = Difference(snake.Position.X, fruit.Position.X);
            var yDifference = Difference(snake.Position.Y, fruit.Position.Y);
            if (xDifference > yDifference)
            {
                if (snake.Position.X > fruit.Position.X)
                {
                    return Direction.Left;
                }
                else
                {
                    return Direction.Right;
                }

            }
            else
            {
                if (snake.Position.Y > fruit.Position.Y)
                {
                    return Direction.Up;
                }
                else
                {
                    return Direction.Down;
                }
            }
            static float Difference(float x1, float x2) => x1 > x2 ? x1 - x2 : x2 - x1;
        }
    }
}