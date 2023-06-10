using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDo.Domain.Dtos;
using ToDo.Domain.ICommands;
using ToDo.Domain.IQueries;

namespace ToDo.WebAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class MediaWorkController: ControllerBase
	{
		private readonly ILogger<MediaController> _logger;
		private readonly IMediator _mediator;
		private readonly IMapper _mapper;

		public MediaWorkController(ILogger<MediaController> logger, IMediator mediator, IMapper mapper)
		{
			_logger = logger;
			_mediator = mediator;
			_mapper = mapper;
		}
		[HttpGet("get-list-media-work")]
		public async Task<object?> GetListMWork([FromQuery] GetListMediaWorkDto input)
		{
			try
			{
				var result = await _mediator.Send(_mapper.Map<GetListMediaWorkQuery>(input));

				return new ApiResult
				{
					Success = true,
					Result = result
				};
			}
			catch (Exception e)
			{
				_logger.LogError(e, e.Message);

				return new ApiResult
				{
					Success = false,
					Message = e.Message
				};
			}
		}
		[HttpPost("create-media-work")]
		public async Task<object?> CreateMWork([FromBody] CreateMediaWorkDto input)
		{
			try
			{
				var result = await _mediator.Send(_mapper.Map<CreateMediaWorkCommand>(input));

				return new ApiResult
				{
					Success = true,
					Result = result
				};
			}
			catch (Exception e)
			{
				_logger.LogError(e, e.Message);

				return new ApiResult
				{
					Success = false,
					Result = false,
					Message = e.Message
				};
			}
		}
		[HttpPut("update-media-work")]
		public async Task<object?> UpdateMedia([FromBody] UpdateMediaWorkDto input)
		{
			try
			{
				var result = await _mediator.Send(_mapper.Map<UpdateMediaWorkCommand>(input));

				return new ApiResult
				{
					Success = true,
					Result = result
				};
			}
			catch (Exception e)
			{
				_logger.LogError(e, e.Message);

				return new ApiResult
				{
					Success = false,
					Result = false,
					Message = e.Message
				};
			}
		}
		[HttpDelete("delete-media-work")]
		public async Task<object?> DeleteMWork([FromQuery] DeleteMediaWorkDto input)
		{
			try
			{
				var result = await _mediator.Send(_mapper.Map<DeleteMediaWorkCommand>(input));

				return new ApiResult
				{
					Success = true,
					Result = result
				};
			}
			catch (Exception e)
			{
				_logger.LogError(e, e.Message);

				return new ApiResult
				{
					Success = false,
					Result = false,
					Message = e.Message
				};
			}
		}
	}
}
