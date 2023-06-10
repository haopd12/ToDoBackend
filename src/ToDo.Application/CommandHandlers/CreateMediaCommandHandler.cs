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
	public class CreateMediaCommandHandler: IRequestHandler<CreateMediaCommand, bool>
	{
		private readonly IMediaTranmissionRepository _mediaRepository;
		private readonly IWorkRepository _workRepository;
		private readonly IUserWorkRepository _userWorkRepository;
		private readonly IMapper _mapper;
		private readonly IMaxUnitOfWork _unitOfWork;
		private readonly IAppSession _appSession;

		public CreateMediaCommandHandler(IMediaTranmissionRepository mediaTranmissionRepository, IWorkRepository workRepository, IUserWorkRepository userWorkRepository, IMapper mapper,
			IMaxUnitOfWork unitOfWork, IAppSession appSession)
		{
			_workRepository = workRepository;
			_mediaRepository = mediaTranmissionRepository;
			_userWorkRepository = userWorkRepository;
			_mapper = mapper;
			_unitOfWork = unitOfWork;
			_appSession = appSession;
		}
		public async Task<bool> Handle(CreateMediaCommand request, CancellationToken cancellationToken)
		{
			var input = _mapper.Map<MediaTranmission>(request);
			input.TenantId = _appSession.TenantId;

			await _mediaRepository.InsertAsync(input);

			await _unitOfWork.SaveChangesAsync();

			return true;
		}
	}
}
