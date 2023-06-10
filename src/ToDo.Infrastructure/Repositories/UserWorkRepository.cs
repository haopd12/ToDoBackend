using App.Shared.Repositories;
using ToDo.Domain.Entities;
using ToDo.Domain.Repositories;
using ToDo.Infrastructure.Contexts;

namespace ToDo.Infrastructure.Repositories
{
	public class UserWorkRepository : RepositoryBase<ToDoContext, UserWork, long>, IUserWorkRepository
	{
		public UserWorkRepository(ToDoContext context) : base(context)
		{
		}
	}
}