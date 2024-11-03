using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[assembly:LevelOfParallelism(4)]
[assembly: Parallelizable(ParallelScope.Fixtures)]

namespace PlaywrightTests
{
    public class AssemblyInfo
    {
    }
}