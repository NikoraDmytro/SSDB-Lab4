using AutoMapper;
using SSDB_Lab4.Common.RequestFeatures;

namespace SSDB_Lab4.Application.MappingProfiles;

public class PagedListProfile: Profile
{
    public PagedListProfile()
    {
        CreateMap(typeof(PagedList<>), typeof(PagedList<>));
    }
}