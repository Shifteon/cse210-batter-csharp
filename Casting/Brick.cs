namespace cse210_batter_csharp.Casting
{
    public class Brick : Actor
    {
        public Brick(int x, int y)
        {
            _position = new Point(x, y);
            SetImage(Constants.IMAGE_BRICK);
            _height = Constants.BRICK_HEIGHT;
            _width = Constants.BRICK_WIDTH;
        }
    }
}