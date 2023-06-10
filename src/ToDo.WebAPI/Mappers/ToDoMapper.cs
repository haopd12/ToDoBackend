using AutoMapper;
using ToDo.Domain.Entities;
using System.CodeDom;
using ToDo.Domain.Dtos;

using ToDo.Domain.ICommands;
using ToDo.Domain.IQueries;

namespace ToDo.WebAPI.Mappers
{
	public class ToDoMapper: Profile
	{
		public ToDoMapper() 
		{
			
			CreateMap<CreateWorkWithNameCommand, Work>().ReverseMap();
			CreateMap<CreateWorkWithNameInput, CreateWorkWithNameCommand>().ReverseMap();
			CreateMap<UpdateWorkByUserCommand, UserWork>().ReverseMap();
			CreateMap<UpdateWorkByUserCommand, Work>().ReverseMap();
			CreateMap<UpdateWorkByUserInput, UpdateWorkByUserCommand>().ReverseMap();
			CreateMap<UpdateWorkCommand, Work>().ReverseMap();
			CreateMap<UpdateWorkDto, UpdateWorkCommand>().ReverseMap();
			CreateMap<DeleteWorkDto, DeleteWorkCommand>().ReverseMap();
			CreateMap<DeleteWorkDto, DeleteTaskOfWorkCommand>().ReverseMap();

			CreateMap<GetListWorkByUserInput, GetListWorkByUserQuery>().ReverseMap();
			
			CreateMap<CreateWorkWithNameCommand, UserWork>().ReverseMap();
			CreateMap<CreateTaskOfWorkCommand, UserWork>().ReverseMap();
			CreateMap<CreateTaskOfWorkInput, CreateTaskOfWorkCommand>().ReverseMap();

			CreateMap<CreateMediaCommand, MediaTranmission>().ReverseMap();
			CreateMap<CreateMediaDto, CreateMediaCommand>().ReverseMap();
			CreateMap<UpdateMediaCommand, MediaTranmission>().ReverseMap();
			CreateMap<UpdateMediaDto, UpdateMediaCommand>().ReverseMap();
			CreateMap<DeleteMediaDto, DeleteMediaCommand>().ReverseMap();
			
			CreateMap<GetListMediaDto, GetListMediaQuery>().ReverseMap();
			CreateMap<GetListMediaByWorkInput, GetListMediaByWorkQuery>().ReverseMap();

			CreateMap<CreateMediaWorkCommand, MediaWork>().ReverseMap();
			CreateMap<CreateMediaWorkDto, CreateMediaWorkCommand>().ReverseMap();
			CreateMap<UpdateMediaWorkCommand, MediaWork>().ReverseMap();
			CreateMap<UpdateMediaWorkDto, UpdateMediaWorkCommand>().ReverseMap();
			CreateMap<CreateMediaWorkDto, MediaWork>().ReverseMap();

			CreateMap<DeleteMediaWorkDto, DeleteMediaWorkCommand>().ReverseMap();
			CreateMap<GetListMediaWorkDto, GetListMediaWorkQuery>().ReverseMap();
		}
	}
}
