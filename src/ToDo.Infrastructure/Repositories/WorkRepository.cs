using App.Shared.Repositories;
using ToDo.Domain.Entities;
using ToDo.Domain.Repositories;
using ToDo.Infrastructure.Contexts;

namespace ToDo.Infrastructure.Repositories
{
	public class WorkRepository: RepositoryBase<ToDoContext, Work, long>, IWorkRepository
	{
		public WorkRepository(ToDoContext context) : base(context)
		{
		}
	}
}
