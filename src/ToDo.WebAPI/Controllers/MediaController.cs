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
	public class MediaController : ControllerBase
	{
		private readonly ILogger<MediaController> _logger;
		private readonly IMediator _mediator;
		private readonly IMapper _mapper;

		public MediaController(ILogger<MediaController> logger, IMediator mediator, IMapper mapper)
		{
			_logger = logger;
			_mediator = mediator;
			_mapper = mapper;
		}


		[HttpGet("get-list-media")]
		public async Task<object?> GetListUser([FromQuery] GetListMediaDto input)
		{
			try
			{
				var result = await _mediator.Send(_mapper.Map<GetListMediaQuery>(input));

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
		[HttpGet("get-list-media-by-work")]
		public async Task<object?> GetListMediaByWorkId([FromQuery] GetListMediaByWorkInput input)
		{
			try
			{
				var result = await _mediator.Send(_mapper.Map<GetListMediaByWorkQuery>(input));

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
		[HttpPost("create-media")]
		public async Task<object?> CreateMedia([FromBody] CreateMediaDto input)
		{
			try
			{
				var result = await _mediator.Send(_mapper.Map<CreateMediaCommand>(input));

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
		[HttpPut("update-media")]
		public async Task<object?> UpdateMedia([FromBody] UpdateMediaDto input)
		{
			try
			{
				var result = await _mediator.Send(_mapper.Map<UpdateMediaCommand>(input));

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
		[HttpDelete("delete-media")]
		public async Task<object?> DeleteMedia([FromQuery] DeleteMediaDto input)
		{
			try
			{
				var result = await _mediator.Send(_mapper.Map<DeleteMediaCommand>(input));

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
