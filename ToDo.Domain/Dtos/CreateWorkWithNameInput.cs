
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Entities;

namespace ToDo.Domain.Dtos
{
	public class CreateWorkWithNameInput
	{
		public string? TitleWork { get; set; }
		public DateTime? StartTime { get; set; }
		public DateTime? EndTime { get; set; }

		
		public Status? Status { get; set; }/* = Status.Default;*/

		public List<long>? BossIds { get; set; }
		public List<long>? EmployeeIds { get; set; }
		public List<long>? ViewerIds { get; set; }
		public List<CreateMediaWorkDto>? mediaWorks { get; set; }
	}
}
