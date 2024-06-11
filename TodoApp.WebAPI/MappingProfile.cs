using AutoMapper;
using TodoApp.Core.DTOs;
using TodoApp.Core.Entities;

namespace TodoApp.WebAPI;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateTodoDto, Todo>().ReverseMap();
        CreateMap<UpdateTodoDto, Todo>().ReverseMap();
    }   
}