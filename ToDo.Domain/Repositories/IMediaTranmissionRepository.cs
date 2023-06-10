﻿
using AppShared.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Entities;

namespace ToDo.Domain.Repositories
{
	public interface IMediaTranmissionRepository: IRepository<MediaTranmission, long>
	{
	}
}
