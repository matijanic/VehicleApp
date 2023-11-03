using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository.Common
{
    public interface IUnitOfWork :IDisposable
    {
        IVehicleMakeRepository VehicleMakes { get; }

        IVehicleModelRepository VehicleModels { get; }

        Task<int> CommitAsync();

    }
}
