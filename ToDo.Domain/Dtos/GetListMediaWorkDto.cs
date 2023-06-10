using App.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Entities;

namespace ToDo.Domain.Dtos
{
	public class GetListMediaWorkDto: PagedInputDto
	{
		public long? Id { get; set; }
		public long? WId { get; set; }
		public Title? Title { get; set; }
	}
}
