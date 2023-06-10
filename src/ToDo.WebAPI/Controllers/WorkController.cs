using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDo.Domain.Dtos;
using ToDo.Domain.Dtos;
using ToDo.Domain.ICommands;
using ToDo.Domain.IQueries;

namespace ToDo.WebAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class WorkController: ControllerBase
	{
		private readonly ILogger<WorkController> _logger;
		private readonly IMapper _mapper;
		private readonly IMediator _mediator;

		public WorkController(ILogger<WorkController> logger, IMediator mediator, IMapper mapper)
		{
			_logger = logger;
			_mediator = mediator;
			_mapper = mapper;
		}

		[HttpGet("get-list-work")]
		public async Task<object?> GetListWork([FromQuery] GetListWorkByUserInput input)
		{
			try
			{
				var result = await _mediator.Send(_mapper.Map<GetListWorkByUserQuery>(input));

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

		[HttpPost("create-work")]
		public async Task<object?> CreateWork([FromBody] CreateWorkWithNameInput input)
		{
			try
			{
				var result = await _mediator.Send(_mapper.Map<CreateWorkWithNameCommand>(input));

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
		[HttpPost("create-task-of-work")]
		public async Task<object?> CreateTaskOfWork([FromBody] CreateTaskOfWorkInput input)
		{
			try
			{
				var result = await _mediator.Send(_mapper.Map<CreateTaskOfWorkCommand>(input));

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
		[HttpPut("update-work")]
		public async Task<object?> UpdateWork([FromBody] UpdateWorkDto input)
		{
			try
			{
				var result = await _mediator.Send(_mapper.Map<UpdateWorkCommand>(input));

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
		[HttpPut("update-task-of-work")]
		public async Task<object?> UpdateWorkByUser([FromBody] UpdateWorkByUserInput input)
		{
			try
			{
				var result = await _mediator.Send(_mapper.Map<UpdateWorkByUserCommand>(input));

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

		[HttpDelete("delete-work")]
		public async Task<object?> DeleteWork([FromQuery] DeleteWorkDto input)
		{
			try
			{
				var result = await _mediator.Send(_mapper.Map<DeleteWorkCommand>(input));

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

		[HttpDelete("delete-task-of-work")]
		public async Task<object?> DeleteTaskOfWork([FromQuery] DeleteWorkDto input)
		{
			try
			{
				var result = await _mediator.Send(_mapper.Map<DeleteTaskOfWorkCommand>(input));

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
