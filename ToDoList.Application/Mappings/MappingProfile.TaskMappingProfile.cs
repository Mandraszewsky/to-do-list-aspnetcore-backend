using ToDoList.Application.Dtos;
using ToDoList.Application.Tasks.Commands.CreateTask;
using ToDoList.Application.Tasks.Commands.UpdateTask;

namespace ToDoList.Application.Mappings;

public partial class MappingProfile
{
    private void TaskMappingProfile()
    {
        CreateMap<CreateTaskCommand, Domain.Models.Task>();
        CreateMap<Domain.Models.Task, CreateTaskCommand>();
        CreateMap<Domain.Models.Task, TaskDto>();
        CreateMap<TaskDto, Domain.Models.Task>();
        CreateMap<UpdateTaskCommand, Domain.Models.Task>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Title, opt =>
            {
                opt.PreCondition(src => src.Task.Title != null);
                opt.MapFrom(src => src.Task.Title);
            })
            .ForMember(dest => dest.Summary, opt =>
            {
                opt.PreCondition(src => src.Task.Summary != null);
                opt.MapFrom(src => src.Task.Summary);
            })
            .ForMember(dest => dest.DueDate, opt =>
            {
                opt.MapFrom(src => src.Task.DueDate);
            });
    }
}
