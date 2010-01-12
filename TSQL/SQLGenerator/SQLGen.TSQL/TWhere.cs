using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLGen.Core;

namespace SQLGen.TSQL
{
    public class TWhere : IWhere
    {
        StringBuilder sql;
        public TWhere()
        {
            sql = new StringBuilder();
        }

        public TWhere(StringBuilder sb)
        {
            sql = sb;
        }

        public override string ToString()
        {
            return this.sql.ToString();
        }

        #region IWhere Members

        public IWhere Where(string condition)
        {
            if (!string.IsNullOrEmpty(condition))
            {
                this.sql.AppendFormat(" WHERE {0}", condition);
            }
            else
            {
                sql.AppendFormat(" WHERE");
                throw new Exception(string.Format("WHERE condition cannot be null or empty \r\n'{0}'", this.sql.ToString()));
            }
            return this;
        }

        public ICondition Equal(string condition)
        {
            if (!string.IsNullOrEmpty(condition))
            {
                this.sql.AppendFormat(" = {0}", condition);
            }
            else
            {
                sql.AppendFormat(" =");
                throw new Exception(string.Format("= expression cannot be null or empty \r\n'{0}'", this.sql.ToString()));
            }
            return this;
        }

        public ICondition In(string items)
        {
            if (!string.IsNullOrEmpty(items))
            {
                this.sql.AppendFormat(" IN ({0})",items.Trim(')','('));
            }
            else
            {
                this.sql.AppendFormat(" IN ");
                throw new Exception(string.Format("IN items cannot be null or empty \r\n'{0}'", this.sql.ToString()));
            }
            return this;
        }

        public ICondition In(List<string> items)
        {
            string valstring = Utility.GetListAsString<string>(items, ",");
            if (!string.IsNullOrEmpty(valstring))
            {
                this.sql.AppendFormat(" IN ({0})", valstring);
            }
            else
            {
                this.sql.AppendFormat(" IN ");
                throw new Exception(string.Format("IN items cannot be null or empty \r\n'{0}'", this.sql.ToString()));
            }
            return this;
        }

        public ICondition In(string[] items)
        {
            string valstring = Utility.GetListAsString<string>(items.ToList(), ",");
            if (!string.IsNullOrEmpty(valstring))
            {
                this.sql.AppendFormat(" IN ({0})", valstring);
            }
            else
            {
                this.sql.AppendFormat(" IN ");
                throw new Exception(string.Format("IN items cannot be null or empty \r\n'{0}'", this.sql.ToString()));
            }
            return this;
        }

        public ICondition GreaterThan(string condition)
        {
            if (!string.IsNullOrEmpty(condition))
            {
                this.sql.AppendFormat(" > {0}", condition);
            }
            else
            {
                sql.AppendFormat(" >");
                throw new Exception(string.Format("> expression cannot be null or empty \r\n'{0}'", this.sql.ToString()));
            }
            return this;
        }

        public ICondition GreaterThanOrEqual(string condition)
        {
            if (!string.IsNullOrEmpty(condition))
            {
                this.sql.AppendFormat(" >= {0}", condition);
            }
            else
            {
                sql.AppendFormat(" >=");
                throw new Exception(string.Format(">= expression cannot be null or empty \r\n'{0}'", this.sql.ToString()));
            }
            return this;
        }

        public ICondition LessThan(string condition)
        {
            if (!string.IsNullOrEmpty(condition))
            {
                this.sql.AppendFormat(" < {0}", condition);
            }
            else
            {
                sql.AppendFormat(" <");
                throw new Exception(string.Format("< expression cannot be null or empty \r\n'{0}'", this.sql.ToString()));
            }
            return this;
        }

        public ICondition LessThanOrEqual(string condition)
        {
            if (!string.IsNullOrEmpty(condition))
            {
                this.sql.AppendFormat(" <= {0}", condition);
            }
            else
            {
                sql.AppendFormat(" <=");
                throw new Exception(string.Format("<= expression cannot be null or empty \r\n'{0}'", this.sql.ToString()));
            }
            return this;
        }

        public ICondition NotEqual(string condition)
        {
            if (!string.IsNullOrEmpty(condition))
            {
                this.sql.AppendFormat(" != {0}", condition);
            }
            else
            {
                sql.AppendFormat(" !=");
                throw new Exception(string.Format("!= expression cannot be null or empty \r\n'{0}'", this.sql.ToString()));
            }
            return this;
        }

        public ICondition Like(string condition)
        {
            if (!string.IsNullOrEmpty(condition))
            {
                this.sql.AppendFormat(" LIKE '{0}'", condition.Trim('\''));
            }
            else
            {
                sql.AppendFormat(" LIKE");
                throw new Exception(string.Format("LIKE expression cannot be null or empty \r\n'{0}'", this.sql.ToString()));
            }
            return this;
        }

