using MoqExample.Data.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoqExample.Data.Implementation
{
    public class DataAccessRepository : MoqExample.Data.Interfaces.IDataAccessRepository
    {
        public int GetNoOfProjects(int id)
        {
            return 3;
        }

        public bool CheckTheComplexType<T>(T input) where T:class
        {
            return input != null;
        }
    }
}
