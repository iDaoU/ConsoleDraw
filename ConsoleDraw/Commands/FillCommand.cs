using ConsoleDraw.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleDraw.Commands
{
    /// <summary>
    /// Command that acts as like the Paint fill-bucket command.
    /// </summary>
    public class FillCommand : ICommand
    {
        private int _x, _y;
        private char _newColour;
        private Canvas _canvas;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="canvas"></param>
        public FillCommand(Canvas canvas)
        {
            _canvas = canvas ?? throw new ArgumentNullException("should create a canvas first");
        }

        public void CommandValidation(List<string> cmd)
        {
            if (cmd == null || !cmd.Any())
                throw new ArgumentNullException("missing command arguments");

            if (cmd.Count != 3)
                throw new ArgumentException("only accept 3 arguments: x,y,c");

            if ((!int.TryParse(cmd[0], out _x) || _x <= 0) || (_x > _canvas.Width))
                throw new ArgumentException($"x coordinates should range from 1 - {_canvas.Width}");

            if ((!int.TryParse(cmd[1], out _y) || _y <= 0) || (_y > _canvas.Height))
                throw new ArgumentException($"y coordinates should range from 1 - {_canvas.Height}");

            if ((_x > _canvas.Width) || (_y > _canvas.Height))
                throw new ArgumentException("point should be in the canvas");

            if (!char.TryParse(cmd[2], out _newColour))
                throw new ArgumentException("colour should be a char");
        }

        public Canvas ExecuteCommand()
        {
            // Classic BFS
            var frontier = new Queue<Point>();
            frontier.Enqueue(new Point(_x, _y));
            var traversed = new HashSet<Point>();
            var targetColour = _canvas.cells[_x, _y];

            while (frontier.Any())
            {
                var current = frontier.Dequeue();
                if (!traversed.Add(current) ||
                    _canvas.cells[current.X, current.Y] != targetColour ||
                    _canvas.cells[current.X, current.Y] == Canvas.horizontalChar ||
                    _canvas.cells[current.X, current.Y] == Canvas.verticalChar)
                {
                    continue;
                }

                // Get neighbours
                _canvas.cells[current.X, current.Y] = _newColour;
                frontier.Enqueue(new Point(current.X - 1, current.Y));
                frontier.Enqueue(new Point(current.X + 1, current.Y));
                frontier.Enqueue(new Point(current.X, current.Y - 1));
                frontier.Enqueue(new Point(current.X, current.Y + 1));
            }

            return _canvas;
        }
    }
}
