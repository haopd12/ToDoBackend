using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDo.Domain.Entities
{
	public enum Title
	{
		Default = 0,
		Image = 1,
		FileLink = 2,
		Comment = 3
	}
	[Table("mediatodo")]
	public class MediaTranmission: FullAuditedEntity<long>, IMayHaveTenant
	{
		public int? TenantId { get; set; }
		public long UWId { get; set; }
		public string linkOrComment { get; set; }
		public Title Title { get; set; }
		

	}
}
