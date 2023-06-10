using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Dtos;

namespace ToDo.Domain.ICommands
{
	public class CreateWorkWithNameCommand: CreateWorkWithNameInput, IRequest<bool>
	{
	}
}
