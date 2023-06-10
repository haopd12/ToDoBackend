using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Domain.Dtos
{
	public class UpdateWorkDto
	{
		public long Id { get; set; }
		public string? TitleWork { get; set; }
		public DateTime? StartTime { get; set; }
		public DateTime? EndTime { get; set; }
	}
}
