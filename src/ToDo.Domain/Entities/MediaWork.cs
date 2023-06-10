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
	[Table("mediawork")]
	public class MediaWork : FullAuditedEntity<long>, IMayHaveTenant
	{
			public int? TenantId { get; set; }
			public long WId { get; set; }
			public string linkOrComment { get; set; }
			public Title Title { get; set; }

	}
}
