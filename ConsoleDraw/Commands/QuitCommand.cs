using ConsoleDraw.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleDraw.Commands
{
    /// <summary>
    /// Command that closes the application.
    /// </summary>
    public class QuitCommand : ICommand
    {
        public void CommandValidation(List<string> cmd)
        {
            if (cmd == null)
                throw new ArgumentNullException("missing command arguments");

            if (cmd.Any())
                throw new ArgumentException("should have no arguments");
        }

        public Canvas ExecuteCommand()
        {
            Environment.Exit(Environment.ExitCode);
            return null;
        }
    }
}
