using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLGen.Core
{
    public interface ICondition
    {
        ICondition Expression(string expression);
        ICondition Equal(string condition);
        ICondition In(string items);
        ICondition In(List<string> items);
        ICondition In(string[] items);
        ICondition GreaterThan(string condition);
        ICondition GreaterThanOrEqual(string condition);      
        ICondition LessThan(string condition);
        ICondition LessThanOrEqual(string condition);
        ICondition NotEqual(string condition);
        ICondition Like(string condition);
        ICondition NotLike(string condition);
        ICondition And(string condition);
        ICondition Or(string condition);
        ICondition Between(string firstValue, string secondValue);
        ICondition Exists(string subquery);
        ICondition NotExists(string subquery);
        
    }
}
