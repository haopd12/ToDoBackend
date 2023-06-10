using App.Shared.Uow;
using MediatR;
using ToDo.Domain.Entities;
using ToDo.Domain.Repositories;
using ToDo.Domain.ICommands;
using ToDo.Domain.Repositories;
using App.Shared.AppSession;

namespace ToDo.Application.CommandHandlers
{
	public class DeleteTaskOfWorkCommandHandler : IRequestHandler<DeleteTaskOfWorkCommand, bool>
	{
		private readonly IWorkRepository _workRepository;
		private readonly IUserWorkRepository _userWorkRepository;
		private readonly IAppSession _appSession;
		private readonly IMaxUnitOfWork _unitOfWork;

		public DeleteTaskOfWorkCommandHandler(IWorkRepository WorkRepository, IUserWorkRepository UserWorkRepository,
			IMaxUnitOfWork unitOfWork, IAppSession appSession)
		{
			_workRepository = WorkRepository;
			_userWorkRepository = UserWorkRepository;
			_unitOfWork = unitOfWork;
			_appSession = appSession;
		}

		public async Task<bool> Handle(DeleteTaskOfWorkCommand command, CancellationToken cancellationToken)
		{
			var userWork = await _userWorkRepository.FirstOrDefaultAsync(x => x.Id == command.Id);
			if (userWork == null)
			{
				return false;
			}
			
			_userWorkRepository.Delete(userWork);
		

			await _unitOfWork.SaveChangesAsync();

			return true;
		}
	}
}
