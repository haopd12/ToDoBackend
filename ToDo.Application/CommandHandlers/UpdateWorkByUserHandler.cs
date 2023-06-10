using App.Shared.Uow;
using AutoMapper;
using MediatR;
using ToDo.Domain.Entities;
using ToDo.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ToDo.Domain.ICommands;
using App.Shared.AppSession;

namespace ToDo.Application.CommandHandlers
{
	public class UpdateWorkByUserHandler: IRequestHandler<UpdateWorkByUserCommand, bool>
	{
		private readonly IUserWorkRepository _userWorkRepository;

		private readonly IMapper _mapper;
		private readonly IMaxUnitOfWork _unitOfWork;
		private readonly IAppSession _appSession;

		public UpdateWorkByUserHandler(IUserWorkRepository userWorkRepository, IMapper mapper,
			IMaxUnitOfWork unitOfWork, IAppSession appSession)
		{
		
			_userWorkRepository = userWorkRepository;
			_mapper = mapper;
			_unitOfWork = unitOfWork;
			_appSession = appSession;
		}

		public async Task<bool> Handle(UpdateWorkByUserCommand request, CancellationToken cancellationToken)
		{
			var input = _mapper.Map<UserWork>(request);

			var user = await _userWorkRepository.FirstOrDefaultAsync(x => x.Id == input.Id);
			user.Status = input.Status;
			user.UId = input.UId;
			user.WId = input.WId;
			user.permision = input.permision;
			user.TaskTitle = input.TaskTitle;


			await _userWorkRepository.UpdateAsync(user);

			await _unitOfWork.SaveChangesAsync();

			return true;
		}
	}
}
