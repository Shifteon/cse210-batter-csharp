using System;

namespace cse210_batter_csharp.Casting
{
    /// <summary>
    /// The score board in the top portion of the game.
    /// </summary>
    public class ScoreBoard : Actor
    {
        private int _points = 0;

        public ScoreBoard()
        {
            _position = new Point(1, Constants.MAX_Y - 25);
            
            UpdateText();
        }

        /// <summary>
        /// Increments the points by the amount specified and updates the
        /// text.
        /// </summary>
        /// <param name="points"></param>
        public void AddPoints(int points)
        {
            _points += points;
            UpdateText();
        }

        /// <summary>
        /// Decrements the points by the amount specified and updates the
        /// text.
        /// </summary>
        /// <param name="points"></param>
        public void MinusPoints(int points)
        {
            _points -= points;
            UpdateText();
        }

        /// <summary>
        /// Updates the text to reflect the new points amount.
        /// This should be called whenever the points are updated.
        /// </summary>
        private void UpdateText()
        {
            _text = $"Score: {_points}";
        }
    }

}