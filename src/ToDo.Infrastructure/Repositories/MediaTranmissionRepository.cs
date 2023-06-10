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
	public class MediaTranmissionRepository: RepositoryBase<ToDoContext,MediaTranmission,long>, IMediaTranmissionRepository
	{
		public MediaTranmissionRepository(ToDoContext context) : base(context) { }
	}
}
