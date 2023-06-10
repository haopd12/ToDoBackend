using App.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Entities;

namespace ToDo.Domain.Dtos
{
	public class GetListWorkByUserInput: PagedInputDto
	{
		public long? UId { get; set; }
		public Status? status { get; set; }
		public Permision? permision { get; set; }
		public string? workName { get; set; }
	}
}
