using SFML.System;
using SFML.Window;

namespace SFMLSnake {

    public class Game {

        public void RunGame() {
            var timer = 0f;
            var delay = 0.1f;
            var world = new GameWorld(30, 20);
            var window = new Window(world, 16);
            var clock = new Clock();
            var snake = world.Add(new Snake(world.RandomPosition()));
            
            
            while (window.IsOpen) {
                window.SetTitle($"SFML Snake by Bassidus and Han 2021 - Score: {world.Score}");
                float time = clock.ElapsedTime.AsSeconds();
                clock.Restart();
                timer += time;

                // exit check
                if (Keyboard.IsKeyPressed(Keyboard.Key.Q) ||
                    Keyboard.IsKeyPressed(Keyboard.Key.Escape)) {
                    window.Close();
                }

                if (timer > delay) {
                    timer = 0;
                    world.Update();
                    window.Render();
                }
            }
        }
    }
}