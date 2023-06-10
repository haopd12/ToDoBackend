using App.Shared.AppSession;
using App.Shared.Uow;

namespace ToDo.Infrastructure.Contexts;

public class UnitOfWork : UnitOfWorkBase<ToDoContext>, IMaxUnitOfWork
{
    public UnitOfWork(ToDoContext context) : base(context)
    {
    }
}