using System.Collections.Generic;
using cse210_batter_csharp.Casting;
using cse210_batter_csharp.Services;


namespace cse210_batter_csharp.Scripting
{
    /// <summary>
    /// An action to draw all of the actors in the game.
    /// </summary>
    public class MoveActorsAction : Action
    {
        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            foreach (List<Actor> actors in cast.Values)
            {
                foreach (Actor actor in actors)
                {
                    actor.MoveNext();
                }
            }
        }

    }
}