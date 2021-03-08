using SFML.Graphics;

namespace SFMLSnake {

    public class Tail : GameObject {

        public Tail(Position location) : base(location) {
            Location = location;
            Sprite = new Sprite(new Texture("images/dark_green.png"));
        }
    }
}