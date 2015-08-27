using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Euler
{
    public interface EulerProblem
    {
        string Run();

        int Number { get; }

        string Description { get; }
    }
}
