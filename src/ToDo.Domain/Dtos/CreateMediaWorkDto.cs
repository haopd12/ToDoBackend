using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Entities;

namespace ToDo.Domain.Dtos
{
	public class CreateMediaWorkDto
	{
		public long WId { get; set; }
		public string linkOrComment { get; set; }
		public Title Title { get; set; }
	}
}