        public ICondition NotLike(string condition)
        {
            if (!string.IsNullOrEmpty(condition))
            {
                this.sql.AppendFormat(" NOT LIKE '{0}'", condition.Trim('\''));
            }
            else
            {
                sql.AppendFormat(" NOT LIKE");
                throw new Exception(string.Format("NOT LIKE expression cannot be null or empty \r\n'{0}'", this.sql.ToString()));
            }
            return this;
        }

        public ICondition And(string condition)
        {
            if (!string.IsNullOrEmpty(condition))
            {
                this.sql.AppendFormat(" AND {0}", condition);
            }
            else
            {
                sql.AppendFormat(" AND");
                throw new Exception(string.Format("AND condition cannot be null or empty \r\n'{0}'", this.sql.ToString()));
            }
            return this;
        }

        public ICondition Or(string condition)
        {
            if (!string.IsNullOrEmpty(condition))
            {
                this.sql.AppendFormat(" OR {0}", condition);
            }
            else
            {
                sql.AppendFormat(" OR");
                throw new Exception(string.Format("OR condition cannot be null or empty \r\n'{0}'", this.sql.ToString()));
            }
            return this;
        }

        public ICondition Between(string firstValue, string secondValue)
        {
            if (string.IsNullOrEmpty(firstValue) || string.IsNullOrEmpty(secondValue))
            {
                this.sql.AppendFormat(" BETWEEN {0} AND {1}", firstValue, secondValue);
                throw new Exception(string.Format("BETWEEN parameters cannot be null or empty \r\n'{0}'", this.sql.ToString()));
            }
            else
            {
                this.sql.AppendFormat(" BETWEEN {0} AND {1}", firstValue, secondValue);
            }
            return this;
        }       
        
        public ICondition Exists(string subquery)
        {
            if (!string.IsNullOrEmpty(subquery))
            {
                this.sql.AppendFormat(" EXISTS ({0})", subquery.Trim(')', '('));
            }
            else
            {
                throw new Exception(string.Format("subquery cannot be null or empty \r\n'{0}'", this.sql.ToString()));
            }
            return this;
        }

        public ICondition NotExists(string subquery)
        {
            if (!string.IsNullOrEmpty(subquery))
            {
                this.sql.AppendFormat(" NOT EXISTS ({0})", subquery.Trim(')', '('));
            }
            else
            {
                throw new Exception(string.Format("subquery cannot be null or empty \r\n'{0}'", this.sql.ToString()));
            }
            return this;
        }        

        public ICondition Expression(string expression)
        {
            if (!string.IsNullOrEmpty(expression))
            {
                this.sql.AppendFormat(" {0}", expression);
            }
            else
            {
                throw new Exception(string.Format("Expression cannot be null or empty \r\n'{0}'", this.sql.ToString()));
            }
            return this;
        }

        #endregion

        #region IWhere Members

        public IWhere Contians(string searchcondition, params string[] columnlist)
        {
            this.sql.AppendFormat(" CONTAINS({0},'{1}')", Utility.GetListAsString<string>(columnlist.ToList(), ","), searchcondition.Trim('\''));
            return this;
        }

        public IWhere Contians(string searchcondition, string language, params string[] columnlist)
        {
            this.sql.AppendFormat(" CONTAINS({0},'{1}',LANGUAGE N'{2}')", Utility.GetListAsString<string>(columnlist.ToList(), ","), searchcondition.Trim('\''), language);
            return this;
        }

        public IWhere Contains(IFullTextSearchCondition searchcondition, params string[] columnlist)
        {
            this.sql.AppendFormat(" CONTAINS({0},{1})", Utility.GetListAsString<string>(columnlist.ToList(), ","), searchcondition.ToString());
            return this;
        }

        public IWhere Contains(IFullTextSearchCondition searchcondition, string language, params string[] columnlist)
        {
            this.sql.AppendFormat(" CONTAINS({0},{1},LANGUAGE N'{2}')", Utility.GetListAsString<string>(columnlist.ToList(), ","), searchcondition.ToString(), language);
            return this;
        }

        public IWhere FreeText(IFullTextSearchCondition searchterm, params string[] columnlist)
        {
            this.sql.AppendFormat(" FREETEXT({0},'{1}')", Utility.GetListAsString<string>(columnlist.ToList(), ","), searchterm.ToString());
            return this;
        }

        public IWhere FreeText(string searchterm, string language, params string[] columnlist)
        {
            if(!string.IsNullOrEmpty(language))
                this.sql.AppendFormat(" FREETEXT({0},{1},LANGUAGE N'{2}')", Utility.GetListAsString<string>(columnlist.ToList(), ","), searchterm, language);
            else
                this.sql.AppendFormat(" FREETEXT({0},'{1}')", Utility.GetListAsString<string>(columnlist.ToList(), ","), searchterm);
            return this;
        }

        #endregion
    }
}
