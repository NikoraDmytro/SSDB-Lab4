using AutoMapper;
using SSDB_Lab4.Abstractions.Persistence;

namespace SSDB_Lab4.Application.Services;

public abstract class BaseService
{
    protected readonly IUnitOfWork UnitOfWork;
    protected readonly IMapper Mapper;

    protected BaseService(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        UnitOfWork = unitOfWork;
        Mapper = mapper;
    }
}