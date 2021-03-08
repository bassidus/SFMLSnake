using SFML.Graphics;

namespace SFMLSnake {

    public class Grid : GameObject {

        public Grid(Position location) : base(location) {
            Location = location;
            Sprite = new Sprite(new Texture("images/white.png"));
        }
    }
}