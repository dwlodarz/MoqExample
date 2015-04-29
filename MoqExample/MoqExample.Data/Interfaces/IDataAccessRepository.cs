using System;
namespace MoqExample.Data.Interfaces
{
    public interface IDataAccessRepository
    {
        bool CheckTheComplexType<T>(T input) where T : class;
        int GetNoOfProjects(int id);
    }
}
