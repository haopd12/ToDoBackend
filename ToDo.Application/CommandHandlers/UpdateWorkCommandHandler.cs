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
	public class UpdateWorkCommandHandler: IRequestHandler<UpdateWorkCommand, bool>
	{
		private readonly IUserWorkRepository _userWorkRepository;
		private readonly IWorkRepository _workRepository;
		private readonly IMapper _mapper;
		private readonly IMaxUnitOfWork _unitOfWork;
		private readonly IAppSession _appSession;

		public UpdateWorkCommandHandler(IUserWorkRepository userWorkRepository, IWorkRepository workRepository, IMapper mapper,
			IMaxUnitOfWork unitOfWork, IAppSession appSession)
		{
			_userWorkRepository = userWorkRepository;
			_workRepository = workRepository;
			_mapper = mapper;
			_unitOfWork = unitOfWork;
			_appSession = appSession;
		}

		public async Task<bool> Handle(UpdateWorkCommand request, CancellationToken cancellationToken)
		{
			var input = _mapper.Map<Work>(request);

			var work = await _workRepository.FirstOrDefaultAsync(x =>x.Id == input.Id);
			work.TitleWork = input.TitleWork;
			work.StartTime = input.StartTime;
			work.EndTime = input.EndTime;
			
			await _workRepository.UpdateAsync(work);

			await _unitOfWork.SaveChangesAsync();

			return true;
		}
	}
}
