using SFML.Graphics;

namespace SFMLSnake {
    struct Fruit {
        public Location Location { get; set; }
        public Sprite Sprite { get; }
        public Fruit(Location location) {
            Location = location;
            Sprite = new Sprite(new Texture("images\\red.png"));
        }
    }
}