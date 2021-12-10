using System.Text;

namespace ConsoleDraw.Models
{
    public class Canvas
	{
		public static readonly char horizontalChar = '-';
		public static readonly char verticalChar = '|';
		public static readonly char emptyChar = ' ';
		public static readonly char lineChar = 'x';

		public readonly int _width;

		public readonly int _height;

		public char[,] cells;

		public Canvas(int width, int height)
		{
			_width = width + 2;
			_height = height + 2;
			cells = new char[_width, _height];

			for (int i = 0; i < _height; i++)
			{
				for (int j = 0; j < _width; j++)
				{
					if (i == 0 || i == _height - 1)
						cells[j, i] = horizontalChar;
					else if (j == 0 || j == _width - 1)
						cells[j, i] = verticalChar;
					else
						cells[j, i] = emptyChar;
				}
			}
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < _height; i++)
			{
				for (int j = 0; j < _width; j++)
				{
					sb.Append(cells[j, i]);
				}
				sb.AppendLine();
			}
			return sb.ToString();
		}
	}
}
