using App.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Entities;

namespace ToDo.Domain.Dtos
{
	public class GetListMediaByWorkInput: PagedInputDto
	{
		
		public Title? Title { get; set; }
		public long? UId { get; set; }
		public long WId { get; set; }
		public Permision? permision { get; set; }
		public Status? Status { get; set; }
	}
}
