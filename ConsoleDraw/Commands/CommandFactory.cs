using ConsoleDraw.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleDraw.Commands
{
    public class CommandFactory
	{
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
					return new RectangleCommand(canvas);
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
