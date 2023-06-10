using App.Shared.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Entities;
using ToDo.Domain.Repositories;
using ToDo.Infrastructure.Contexts;

namespace ToDo.Infrastruture.Repositories
{
	public class MediaWorkRepository: RepositoryBase<ToDoContext, MediaWork,long>, IMediaWorkRepository
	{
		public MediaWorkRepository(ToDoContext context) : base(context) { }
}
}
