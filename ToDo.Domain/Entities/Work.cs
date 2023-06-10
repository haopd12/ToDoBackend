using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDo.Domain.Entities
{
	
	[Table("worktodo")]
	public class Work: FullAuditedEntity<long>, IMayHaveTenant
	{
		public int? TenantId { get; set; }
		public string? TitleWork { get; set; }
		public DateTime? StartTime { get; set; }
		public DateTime? EndTime { get; set; }
	}
}
