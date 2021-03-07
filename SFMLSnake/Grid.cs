using SFML.Graphics;

namespace SFMLSnake {
    struct Grid {
        public Location Location { get; set; }
        public Sprite Sprite { get; }
        public Grid(Location location) {
            Location = location;
            Sprite = new Sprite(new Texture("images\\white.png"));
        }
    }
}