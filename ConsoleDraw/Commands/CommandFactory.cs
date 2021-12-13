using ConsoleDraw.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleDraw.Commands
{
    /// <summary>
    /// A class that acts as a multiplexer for commands.
    /// </summary>
    public class CommandFactory
    {
        /// <summary>
        /// Creates a command based on the first argument or <paramref name="cmd"/> that typically modifies <paramref name="canvas"/>.
        /// </summary>
        public static ICommand CreateCommandInstance(List<string> cmd, Canvas canvas)
        {
            if (cmd == null || !cmd.Any())
                throw new ArgumentNullException("wrong command");

            switch (cmd[0])
            {
                case "C":
                    return new CreateCommand();
                case "L":
                    return new LineCommand(canvas);
                case "R":
                    return new RectangleCommand(canvas, new LineCommand(canvas));
                case "B":
                    return new FillCommand(canvas);
                case "Q":
                    return new QuitCommand();
                default:
                    throw new ArgumentException($"Not supported command: {cmd[0]}");
            }
        }
    }
}
