using SFML.Graphics;
using SFML.Window;

namespace SFMLSnake
{
    public class Snake : GameObject
    {
        public Direction Direction { get; private set; }
        public Snake(Position position) : base(position)
        {
            Direction = Direction.Up;
            Sprite.Color = Color.Green; // green
        }
        public void ChangeDirection(Direction direction)
        {
            Direction = direction switch
            {
                Direction.Up => Direction == Direction.Down ? Direction : direction,
                Direction.Down => Direction == Direction.Up ? Direction : direction,
                Direction.Left => Direction == Direction.Right ? Direction : direction,
                _ => Direction == Direction.Left ? Direction : direction,
            };
        }
        public void KeyScanner()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
            {
                ChangeDirection(Direction.Up);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
            {
                ChangeDirection(Direction.Down);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
            {
                ChangeDirection(Direction.Left);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
            {
                ChangeDirection(Direction.Right);
            }
        }
        public override void Update(int scale)
        {
            Position += Direction switch
            {
                Direction.Up => new Position(0, -scale / 5),
                Direction.Down => new Position(0, scale / 5),
                Direction.Left => new Position(-scale / 5, 0),
                _ => new Position(scale / 5, 0)
            };
        }
    }
}