using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Ports
{
    public interface IRandom
    {
        int generateRnd(int minValue, int maxValue);
        int generateRnd(int maxValue);
    }
}
