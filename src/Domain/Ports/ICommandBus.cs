using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Ports
{
    interface ICommandBus
    {
        public void execute(string command);
    }
}
