using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLib.DAL
{
    public class RepoFactory
    {
        public static IRepo GetRepo() => new DatabaseRepo();
    }
}
