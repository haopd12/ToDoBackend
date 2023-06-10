using App.Shared.AppSession;
using App.Shared.Uow;
using AutoMapper;
using MediatR;
using ToDo.Domain.Entities;
using ToDo.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ToDo.Domain.ICommands;


namespace ToDo.Application.CommandHandlers
{
	public class CreateWorkWithNameHandler: IRequestHandler<CreateWorkWithNameCommand, bool>
	{
		private readonly IWorkRepository _workRepository;
		private readonly IUserWorkRepository _userWorkRepository;
		private readonly IMapper _mapper;
		private readonly IMaxUnitOfWork _unitOfWork;
		private readonly IAppSession _appSession;
		private readonly IMediaWorkRepository _mediaRepository;

		public CreateWorkWithNameHandler( IWorkRepository workRepository, IUserWorkRepository userWorkRepository, IMapper mapper,
			IMaxUnitOfWork unitOfWork, IAppSession appSession, IMediaWorkRepository mediaRepository)
		{
			_workRepository = workRepository;

			_userWorkRepository = userWorkRepository;
			_mediaRepository = mediaRepository;
			_mapper = mapper;
			_unitOfWork = unitOfWork;
			_appSession = appSession;
		}

		public async Task<bool> Handle(CreateWorkWithNameCommand request, CancellationToken cancellationToken)
		{
			if (request.BossIds.Count == 0 || request.EmployeeIds.Count == 0)
				return false;

			var input = _mapper.Map<Work>(request);
			var work = await _workRepository.FirstOrDefaultAsync(x =>  x.TitleWork == input.TitleWork);
			if (work != null)
				return false;
			long countWork = await _workRepository.InsertAndGetIdAsync(input);

			foreach (long id in request.BossIds)
			{
				
				var userWork = _mapper.Map<UserWork>(request);
					userWork.TenantId = _appSession.TenantId;
					userWork.UId = id;
					userWork.WId = countWork;
					userWork.permision = Permision.Boss;
					await _userWorkRepository.InsertAsync(userWork);
				
			}

			foreach (long id in request.EmployeeIds)
			{
				var userWork = _mapper.Map<UserWork>(request);

					userWork.TenantId = _appSession.TenantId;
					userWork.UId = id;
					userWork.WId = countWork;
					userWork.permision = Permision.Employee;
					await _userWorkRepository.InsertAsync(userWork);
				
			}

			foreach (long id in request.ViewerIds)
			{

				var userWork = _mapper.Map<UserWork>(request);
			
					userWork.TenantId = _appSession.TenantId;
					userWork.UId = id;
					userWork.WId = countWork;
					userWork.permision = Permision.Viewer;
					await _userWorkRepository.InsertAsync(userWork);
				
			}	

			foreach (var media in request.mediaWorks)
			{
				var inputM = _mapper.Map<MediaWork>(media);
				inputM.WId = countWork;
				await _mediaRepository.InsertAsync(inputM);
			}
			await _unitOfWork.SaveChangesAsync();
			return true;
		}

	}
}
