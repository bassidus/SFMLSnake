using SFML.System;
using SFML.Window;

namespace SFMLSnake
{

    public class Game
    {

        public void RunGame()
        {
            var timer = 0f;
            var delay = 0.1f;
            var world = new GameWorld(30, 20, 16, 5);
            var window = new Window(world);
            var clock = new Clock();
            var snake = world.Add(new Snake(world.RandomPosition()));

            while (window.IsOpen)
            {
                window.SetTitle($"SFML Snake by Bassidus and Han 2021 - Score: {world.Score}");
                timer += clock.ElapsedTime.AsSeconds();
                clock.Restart();

                window.DispatchEvents();
                    // exit check
                if (Keyboard.IsKeyPressed(Keyboard.Key.Q) || Keyboard.IsKeyPressed(Keyboard.Key.Escape))
                {
                    window.Close();
                }

                if (timer > delay / world.FrameRate)
                {
                    timer = 0;
                    world.Update();
                }
                window.Render();
            }
        }
    }
}