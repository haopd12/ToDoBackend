using Abp.Collections.Extensions;
using App.Shared.AppSession;
using App.Shared.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Entities;
using ToDo.Domain.IQueries;
using ToDo.Domain.Repositories;

namespace ToDo.Application.QueryHandlers
{
	public class GetListMediaQueryHandler: IRequestHandler<GetListMediaQuery, PagedResultDto<MediaTranmission>>
	{
		private readonly IMediaTranmissionRepository _mediaRepository;
		private readonly IAppSession _appSession;

		public GetListMediaQueryHandler(IMediaTranmissionRepository mediaRepository, IAppSession appSession)
		{
			_mediaRepository = mediaRepository;
			_appSession = appSession;
		}

		public Task<PagedResultDto<MediaTranmission>> Handle(GetListMediaQuery request, CancellationToken cancellationToken)
		{
			var query = _mediaRepository.GetAll()
				.WhereIf(request.Id.HasValue, x =>x.Id == request.Id)
				.WhereIf(request.UWId.HasValue, x => x.UWId == request.UWId)
				.WhereIf(request.Title.HasValue, x => x.Title == request.Title);
				

			var listData = query
				.Skip(request.SkipCount)
				.Take(request.MaxResultCount)
				.OrderByDescending(x => x.LastModificationTime)
				.ToList();

			var totalCount = query.Count();

			var result = new PagedResultDto<MediaTranmission>()
			{
				TotalCount = totalCount,
				Items = listData
			};

			return Task.FromResult(result);
		}
	}
}
