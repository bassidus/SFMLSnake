using SFML.Graphics;

namespace SFMLSnake {
    struct Snake {

        public Location Location { get; set; }
        public Sprite Head { get; }
        public Sprite Body { get; }
        public Snake(Location location) {
            Location = location;
            Head = new Sprite(new Texture("red.png"));
            Body = new Sprite(new Texture("green.png"));
        }

    }
}