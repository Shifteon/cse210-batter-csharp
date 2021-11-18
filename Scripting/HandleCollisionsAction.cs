using System.Collections.Generic;
using cse210_batter_csharp.Casting;
using cse210_batter_csharp.Services;


namespace cse210_batter_csharp.Scripting
{
    /// <summary>
    /// An action to draw all of the actors in the game.
    /// </summary>
    public class HandleCollisionsAction : Action
    {
        private PhysicsService _physicsService;
        private AudioService _audioService;
        public HandleCollisionsAction(PhysicsService physicsService, AudioService audioService)
        {
            _physicsService = physicsService;
            _audioService = audioService;
        }
        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            Ball ball = (Ball)cast["balls"][0];
            Actor paddle = cast["paddle"][0];

            if (_physicsService.IsCollision(ball, paddle))
            {
                _audioService.PlaySound(Constants.SOUND_BOUNCE);
                ball.BounceVertical();
            }

            List<Brick> bricksToRemove = new List<Brick>();
            foreach (Brick brick in cast["bricks"])
            {
                if (_physicsService.IsCollision(ball, brick))
                {
                    _audioService.PlaySound(Constants.SOUND_BOUNCE);
                    ball.BounceVertical();
                    bricksToRemove.Add(brick);
                }
            }

            foreach (Brick brick in bricksToRemove)
            {
                if (cast["bricks"].Contains(brick))
                    cast["bricks"].Remove(brick);
            }
            
        }

    }
}