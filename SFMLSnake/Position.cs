using System;

namespace SFMLSnake {
    public struct Position {
        public readonly float X, Y;
        public Position(float x, float y) {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj) {
            return obj is Position location &&
                   X == location.X &&
                   Y == location.Y;
        }

        public override int GetHashCode() {
            return HashCode.Combine(X, Y);
        }

        public static Position operator +(Position a, Position b) {
            return new Position(a.X + b.X, a.Y + b.Y);
        }
        public static Position operator -(Position a, Position b) {
            return new Position(a.X - b.X, a.Y - b.Y);
        }
        public static bool operator ==(Position a, Position b) {
            return a.Equals(b);
        }
        public static bool operator !=(Position a, Position b) {
            return !(a == b);
        }
    }
}