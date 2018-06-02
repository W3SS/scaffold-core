using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using System.Data;
using Serilog;
using ScaffoldCore.Infrastructure.Exceptions;
using ScaffoldCore.Domain.Base;
using ScaffoldCore.Infrastructure.Factories;
using System.Linq;
using ScaffoldCore.Domain.BindingModels;
using ScaffoldCore.Domain.Entities;
using Dapper.Contrib.Extensions;
using Marten;

namespace ScaffoldCore.Domain.Services
{
	public class PostgresSampleService : BaseService
	{
		private IDocumentStore Store;

		public PostgresSampleService(IDocumentStore store, IMapper mapper, ILogger logger) : base(mapper, logger)
		{
			Store = store;
		}

		public List<SampleAggregateBindingModel> List()
		{
			using (var session = Store.LightweightSession())
			{
				var collection = session
					.Query<SampleAggregateEntity>()
					.ToList();
				return Mapper.Map<List<SampleAggregateBindingModel>>(collection);
			}
		}

		public SampleAggregateBindingModel Read(Guid id)
		{
			using (var session = Store.LightweightSession())
			{
				var collection = session
					.Query<SampleAggregateEntity>()
					.Where(x => x.Id.Equals(id))
					.SingleOrDefault();
				return Mapper.Map<SampleAggregateBindingModel>(collection);
			}
		}

		public SampleAggregateBindingModel Save(SampleAggregateBindingModel model)
		{
			var entity = Mapper.Map<SampleAggregateEntity>(model);
			using (var session = Store.LightweightSession())
			{
				session.Store<SampleAggregateEntity>(entity);
				session.SaveChanges();
				return Mapper.Map<SampleAggregateBindingModel>(entity);
			}
		}

		public void Delete(Guid id)
		{
			using (var session = Store.LightweightSession())
			{
				session.Delete<SampleAggregateEntity>(id);
				session.SaveChanges();
			}
		}

		public object SampleError()
		{
			throw new HandledException(ExceptionType.General, "This is a sample error.", System.Net.HttpStatusCode.NotAcceptable);
		}
	}
}
