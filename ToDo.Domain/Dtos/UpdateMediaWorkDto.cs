using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Entities;

namespace ToDo.Domain.Dtos
{
	public class UpdateMediaWorkDto
	{
		public int Id { get; set; }
		public long WId { get; set; }
		public string? linkOrComment { get; set; }
		public Title? Title { get; set; }
	}
}
