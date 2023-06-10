using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Entities;

namespace ToDo.Domain.Dtos
{
	
	public class CreateMediaDto
	{
		public long UWId { get; set; }
		public string linkOrComment { get; set; }
		public Title Titles { get; set; }
	
	}
}
