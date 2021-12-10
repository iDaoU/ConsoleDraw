using ConsoleDraw.Models;
using System.Collections.Generic;

namespace ConsoleDraw.Commands
{
    public interface ICommand
	{
		void CommandValidation(List<string> cmd);

		Canvas ExecuteCommand();
	}
}
