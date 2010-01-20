using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLGen.Core
{
    public interface ICTE
    {
        void As(string statement);
        void As(ISelect statement);
        void As(ISQL statement);
    }
}
