using AutoMapper;

namespace ToDoList.Application.Mappings;

public partial class MappingProfile : Profile
{
    public MappingProfile()
    {
        TaskMappingProfile();
    }
}
