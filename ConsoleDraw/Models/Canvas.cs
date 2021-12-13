using System.Text;

namespace ConsoleDraw.Models
{
    /// <summary>
    /// Represent a 2D canvas for the drawing.
    /// </summary>
    public class Canvas
    {
        public static readonly char horizontalChar = '-';
        public static readonly char verticalChar = '|';
        public static readonly char emptyChar = ' ';
        public static readonly char lineChar = 'x';

        private readonly int _columns;
        private readonly int _rows;

        public char[,] cells;

        /// <summary>
        /// The width of the drawing area of the canvas.
        /// </summary>
        public int Width { get; }

        /// <summary>
        /// The height of the drawing area of the canvas.
        /// </summary>
        public int Height { get; }

        /// <summary>
        /// Constructor that creates a <see cref="Canvas"/> with a specified <paramref name="height"/> and <paramref name="width"/>.
        /// </summary>
        public Canvas(int width, int height)
        {
            _columns = width + 2;
            _rows = height + 2;
            Width = width;
            Height = height;
            cells = new char[_columns, _rows];

            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _columns; j++)
                {
                    if (i == 0 || i == _rows - 1)
                        cells[j, i] = horizontalChar;
                    else if (j == 0 || j == _columns - 1)
                        cells[j, i] = verticalChar;
                    else
                        cells[j, i] = emptyChar;
                }
            }
        }

        /// <summary>
        /// Creates a representation of the <see cref="Canvas"/> in string form.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _columns; j++)
                {
                    sb.Append(cells[j, i]);
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
