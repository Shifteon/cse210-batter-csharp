using System.Collections.Generic;
using cse210_batter_csharp.Casting;
using cse210_batter_csharp.Services;


namespace cse210_batter_csharp.Scripting
{
    /// <summary>
    /// An action to draw all of the actors in the game.
    /// </summary>
    public class HandleOffScreenAction : Action
    {
        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            foreach (Ball b in cast["balls"])
            {
                if (b.GetX() <= 0 || b.GetX() > Constants.MAX_X)
                    b.BounceHorizontal();
                if (b.GetY() > Constants.MAX_Y)
                    b.kill();
                if (b.GetY() <= 0)
                    b.BounceVertical();
            }
            Actor paddle = cast["paddle"][0];
            // Keep the paddle from going off screen
            if (paddle.GetX() > Constants.MAX_X - Constants.PADDLE_WIDTH)
                paddle.SetPosition(new Point(Constants.MAX_X - Constants.PADDLE_WIDTH, paddle.GetY()));
            if (paddle.GetX() <= 0)
                paddle.SetPosition(new Point(0, paddle.GetY()));
        }

    }
}