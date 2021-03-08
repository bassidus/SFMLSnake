﻿using SFML.Graphics;
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
                Direction.UpRight => Direction == Direction.DownLeft ? Direction : direction,
                Direction.Right => Direction == Direction.Left ? Direction : direction,
                Direction.DownRight => Direction == Direction.UpLeft ? Direction : direction,
                Direction.Down => Direction == Direction.Up ? Direction : direction,
                Direction.DownLeft => Direction == Direction.UpRight ? Direction : direction,
                Direction.Left => Direction == Direction.Right ? Direction : direction,
                _ => Direction == Direction.DownRight ? Direction : direction,
            };
        }
        public void KeyScanner()
        {
            var keyUp = Keyboard.IsKeyPressed(Keyboard.Key.Up);
            var keyRight = Keyboard.IsKeyPressed(Keyboard.Key.Right);
            var keyDown = Keyboard.IsKeyPressed(Keyboard.Key.Down);
            var keyLeft = Keyboard.IsKeyPressed(Keyboard.Key.Left);

            if (keyUp && !keyRight && !keyDown && !keyLeft)
            {
                ChangeDirection(Direction.Up);
            }
            else if (keyUp && keyRight && !keyDown && !keyLeft)
            {
                ChangeDirection(Direction.UpRight);
            }
            else if (!keyUp && keyRight && !keyDown && !keyLeft)
            {
                ChangeDirection(Direction.Right);
            }
            else if (!keyUp && keyRight && keyDown && !keyLeft)
            {
                ChangeDirection(Direction.DownRight);
            }
            else if (!keyUp && !keyRight && keyDown && !keyLeft)
            {
                ChangeDirection(Direction.Down);
            }
            else if (!keyUp && !keyRight && keyDown && keyLeft)
            {
                ChangeDirection(Direction.DownLeft);
            }
            else if (!keyUp && !keyRight && !keyDown && keyLeft)
            {
                ChangeDirection(Direction.Left);
            }
            else if (keyUp && !keyRight && !keyDown && keyLeft)
            {
                ChangeDirection(Direction.UpLeft);
            }
        }
        public override void Update(int movement)
        {
            Position += Direction switch
            {
                Direction.Up => new Position(0, -movement),
                Direction.UpRight => new Position((int)(movement * 0.7071f), (int)(-movement * 0.7071f)),
                Direction.Right => new Position(movement, 0),
                Direction.DownRight => new Position((int)(movement * 0.7071f), (int)(movement * 0.7071f)),
                Direction.Down => new Position(0, movement),
                Direction.DownLeft => new Position((int)(-movement * 0.7071f), (int)(movement * 0.7071f)),
                Direction.Left => new Position(-movement, 0),
                _ => new Position((int)(-movement * 0.7071f), (int)(-movement * 0.7071f))
            };
        }
    }
}