namespace ConsoleDraw.Models
{
    /// <summary>
    /// A struct that represents a 2D point on the canvas
    /// </summary>
    public struct Point
    {
        public readonly int X;

        public readonly int Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
