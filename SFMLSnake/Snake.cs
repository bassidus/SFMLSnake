using SFML.Graphics;
using SFML.System;

namespace SFMLSnake
{
    public class Snake : GameObject
    {
        public Directions Direction { get; private set; }
        public Snake(Position location):base(location)
        {
            Direction = Directions.Up;
            Sprite = new Sprite(new Texture("images/red.png"));
        }

        public override void Update()
        {
            Location += Direction switch
            {
                Directions.Up => new Position(0, -1),
                Directions.Down => new Position(0, 1),
                Directions.Left => new Position(-1, 0),
                _ => new Position(1, 0)
            };
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
    }
}