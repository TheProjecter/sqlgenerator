using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLGen.Core
{
    public interface IDelete
    {
        IFrom DeleteFrom(string tableName);
    }
}
