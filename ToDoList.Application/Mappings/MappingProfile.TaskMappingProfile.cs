using ToDoList.Application.CQRS.Tasks.Commands.CreateTask;
using ToDoList.Application.CQRS.Tasks.Commands.UpdateTask;
using ToDoList.Application.CQRS.Tasks.Queries.GetFilteredTasks;
using ToDoList.Application.Dtos;

namespace ToDoList.Application.Mappings;

public partial class MappingProfile
{
    private void TaskMappingProfile()
    {
        CreateMap<CreateTaskCommand, Domain.Models.Task>();
        CreateMap<Domain.Models.Task, CreateTaskCommand>();

        CreateMap<Domain.Models.Task, TaskDto>();
        CreateMap<TaskDto, Domain.Models.Task>();

        CreateMap<CreateTaskDto, Domain.Models.Task>();
        CreateMap<Domain.Models.Task, CreateTaskDto>();

        CreateMap<UpdateTaskDto, Domain.Models.Task>();
        CreateMap<Domain.Models.Task, UpdateTaskDto>();

        CreateMap<TaskFilterDto, Domain.Models.Task>();
        CreateMap<Domain.Models.Task, TaskFilterDto>();

        CreateMap<GetFilteredTaskQuery, Domain.Models.Task>();

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
