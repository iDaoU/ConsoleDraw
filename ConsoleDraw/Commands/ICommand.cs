using ConsoleDraw.Models;
using System.Collections.Generic;

namespace ConsoleDraw.Commands
{
    /// <summary>
    /// Interface defining a command
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Parses command arguments and vaidates them against the command criteria
        /// </summary>
        /// <param name="cmd"></param>
        void CommandValidation(List<string> cmd);

        /// <summary>
        /// Executes the command
        /// </summary>
        /// <returns></returns>
        Canvas ExecuteCommand();
    }
}
