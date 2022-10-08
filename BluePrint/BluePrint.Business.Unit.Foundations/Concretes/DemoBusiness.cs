using Autofac;
using BluePrint.Business.Abstracts;
using BluePrint.Business.Unit.Foundations.Behaviors;
using BluePrint.Common.Rest;
using BluePrint.CrossCuttingConcern.Caching.Aspects;
using BluePrint.CrossCuttingConcern.Logging.Aspects;
using BluePrint.CrossCuttingConcern.Logging.Helpers;
using BluePrint.CrossCuttingConcern.Scheduling.Aspects;
using BluePrint.CrossCuttingConcern.Transaction.Aspects;
using BluePrint.CrossCuttingConcern.Unit.Foundations.Validation;
using BluePrint.CrossCuttingConcern.Validation.Aspects;
using BluePrint.DataAccess.Persistance.Context;
using BluePrint.DataAccess.Unit.Foundations.Behaviors;
using BluePrint.Model.Dtos.Behaviors;
using BluePrint.Model.Entities.Behaviors;
using BluePrint.Model.Unit.Foundations.Dtos;
using BluePrint.Model.Unit.Foundations.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BluePrint.Business.Unit.Foundations.Concretes
{
    public class DemoBusiness : BaseBusiness<DemoDto, DemoEntity, BluePrintContext>, IDemoBusiness
    {
        public DemoBusiness(IComponentContext componentContext) : base(componentContext)
        {
        }

        [CacheRemoveAspect("IDemoBusiness.GetDemoService")]
        public ServiceResult<bool> AddRangeDemoService()
        {
            var demoEntites = new List<DemoEntity>();
            for (int i = 0; i < 30; i++)
            {
                var entity = new DemoEntity()
                {
                    CreatedBy = "Serhat",
                    CreationDate = DateTime.Now,
                    DemoName = this.GenerateRandomString(),
                    ModificationDate = DateTime.Now,
                    ModifiedBy = "Serhat"
                };

                demoEntites.Add(entity);
            }

            var repository = this.ComponentContext.Resolve<IDemoRepository>();
            repository.AddRange(demoEntites);

            base.UnitOfWork.Commit();

            return new ServiceResult<bool>(true, "Demo entites added success!");
        }

        [ValidationAspect(typeof(DemoValidation), Priority = 1)]
        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [CacheRemoveAspect("IDemoBusiness.GetDemoService")]
        public ServiceResult<DemoDto> CreateDemoService(DemoDto dto)
        {
            var entity = base.Mapper.Map<DemoDto, DemoEntity>(dto);
            var repository = this.ComponentContext.Resolve<IDemoRepository>();
            repository.Add(entity);

            base.UnitOfWork.Commit();

            return new ServiceResult<DemoDto>(dto,"Demo created successfully");

        }


        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [CacheAspect(duration: 10)]
        [SchedulingAspect(1)]
        public ServiceResult<IPagingDto<DemoDto>> GetAllDemoService()
        {
            var repository = this.ComponentContext.Resolve<IDemoRepository>();
            var entites = repository.GetAll();
            var dtos = base.Mapper.Map<IPagingEntity<DemoEntity>, IPagingDto<DemoDto>>(entites);

            return new ServiceResult<IPagingDto<DemoDto>>(dtos,": All Demos Returned Success!");

        }

        [TransactionScopeAspect]
        public ServiceResult<bool> TransactionalOperation(DemoDto dto)
        {
            this.UpdateDemoService(dto);
            this.CreateDemoService(dto);
            return new ServiceResult<bool>(true, "TransactionalOperation");
        }

        public ServiceResult<DemoDto> UpdateDemoService(DemoDto dto)
        {
            var repository = this.ComponentContext.Resolve<IDemoRepository>();
            var entity = repository.GetById(dto.Id);
            entity.DemoName = dto.DemoName;
            var result = base.Mapper.Map<DemoEntity, DemoDto>(entity);

            base.UnitOfWork.Commit();

            return new ServiceResult<DemoDto>(result, "Demo entity updated success!");
        }

        /// <summary>
        /// Generates the random string.
        /// </summary>
        /// <param name="length">The length.</param>
        /// <returns></returns>
        private string GenerateRandomString()
        {
            StringBuilder str_build = new StringBuilder();
            Random random = new Random();
            char letter;

            double flt = random.NextDouble();
            int shift = Convert.ToInt32(Math.Floor(25 * flt));
            letter = Convert.ToChar(shift + 65);
            str_build.Append(letter);

            return str_build.ToString();
        }
    }
}
