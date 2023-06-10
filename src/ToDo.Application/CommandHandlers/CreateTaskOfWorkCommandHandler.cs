using App.Shared.AppSession;
using App.Shared.Uow;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Entities;
using ToDo.Domain.ICommands;
using ToDo.Domain.Repositories;

namespace ToDo.Application.CommandHandlers
{
	public class CreateTaskOfWorkCommandHandler: IRequestHandler<CreateTaskOfWorkCommand, bool>
	{ 
		private readonly IWorkRepository _workRepository;
		private readonly IUserWorkRepository _userWorkRepository;
		private readonly IMapper _mapper;
		private readonly IMaxUnitOfWork _unitOfWork;
		private readonly IAppSession _appSession;

		public CreateTaskOfWorkCommandHandler(IWorkRepository workRepository, IUserWorkRepository userWorkRepository, IMapper mapper,
			IMaxUnitOfWork unitOfWork, IAppSession appSession)
		{
			_workRepository = workRepository;
			_userWorkRepository = userWorkRepository;
			_mapper = mapper;
			_unitOfWork = unitOfWork;
			_appSession = appSession;
		}
		public async Task<bool> Handle(CreateTaskOfWorkCommand request, CancellationToken cancellationToken)
		{
			var input = _mapper.Map<UserWork>(request);
			input.TenantId = _appSession.TenantId;

			await _userWorkRepository.InsertAsync(input);

			await _unitOfWork.SaveChangesAsync();

			return true;
		}
	}
}
