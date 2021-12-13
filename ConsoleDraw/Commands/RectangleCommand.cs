using ConsoleDraw.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleDraw.Commands
{
    /// <summary>
    /// Command that draws a rectangles on a <see cref="Canvas"/>.
    /// </summary>
    public class RectangleCommand : ICommand
    {
        private int _x1, _x2, _y1, _y2;
        private Canvas _canvas;
        private readonly ICommand _lineCommand;

        public RectangleCommand(Canvas canvas, ICommand lineCommand)
        {
            _canvas = canvas ?? throw new ArgumentNullException("should create a canvas first");
            _lineCommand = lineCommand;
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

            if ((_x1 > _x2) || (_y1 > _y2))
                throw new ArgumentException("arguments wrong: x1 > x2 or y1 > y2");
        }

        public Canvas ExecuteCommand()
        {
            // Draw 4 lines
            var x1 = _x1.ToString();
            var x2 = _x2.ToString();
            var y1 = _y1.ToString();
            var y2 = _y2.ToString();
            _lineCommand.CommandValidation(new List<string>() { x1, y1, x2, y1 });
            _lineCommand.ExecuteCommand();
            _lineCommand.CommandValidation(new List<string>() { x1, y2, x2, y2 });
            _lineCommand.ExecuteCommand();
            _lineCommand.CommandValidation(new List<string>() { x1, y1, x1, y2 });
            _lineCommand.ExecuteCommand();
            _lineCommand.CommandValidation(new List<string>() { x2, y1, x2, y2 });
            _lineCommand.ExecuteCommand();
            return _canvas;
        }
    }
}
