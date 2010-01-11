using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLGen.Core
{
    public interface IFullTextSearchCondition
    {
        IFullTextSearchCondition SimpleTerm(string term);
        IFullTextSearchCondition FormsOfINFLECTIONAL (params string[] term);
        IFullTextSearchCondition FormsOfTHESAURUS(params string[] term);
        IFullTextSearchCondition And(string searchcondition);
        IFullTextSearchCondition AndNot(string searchcondition);
        IFullTextSearchCondition Or(string searchcondition);
        IFullTextSearchCondition Near(string term);
        IFullTextSearchCondition IsAbout(Dictionary<string, float> weightedterms);
    }
}
