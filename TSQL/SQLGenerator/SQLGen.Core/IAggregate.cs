using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLGen.Core
{
    public interface IAggregate
    {
        IAggregate Max(string column);
        IAggregate Min(string column);
        IAggregate Avg(string column);
        IAggregate Count(string column);
        IAggregate Sum(string column);
        IAggregate As(string alias);
    }
}
