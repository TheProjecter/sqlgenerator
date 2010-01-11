using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLGen.Core;

namespace SQLGen.TSQL
{
    public class TFullTextSearchCondition :IFullTextSearchCondition
    {
        StringBuilder condition;
        public TFullTextSearchCondition(StringBuilder sb)
        {
            condition = sb;
        }
        public TFullTextSearchCondition()
        {
            condition = new StringBuilder();
        }

        public override string ToString()
        {
            return this.condition.ToString();
        }

        #region IFullTextSearchCondition Members

        public IFullTextSearchCondition SimpleTerm(string term)
        {
            this.condition.AppendFormat(" {0}",term);
            return this;
        }

        public IFullTextSearchCondition FormsOfINFLECTIONAL(params string[] term)
        {
            this.condition.AppendFormat(" FORMSOF(INFLECTIONAL,{0})",Utility.GetListAsString<string>(term.ToList(),","));
            return this;
        }

        public IFullTextSearchCondition FormsOfTHESAURUS(params string[] term)
        {
            this.condition.AppendFormat(" FORMSOF(THESAURUS,{0})", Utility.GetListAsString<string>(term.ToList(), ","));
            return this;
        }

        public IFullTextSearchCondition And(string searchcondition)
        {
            this.condition.AppendFormat(" AND {0}", searchcondition);
            return this;
        }

        public IFullTextSearchCondition AndNot(string searchcondition)
        {
            this.condition.AppendFormat(" AND NOT {0}", searchcondition);
            return this;
        }

        public IFullTextSearchCondition Or(string searchcondition)
        {
            this.condition.AppendFormat(" OR {0}", searchcondition);
            return this;
        }

        public IFullTextSearchCondition Near(string term)
        {
            this.condition.AppendFormat(" NEAR {0}", term);
            return this;
        }

        public IFullTextSearchCondition IsAbout(Dictionary<string, float> weightedterms)
        {
            List<string> terms = new List<string>();
            foreach (KeyValuePair<string, float> kvp in weightedterms)
            {
                terms.Add(string.Format("{0} weight({1})",kvp.Key,kvp.Value.ToString().Substring(kvp.Value.ToString().IndexOf("."))));
            }
            this.condition.AppendFormat(" 'ISABOUT({0})'", Utility.GetListAsString<string>(terms,","));
            return this;
        }

        #endregion
    }
}
