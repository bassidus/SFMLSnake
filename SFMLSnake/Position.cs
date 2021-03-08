using System;

namespace SFMLSnake {

    public struct Position {
        public readonly float X, Y;

        public Position(float x, float y) {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj) => obj is Position location && X == location.X && Y == location.Y;

        public static Position operator +(Position a, Position b) => new Position(a.X + b.X, a.Y + b.Y);

        public static Position operator -(Position a, Position b) => new Position(a.X - b.X, a.Y - b.Y);

        public static bool operator ==(Position a, Position b) => a.Equals(b);

        public static bool operator !=(Position a, Position b) => !(a == b);

        public override int GetHashCode() => HashCode.Combine(X, Y);
    }
}