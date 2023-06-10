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
	public enum Permision
	{
		None = 0,
		Boss = 1,
		Employee = 2,
		Viewer = 3,
	}
	public enum Status
	{
		Default = 0,
		Deny = 1,
		Accept = 2,
		Processing = 3,
		Complete = 4,
	}

	[Table("userworktodo")]
	public class UserWork : FullAuditedEntity<long>, IMayHaveTenant
	{
		public int? TenantId { get; set; }
		public long UId { get; set; }
		public long WId { get; set; }
		public Permision permision { get; set; }
		public Status? Status { get; set; }
		public string? TaskTitle { get; set; }
	}
}
