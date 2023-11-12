using AutoMapper;
using Project.DAL;
using Project.Model;
using Project.Repository.Common;
using Project.Service.Common;


namespace Project.Service
{
    public class VehicleModelService : IVehicleModelService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VehicleModelService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateVModel(VehicleModelModel entity)
        {
            var newEntity = _mapper.Map<VehicleModelEntity>(entity);
            await _unitOfWork.VehicleModels.AddAsync(newEntity);

            await _unitOfWork.CommitAsync();
            
            
        }

        public async Task <bool> DeleteVModel(int id)
        {
            var entity = await _unitOfWork.VehicleModels.GetByIdAsync(id);
            if(entity == null)
            {
                return false;
            }

            await _unitOfWork.VehicleModels.DeleteAsync(id);
            await _unitOfWork.CommitAsync();
            return true;

            
        }

        public async Task<List<VehicleModelModel>> GetAllVModels()
        {
            var  listAll = await _unitOfWork.VehicleModels.GetAllAsync();
            var newList = _mapper.Map<List<VehicleModelModel>>(listAll);
            return newList;
        }

        public async Task<List<VehicleModelEntity>> GetAllWithVMakes()
        {
            var listaAllAndModels = await _unitOfWork.VehicleModels.GetAllWithVehicleMakes();
            return listaAllAndModels;
        }

        public async Task<List<VehicleModelModel>> GetFilterByName(string? Name = null)
        {
            var list =await _unitOfWork.VehicleModels.GetFilterByNameAsync(Name);

            
            var newList= _mapper.Map<List<VehicleModelModel>>(list);

            return newList;
        }

        public async Task<List<VehicleModelModel>> GetSortByName(string? Name = null, bool isAscending = true)
        {
            var list = await _unitOfWork.VehicleModels.GetSortByNameAsync(Name, isAscending);
            

            var newList=  _mapper.Map <List<VehicleModelModel>>(list);

            return newList;
        }

        public async Task<VehicleModelModel> GetVModelById(int id)
        {
            var entity = await _unitOfWork.VehicleModels.GetByIdAsync(id);
            var newEntity = _mapper.Map<VehicleModelModel>(entity);
            return newEntity;
        }

        public async Task<VehicleModelModel> GetVModelWithVMakeById(int id)
        {
            var entity = await _unitOfWork.VehicleModels.GetVehicleModelWithVehicleMakeByIdAsync(id);

            if(entity == null)
            {
                return null;
            }

            var newEntity= _mapper.Map<VehicleModelModel>(entity);

            return newEntity;
        }

        public async  Task<List<VehicleModelModel>> PagingVehicleModels(int pageNumber = 1, int pageSize = 1000)
        {
            var list = await _unitOfWork.VehicleModels.PagingVehicleModels(pageNumber, pageSize);

            return _mapper.Map<List<VehicleModelModel>>(list);
        }

        public async Task UpdateVModel(int id, VehicleModelModel input)
        {
            var entityToBeUpdted = await _unitOfWork.VehicleModels.GetByIdAsync(id);

            entityToBeUpdted.Name = input.Name;
            entityToBeUpdted.Abrv = input.Abrv;
            entityToBeUpdted.MakeId = input.MakeId;

            var updatedEntity = _mapper.Map<VehicleModelEntity>(entityToBeUpdted);
            await _unitOfWork.CommitAsync();
        }

      
    }
}