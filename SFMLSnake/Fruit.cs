using SFML.Graphics;

namespace SFMLSnake {

    public class Fruit : GameObject {

        public Fruit(Position location) : base(location) {
            Sprite = new Sprite(new Texture("images/red.png"));
        }
    }
}