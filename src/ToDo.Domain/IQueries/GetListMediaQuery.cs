using App.Shared.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Dtos;
using ToDo.Domain.Entities;

namespace ToDo.Domain.IQueries
{
	public class GetListMediaQuery: GetListMediaDto, IRequest<PagedResultDto<MediaTranmission>>
	{
	}
}
