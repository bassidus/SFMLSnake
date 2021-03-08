using SFML.Graphics;
using SFML.Window;

namespace SFMLSnake
{
    public class Snake : GameObject
    {
        public Directions Direction { get; private set; }
        public Snake(Position position) : base(position)
        {
            Direction = Directions.Up;
            Sprite.Color = Color.Green; // green
        }
        public void ChangeDirection(Directions direction)
        {
            Direction = direction switch
            {
                Directions.Up => Direction == Directions.Down ? Direction : direction,
                Directions.Down => Direction == Directions.Up ? Direction : direction,
                Directions.Left => Direction == Directions.Right ? Direction : direction,
                _ => Direction == Directions.Left ? Direction : direction,
            };
        }
        public void KeyScanner()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
            {
                ChangeDirection(Directions.Up);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
            {
                ChangeDirection(Directions.Down);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
            {
                ChangeDirection(Directions.Left);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
            {
                ChangeDirection(Directions.Right);
            }
        }
        public override void Update(int scale)
        {
            Position += Direction switch
            {
                Directions.Up => new Position(0, -scale / 5),
                Directions.Down => new Position(0, scale / 5),
                Directions.Left => new Position(-scale / 5, 0),
                _ => new Position(scale / 5, 0)
            };
        }
    }
}