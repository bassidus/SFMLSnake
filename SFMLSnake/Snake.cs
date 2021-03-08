using SFML.Graphics;
using SFML.Window;

namespace SFMLSnake
{
    public class Snake : GameObject
    {
        public Directions Direction { get; private set; }
        public Snake(Position position):base(position)
        {
            Direction = Directions.Up;
            Sprite.Color = Color.Green; // green
        }

        public override void Update()
        {
            Position += Direction switch
            {
                Directions.Up => new Position(0, -1),
                Directions.Down => new Position(0, 1),
                Directions.Left => new Position(-1, 0),
                _ => new Position(1, 0)
            };
        }

        public void ChangeDirection(Direction direction) {
            Direction = direction switch {
                Direction.Up => Direction == Direction.Down ? Direction : direction,
                Direction.Down => Direction == Direction.Up ? Direction : direction,
                Direction.Left => Direction == Direction.Right ? Direction : direction,
                _ => Direction == Direction.Left ? Direction : direction,
            };
        }

        public void KeyScanner() {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Up)) {
                ChangeDirection(Direction.Up);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Down)) {
                ChangeDirection(Direction.Down);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Left)) {
                ChangeDirection(Direction.Left);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Right)) {
                ChangeDirection(Direction.Right);
            }
        }
    }
}