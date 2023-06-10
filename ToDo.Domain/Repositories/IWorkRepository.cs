using AppShared.Repositories;
using ToDo.Domain.Entities;

namespace ToDo.Domain.Repositories;

public interface IWorkRepository : IRepository<Work, long>
{
}