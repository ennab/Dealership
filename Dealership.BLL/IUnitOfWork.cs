using Dealership.BLL.Repositories;
using System;

namespace Dealership.BLL
{
    public interface IUnitOfWork : IDisposable
    {
        IMakeRepository Makes { get; }
        int Complete();
    }
}
