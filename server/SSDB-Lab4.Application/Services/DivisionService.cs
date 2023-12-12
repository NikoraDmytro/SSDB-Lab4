using AutoMapper;
using SSDB_Lab4.Abstractions.Application;
using SSDB_Lab4.Abstractions.Persistence;
using SSDB_Lab4.Common;
using SSDB_Lab4.Common.DTOs.Division;
using SSDB_Lab4.Common.Exceptions;
using SSDB_Lab4.Domain.entities;

namespace SSDB_Lab4.Application.Services
{
    public class DivisionService : BaseService, IDivisionService
    {
        public DivisionService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper)
        {
        }

        public async Task<IEnumerable<DivisionDto>> GetDivisionsAsync()
        {
            var divisions = await UnitOfWork
                .DivisionRepository
                .GetAllAsync();

            var divisionDtos = Mapper.Map<IEnumerable<DivisionDto>>(divisions);

            return divisionDtos;
        }

        public async Task<DivisionDto?> GetDivisionByIdAsync(int id)
        {
            var division = await UnitOfWork
                .DivisionRepository
                .GetByIdAsync(id);

            if (division is null)
            {
                throw new NotFoundException($"Division was not found!");
            }

            var divisionDto = Mapper.Map<DivisionDto>(division);

            return divisionDto;
        }

        private async Task ThrowIfDuplicate(int id, String name)
        {
            var duplicate = await UnitOfWork
                .DivisionRepository
                .GetByNameAsync(name);

            if (duplicate != null && duplicate.Id != id)
            {
                throw new BadRequestException($"Division with name {name} already exists");
            }
        }

        public async Task<DivisionDto> CreateDivisionAsync(CreateDivisionDto createDivisionDto)
        {
            await ThrowIfDuplicate(-1, createDivisionDto.Name!);
            
            var division = Mapper.Map<Division>(createDivisionDto);

            
            await UnitOfWork.DivisionRepository.AddAsync(division);
            await UnitOfWork.SaveAsync();

            var divisionDto = Mapper.Map<DivisionDto>(division);

            return divisionDto;
        }

        public async Task UpdateDivisionAsync(int id, UpdateDivisionDto updateDivisionDto)
        {
            await ThrowIfDuplicate(id, updateDivisionDto.Name!);
            
            var division = await UnitOfWork
                .DivisionRepository
                .GetByIdAsync(id);

            if (division is null)
            {
                throw new NotFoundException($"Division was not found!");
            }
            if (updateDivisionDto.MinWeight >= updateDivisionDto.MaxWeight)
            {
                throw new BadRequestException("Max weight must be bigger than min weight!");
            }
            if (updateDivisionDto.MinAge >= updateDivisionDto.MaxAge)
            {
                throw new BadRequestException("Max age must be bigger than min age!");
            }

            division.Name = updateDivisionDto.Name;
            division.MinWeight = updateDivisionDto.MinWeight;
            division.MaxWeight = updateDivisionDto.MaxWeight;
            division.MinAge = updateDivisionDto.MinAge 
                              ?? division.MinAge;
            division.MaxAge = updateDivisionDto.MaxAge 
                              ?? division.MaxAge;
            division.Sex = Enum.Parse<Sex>(updateDivisionDto.Sex!);

            UnitOfWork.DivisionRepository.Update(division);
            await UnitOfWork.SaveAsync();
        }

        public async Task DeleteDivisionAsync(int id)
        {
            var division = await UnitOfWork
                .DivisionRepository
                .GetByIdAsync(id);

            if (division is null)
            {
                throw new NotFoundException($"Division was not found!");
            }

            UnitOfWork.DivisionRepository.Delete(division);
            await UnitOfWork.SaveAsync();
        }
    }
}
