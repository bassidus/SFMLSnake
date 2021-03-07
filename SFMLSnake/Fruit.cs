using SFML.Graphics;

namespace SFMLSnake {
    struct Fruit {
        public Location Location { get; set; }
        public Sprite Sprite { get; }
        public Fruit(Location location) {
            Location = location;
            Sprite = new Sprite(new Texture("red.png"));
        }
    }

    struct Grid {
        public Location Location { get; set; }
        public Sprite Sprite { get; }
        public Grid(Location location) {
            Location = location;
            Sprite = new Sprite(new Texture("white.png"));
        }
    }
}