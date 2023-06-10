using App.Shared.Uow;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Entities;
using ToDo.Domain.ICommands;
using ToDo.Domain.Repositories;

namespace ToDo.Application.CommandHandlers
{
	public class UpdateMediaCommandHandler: IRequestHandler<UpdateMediaCommand, bool>
	{
		private readonly IMediaTranmissionRepository _mediaRepository;
		private readonly IMapper _mapper;
		private readonly IMaxUnitOfWork _unitOfWork;

		public UpdateMediaCommandHandler(IMediaTranmissionRepository mediaRepository, IMapper mapper,
			IMaxUnitOfWork unitOfWork)
		{
			_mediaRepository = mediaRepository;
			_mapper = mapper;
			_unitOfWork = unitOfWork;
		}

		public async Task<bool> Handle(UpdateMediaCommand request, CancellationToken cancellationToken)
		{
			var input = _mapper.Map<MediaTranmission>(request);
			var media = await _mediaRepository.FirstOrDefaultAsync(x => x.Id == input.Id);
			media.linkOrComment = input.linkOrComment;
			media.UWId = input.UWId;
			media.Title = input.Title;
			
			await _mediaRepository.UpdateAsync(media);

			await _unitOfWork.SaveChangesAsync();

			return true;
		}
	}
}
