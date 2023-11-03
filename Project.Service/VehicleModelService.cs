﻿using AutoMapper;
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

        public async Task<VehicleModelModel> GetVModelById(int id)
        {
            var entity = await _unitOfWork.VehicleModels.GetByIdAsync(id);
            var newEntity = _mapper.Map<VehicleModelModel>(entity);
            return newEntity;
        }

        public async Task<VehicleModelEntity> GetVModelWithVMakeById(int id)
        {
            var entity = await _unitOfWork.VehicleModels.GetVehicleModelWithVehicleMakeById(id);
            return entity;
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