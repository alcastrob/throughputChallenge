using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Ports
{
    interface IRandom
    {
        int generateRnd(int minValue, int maxValue);
        int generateRnd(int maxValue);
    }
}
