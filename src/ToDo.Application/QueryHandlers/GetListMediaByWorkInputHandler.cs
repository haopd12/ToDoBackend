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
	public class GetListMediaByWorkInputHandler: IRequestHandler<GetListMediaByWorkQuery, PagedResultDto<MediaTranmission>>
	{
		private readonly IMediaTranmissionRepository _mediaRepository;
		private readonly IUserWorkRepository _userWorkRepository;
		private readonly IAppSession _appSession;

		public GetListMediaByWorkInputHandler(IMediaTranmissionRepository mediaRepository, IAppSession appSession, IUserWorkRepository userWorkRepository)
		{
			_mediaRepository = mediaRepository;
			_appSession = appSession;
			_userWorkRepository = userWorkRepository;
		}

		public Task<PagedResultDto<MediaTranmission>> Handle(GetListMediaByWorkQuery request, CancellationToken cancellationToken)
		{
			var q = _userWorkRepository.GetAll()
				.Where(x => x.WId == request.WId)
				.WhereIf(request.UId.HasValue,x => x.UId == request.UId)
				.WhereIf(request.permision.HasValue, x => x.permision == request.permision)
				.WhereIf(request.Status.HasValue,x => x.Status == request.Status)
				.ToList();
			
			List<MediaTranmission> list = new List<MediaTranmission>();
			foreach (var uw in q)
			{
				var query = _mediaRepository.GetAll()
					.Where(x => x.UWId == uw.Id)
					.WhereIf(request.Title.HasValue, x => x.Title == request.Title);
				if (query != null)
				{
					list.AddRange(query);
				}
			}



			var listData = list
				.Skip(request.SkipCount)
				.Take(request.MaxResultCount)
				.OrderByDescending(x => x.UWId)
				.ToList();

			var totalCount = list.Count();

			var result = new PagedResultDto<MediaTranmission>()
			{
				TotalCount = totalCount,
				Items = listData
			};

			return Task.FromResult(result);
		}
	}
}
