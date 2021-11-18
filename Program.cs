using System;
using cse210_batter_csharp.Services;
using cse210_batter_csharp.Casting;
using cse210_batter_csharp.Scripting;
using System.Collections.Generic;

namespace cse210_batter_csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the cast
            Dictionary<string, List<Actor>> cast = new Dictionary<string, List<Actor>>();

            // Bricks
            cast["bricks"] = new List<Actor>();

            for (int x = 25; x < Constants.MAX_X - 50; x += Constants.BRICK_WIDTH + Constants.BRICK_SPACE)
            {
                for (int y = 0; y < Constants.MAX_Y - 400; y += Constants.BRICK_HEIGHT + Constants.BRICK_SPACE)
                {
                    cast["bricks"].Add(new Brick(x, y));
                }
            }

            // The Ball (or balls if desired)
            cast["balls"] = new List<Actor>();
            cast["balls"].Add(new Ball(400, 300));
            // The paddle
            cast["paddle"] = new List<Actor>();
            cast["paddle"].Add(new Paddle(Constants.MAX_X / 2, Constants.MAX_Y - 30));

            // Create the script
            Dictionary<string, List<Action>> script = new Dictionary<string, List<Action>>();

            OutputService outputService = new OutputService();
            InputService inputService = new InputService();
            PhysicsService physicsService = new PhysicsService();
            AudioService audioService = new AudioService();

            script["output"] = new List<Action>();
            script["input"] = new List<Action>();
            script["update"] = new List<Action>();

            DrawActorsAction drawActorsAction = new DrawActorsAction(outputService);
            script["output"].Add(drawActorsAction);

            script["update"].Add(new MoveActorsAction());
            script["update"].Add(new HandleOffScreenAction());
            script["update"].Add(new HandleCollisionsAction(physicsService, audioService));

            script["input"].Add(new ControlActorsAction(inputService));
            // TODO: Add something fun

            // Start up the game
            outputService.OpenWindow(Constants.MAX_X, Constants.MAX_Y, "Batter", Constants.FRAME_RATE);
            audioService.StartAudio();
            audioService.PlaySound(Constants.SOUND_START);

            Director theDirector = new Director(cast, script);
            theDirector.Direct();

            audioService.StopAudio();
        }
    }
}
