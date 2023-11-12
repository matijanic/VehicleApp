using AutoMapper;
using Project.DAL;
using Project.Model;
using Project.Repository.Common;
using Project.Service.Common;


namespace Project.Service
{
    public class VehicleMakeService : IVehicleMakeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VehicleMakeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper =  mapper;
        }
        public async Task CreateVMake(VehicleMakeModel entity)
        {
            var newEntity = _mapper.Map<VehicleMakeEntity>(entity);
            await _unitOfWork.VehicleMakes.AddAsync(newEntity);
            await _unitOfWork.CommitAsync();
            
        }

        public async Task<bool> DeleteVMake(int id)
        {

            var entity = await _unitOfWork.VehicleMakes.GetByIdAsync(id);

            if(entity == null)
            {
                return false;
            }

            await _unitOfWork.VehicleMakes.DeleteAsync(id);
            await _unitOfWork.CommitAsync();

            return true;

           
        }


        public async Task<List<VehicleMakeModel>> GetAllVMakes()
        {
          var listAll = await _unitOfWork.VehicleMakes.GetAllAsync();
          var newList = _mapper.Map<List<VehicleMakeModel>>(listAll);
          return newList;
        }

        public async Task<List<VehicleMakeModel>> GetAllWithModels()
        {
            var listAllWithModels= await _unitOfWork.VehicleMakes.GetAllDetailsWithModelsAsync();
             var newList = _mapper.Map<List<VehicleMakeModel>> (listAllWithModels);
            return newList;
            
        }

        public async Task<VehicleMakeModel> GetVMakeById(int id)
        {
           var entity= await _unitOfWork.VehicleMakes.GetByIdAsync(id);
           var newEntity = _mapper.Map<VehicleMakeModel>(entity);
            return newEntity;
        }

       

        public async Task UpdateVMake(int id, VehicleMakeModel input)
        {

            var entityToBeUpdated = await _unitOfWork.VehicleMakes.GetByIdAsync(id);

            entityToBeUpdated.Name = input.Name;
            entityToBeUpdated.Abrv = input.Abrv;

            var updatedEntity = _mapper.Map<VehicleMakeEntity>(entityToBeUpdated);

            await _unitOfWork.CommitAsync();

        }

       public async Task<VehicleMakeModel> GetVMakeWithModelsById(int id)
        {
            var entity = await _unitOfWork.VehicleMakes.GetByIdAsync(id);
            var newEntity = _mapper.Map<VehicleMakeModel>(entity);
            return newEntity;
        }

        public async Task<List<VehicleMakeModel>> GetFilterByName(string? Name = null)
        {

            var list = await _unitOfWork.VehicleMakes.GetFilterByNameAsync(Name);

            var newList =  _mapper.Map<List<VehicleMakeModel>>(list);

            return newList;

        }

        public async Task<List<VehicleMakeModel>> GetSortByName(string? Name = null, bool isAscending = true)
        {
           
            var list = await _unitOfWork.VehicleMakes.GetSortByNameAsync(Name, isAscending);

            var newList = _mapper.Map<List<VehicleMakeModel>>(list);

            return newList;

        }

        public async Task<List<VehicleMakeModel>> PagingVehicleMakes(int pageNumber = 1, int pageSize = 1000)
        {
            var list = await _unitOfWork.VehicleMakes.PagingVehicleMakesAsync(pageNumber, pageSize);

            return _mapper.Map<List<VehicleMakeModel>>(list);

        }
    }
}