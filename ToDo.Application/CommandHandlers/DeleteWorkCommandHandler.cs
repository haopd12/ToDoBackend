using App.Shared.Uow;
using MediatR;
using ToDo.Domain.Entities;
using ToDo.Domain.Repositories;

using ToDo.Domain.ICommands;


namespace ToDo.Application.CommandHandlers
{
	public class DeleteWorkCommandHandler: IRequestHandler<DeleteWorkCommand, bool>
	{
		private readonly IWorkRepository _workRepository;
		private readonly IUserWorkRepository _userWorkRepository;
		private readonly IMaxUnitOfWork _unitOfWork;

		public DeleteWorkCommandHandler(IWorkRepository WorkRepository, IUserWorkRepository UserWorkRepository,
			IMaxUnitOfWork unitOfWork)
		{
			_workRepository = WorkRepository;
			_userWorkRepository = UserWorkRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<bool> Handle(DeleteWorkCommand command, CancellationToken cancellationToken)
		{
			var Work = await _workRepository.FirstOrDefaultAsync(x => x.Id == command.Id);
			if (Work == null)
			{
				return false;
			}
			var userWorks = await _userWorkRepository.GetAllListAsync(x => x.WId == command.Id);
			if (userWorks == null)
			{
				return false;
			}
			foreach (UserWork userWork in userWorks)
			{
				_userWorkRepository.Delete(userWork);
			}
			_workRepository.Delete(Work);

			await _unitOfWork.SaveChangesAsync();

			return true;
		}
	}
}
