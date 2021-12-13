using ConsoleDraw.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleDraw.Commands
{
    /// <summary>
    /// Command that draws a line on a <see cref="Canvas"/>.
    /// </summary>
    public class LineCommand : ICommand
    {
        private int _x1, _x2, _y1, _y2;
        private Canvas _canvas;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="canvas"></param>
        public LineCommand(Canvas canvas)
        {
            _canvas = canvas ?? throw new ArgumentNullException("should create a canvas first");
        }

        public void CommandValidation(List<string> cmd)
        {
            if (cmd == null || !cmd.Any())
                throw new ArgumentNullException("missing command arguments");

            if (cmd.Count != 4)
                throw new ArgumentException("only accept 4 arguments: x1,x2,y1,y2");

            if ((!int.TryParse(cmd[0], out _x1) || _x1 <= 0) || (_x1 > _canvas.Width) ||
                (!int.TryParse(cmd[2], out _x2) || _x2 <= 0) || (_x2 > _canvas.Width))
                throw new ArgumentException($"x coordinates should range from 1 - {_canvas.Width}");

            if ((!int.TryParse(cmd[1], out _y1) || _y1 <= 0) || (_y1 > _canvas.Height) ||
                (!int.TryParse(cmd[3], out _y2) || _y2 <= 0) || (_y2 > _canvas.Height))
                throw new ArgumentException($"y coordinates should range from 1 - {_canvas.Height}");

            if ((_x1 != _x2) && (_y1 != _y2))
                throw new ArgumentException("currently only	horizontal or vertical lines are supported.");
        }

        public Canvas ExecuteCommand()
        {
            if (_x1 == _x2)
            {
                //draw vertical
                if (_y1 > _y2)
                {
                    var temp = _y1;
                    _y1 = _y2;
                    _y2 = temp;
                }

                for (int i = _y1; i <= _y2; i++)
                    _canvas.cells[_x1, i] = Canvas.lineChar;
            }
            else if (_y1 == _y2)
            {
                //draw horizontal
                if (_x1 > _x2)
                {
                    var temp = _x1;
                    _x1 = _x2;
                    _x2 = temp;
                }

                for (int i = _x1; i <= _x2; i++)
                    _canvas.cells[i, _y1] = Canvas.lineChar;
            }

            return _canvas;
        }
    }
}
