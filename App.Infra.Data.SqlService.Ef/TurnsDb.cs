
using App.Domain.Core.TurnsManager.CarModelAggrigate.Entity;
using App.Domain.Core.TurnsManager.OperatorAggrigate.Entity;
using App.Domain.Core.TurnsManager.RejectedRequestAggrigate.Entity;
using App.Domain.Core.TurnsManager.TechExamAggrigate.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.SqlService.Ef;

public class TurnsDb :DbContext
{
    public TurnsDb(DbContextOptions<TurnsDb> options) : base(options) { }

    public DbSet<CarModel> CarModels { get; set; }
    public DbSet<RejectedRequest> RejectedRequests { get; set; }
    public DbSet<TechExam> TechExams { get; set; }
    public DbSet<Operator> Operators { get; set; }
}
