using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Entities;

namespace ToDo.Domain.Dtos
{
	public class CreateTaskOfWorkInput
	{
		public long UId { get; set; }
		public long WId { get; set; }
		public Permision? permision { get; set; }
		public Status? Status { get; set; }
		public string? TaskTitle { get; set; }
	}
}
