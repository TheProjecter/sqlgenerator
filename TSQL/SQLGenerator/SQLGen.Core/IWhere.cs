using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLGen.Core
{
    public interface IWhere : ICondition
    {
        IWhere Contains(IFullTextSearch ftsearch);
        IWhere Contains(string ftsearch);
        IWhere FreeText(IFullTextSearch ftsearch);
        IWhere FreeText(string ftsearch);
    }
}

