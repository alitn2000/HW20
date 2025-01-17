using App.Domain.Core.TurnsManager.OperatorAggrigate.Contracts;
using App.Domain.Core.TurnsManager.OperatorAggrigate.Entity;
using App.Infra.Data.SqlService.Ef;

namespace App.Infra.DataAccess.EF.OperatorAggrigate;

//public interface IOperatorRepository
//{
//    bool LogIn(string userName, string password);
//}
public class OperatorRepository : IOperatorRepository
{
    private readonly TurnsDb _context;
    public OperatorRepository(TurnsDb db)
    {
        _context = db;

    }

    public bool LogIn(string userName, string password)
    {

        if (_context.Operators.Any(o => o.UserName == userName && o.Password == password))
        {
            return true;
        }
        return false;
    }

    public Operator? GetOperator(string userName)
    {
        return _context.Operators.FirstOrDefault(o => o.UserName == userName);
    }
}
