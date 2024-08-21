using AutoMapper;
using CommandHelper.Dtos;
using CommandHelper.Models;

namespace CommandHelper.Profiles
{
    public class CommandProfile : Profile
    {
        public CommandProfile()
        {    //Source -> Target
            CreateMap<Command, CommandReadDto>();
            CreateMap<CommandCreateDto, Command>();
            CreateMap<CommandUpdateDto, Command>();
            CreateMap<Command, CommandUpdateDto>();
        }
    }
}
