using SFML.Graphics;

namespace SFMLSnake {
    struct Snake {

        public Location Location { get; set; }
        public Directions Direction { get; private set; }

        public Sprite Head { get; }
        public Sprite Body { get; }
        public Snake(Location location) {
            Location = location;
            Direction = Directions.Up;
            Head = new Sprite(new Texture("red.png"));
            Body = new Sprite(new Texture("green.png"));
        }

        public void Update() {
            Move();
            OtherSide();
        }

        private void Move() {
            switch (Direction) {
                case Directions.Up:
                    Location -= new Location(0, 1);
                    break;

                case Directions.Down:
                    Location += new Location(0, 1);
                    break;

                case Directions.Left:
                    Location -= new Location(1, 0);
                    break;

                default:
                    Location += new Location(1, 0);
                    break;
            }
        }

        private void OtherSide() {
            if (Location.X > Program.Width) {
                Location = new Location(0, Location.Y);
            }
            if (Location.X < 0) {
                Location = new Location(Program.Width, Location.Y);
            }
            if (Location.Y > Program.Height) {
                Location = new Location(Location.X, 0);
            }
            if (Location.Y < 0) {
                Location = new Location(Location.X, Program.Height);
            }
        }

        public void ChangeDirection(Directions direction) {
            switch (direction) {
                case Directions.Up:
                    if (Direction != Directions.Down) {
                        Direction = Directions.Up;
                    }
                    break;
                case Directions.Down:
                    if (Direction != Directions.Up) {
                        Direction = Directions.Down;
                    }
                    break;
                case Directions.Left:
                    if (Direction != Directions.Right) {
                        Direction = Directions.Left;
                    }
                    break;
                case Directions.Right:
                    if (Direction != Directions.Left) {
                        Direction = Directions.Right;
                    }
                    break;
                default:
                    break;
            }


        }

    }
}