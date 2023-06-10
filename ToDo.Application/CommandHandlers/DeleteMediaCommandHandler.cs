﻿using App.Shared.AppSession;
using App.Shared.Uow;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.ICommands;
using ToDo.Domain.Repositories;

namespace ToDo.Application.CommandHandlers
{
	public class DeleteMediaCommandHandler: IRequestHandler<DeleteMediaCommand, bool>
	{
		private readonly IMediaTranmissionRepository _mediaRepository;
		private readonly IMaxUnitOfWork _unitOfWork;
		private readonly IAppSession _appSession;
		public DeleteMediaCommandHandler(IMediaTranmissionRepository mediaRepository,
			IMaxUnitOfWork unitOfWork, IAppSession appSession)
		{
			_mediaRepository = mediaRepository;
			_unitOfWork = unitOfWork;
			_appSession = appSession;
		}
		public async Task<bool> Handle(DeleteMediaCommand command, CancellationToken cancellationToken)
		{
			var media = await _mediaRepository.FirstOrDefaultAsync(x => x.Id == command.Id);
			if (media == null)
			{
				return false;
			}

			_mediaRepository.Delete(media);

			await _unitOfWork.SaveChangesAsync();

			return true;
		}
	}
}
