using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLGen.Core
{
    public interface IWhere : ICondition
    {
        IWhere Contians(string searchcondition, params string[] columnlist);
        IWhere Contians(string searchcondition, string language, params string[] columnlist);
        IWhere Contains(IFullTextSearchCondition searchcondition, params string[] columnlist);
        IWhere Contains(IFullTextSearchCondition searchcondition, string language, params string[] columnlist);
        IWhere FreeText(IFullTextSearchCondition searchterm, params string[] columnlist);
        IWhere FreeText(string searchterm, string language, params string[] columnlist);
    }
}

