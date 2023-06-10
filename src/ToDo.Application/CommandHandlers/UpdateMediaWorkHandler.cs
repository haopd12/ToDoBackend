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
	public class UpdateMediaWorkHandler: IRequestHandler<UpdateMediaWorkCommand, bool>
	{
		private readonly IMediaWorkRepository _mediaRepository;
		private readonly IMapper _mapper;
		private readonly IMaxUnitOfWork _unitOfWork;

		public UpdateMediaWorkHandler(IMediaWorkRepository mediaRepository, IMapper mapper,
			IMaxUnitOfWork unitOfWork)
		{
			_mediaRepository = mediaRepository;
			_mapper = mapper;
			_unitOfWork = unitOfWork;
		}

		public async Task<bool> Handle(UpdateMediaWorkCommand request, CancellationToken cancellationToken)
		{
			var input = _mapper.Map<MediaWork>(request);
			var media = await _mediaRepository.FirstOrDefaultAsync(x => x.Id == input.Id);
			media.linkOrComment = input.linkOrComment;
			media.Title = input.Title;
			media.WId = input.WId;

			await _mediaRepository.UpdateAsync(media);

			await _unitOfWork.SaveChangesAsync();

			return true;
		}
	}
}
