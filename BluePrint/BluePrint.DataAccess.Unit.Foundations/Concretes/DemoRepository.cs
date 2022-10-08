using BluePrint.DataAccess.Concretes;
using BluePrint.DataAccess.Persistance.Context;
using BluePrint.DataAccess.Unit.Foundations.Behaviors;
using BluePrint.Model.Unit.Foundations.Entities;

namespace BluePrint.DataAccess.Unit.Foundations.Concretes
{
    public class DemoRepository : BaseEntityRepository<DemoEntity, BluePrintContext>, IDemoRepository
    {
        public DemoRepository(BluePrintContext context) : base(context)
        {
        }
    }
}
