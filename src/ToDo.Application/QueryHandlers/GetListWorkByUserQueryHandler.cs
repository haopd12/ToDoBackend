using Abp.Collections.Extensions;
using Abp.Domain.Entities;
using Abp.Extensions;
using App.Shared.AppSession;
using App.Shared.Dtos;
using MediatR;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Entities;
using ToDo.Domain.IQueries;
using ToDo.Domain.Repositories;

namespace ToDo.Application.QueryHandlers
{
	public class GetListWorkByUserQueryHandler : IRequestHandler<GetListWorkByUserQuery, PagedResultDto<UserWork>>
	{
		private readonly IWorkRepository _workRepository;
		private readonly IUserWorkRepository _userWorkRepository;

		private readonly IAppSession _appSession;

		public GetListWorkByUserQueryHandler(IWorkRepository workRepository, IUserWorkRepository userWorkRepository, IAppSession appSession)
		{
			_workRepository = workRepository;
			_userWorkRepository = userWorkRepository;
			_appSession = appSession;
		}

		public async Task<PagedResultDto<UserWork>> Handle(GetListWorkByUserQuery request, CancellationToken cancellationToken)
		{
			var wUser = await _workRepository.FirstOrDefaultAsync(x => x.TitleWork == request.workName);
			var query = _userWorkRepository.GetAll()
				.WhereIf(request.UId.HasValue, x => x.UId == request.UId)
				.WhereIf(wUser != null, x => x.WId == wUser.Id)
				.WhereIf(request.status.HasValue, x => x.Status == request.status)
				.WhereIf(request.permision.HasValue, x => x.permision == request.permision);

			var listData = query
			.Skip(request.SkipCount)
			.Take(request.MaxResultCount)
			.OrderByDescending(x => x.LastModificationTime)
			.ToList();

			var totalCount = query.Count();

			var result = new PagedResultDto<UserWork>()
			{
				TotalCount = totalCount,
				Items = listData
			};

			return result;
		}
	}
}