namespace ToDo.Domain.Dtos;

public class ApiResult
{
    public string Message { get; set; } = "Success";
    public bool Success { get; set; }
    public object? Result { get; set; } = null;
}