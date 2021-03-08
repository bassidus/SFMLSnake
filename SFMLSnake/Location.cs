using System;

namespace SFMLSnake {
    public struct Location {
        public readonly float X, Y;
        public Location(float x, float y) {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj) {
            return obj is Location location &&
                   X == location.X &&
                   Y == location.Y;
        }

        public override int GetHashCode() {
            return HashCode.Combine(X, Y);
        }

        public static Location operator +(Location a, Location b) {
            return new Location(a.X + b.X, a.Y + b.Y);
        }
        public static Location operator -(Location a, Location b) {
            return new Location(a.X - b.X, a.Y - b.Y);
        }
        public static bool operator ==(Location a, Location b) {
            return a.Equals(b);
        }
        public static bool operator !=(Location a, Location b) {
            return !(a == b);
        }
    }
}