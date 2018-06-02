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
using ScaffoldCore.Domain.Contexts;

namespace ScaffoldCore.Domain.Services
{
	public class ContextSampleService : BaseService
	{
		private SampleContext Context;

		public ContextSampleService(IDbContextFactory contextFactory, IMapper mapper, ILogger logger) : base(mapper, logger)
		{
			Context = contextFactory.CreateDatabaseContext<SampleContext>();
		}

		public SampleEntityFilterResponse List(SampleEntityFilterRequest request)
		{
			var total = Context.SampleEntities.Count(x => x.Name.Contains(request.Name));
			var collection = Context.SampleEntities
				.Where(x => x.Name.Contains(request.Name))
				.Skip(request.PageSize * (request.CurrentPage))
				.Take(request.PageSize)
				.ToList();

			var results = Mapper.Map<List<SampleEntity>, List<SampleEntityBindingModel>>(collection);
			var response = new SampleEntityFilterResponse(results);
			response.Total = total;
			response.CurrentPage = request.CurrentPage;
			response.PageSize = request.PageSize;

			return response;
		}

		public SampleEntityBindingModel Read(int id)
		{
			var model = Context.SampleEntities.Single(i => i.Id == id);
			return Mapper.Map<SampleEntity, SampleEntityBindingModel>(model);
		}

		public SampleEntityBindingModel Save(SampleEntityBindingModel bindingModel)
		{
			var model = Mapper.Map<SampleEntityBindingModel, SampleEntity>(bindingModel);
			if (model.Id == default(int))
			{
				Context.SampleEntities.Add(model);
				Context.SaveChanges();
			}
			else
			{
				Context.Attach(model);
				Context.SaveChanges();
			}
			return Mapper.Map<SampleEntity, SampleEntityBindingModel>(model);
		}

		public void Delete(int id)
		{
			var model = Context.SampleEntities.Single(i => i.Id == id);
			if (model != null)
			{
				Context.SampleEntities.Remove(model);
				Context.SaveChanges();
			}
		}

		public void Delete(SampleEntityBindingModel bindingModel)
		{
			var model = Mapper.Map<SampleEntityBindingModel, SampleEntity>(bindingModel);
			Context.SampleEntities.Remove(model);
			Context.SaveChanges();
		}

		public object SampleError()
		{
			throw new HandledException(ExceptionType.General, "This is a sample error.", System.Net.HttpStatusCode.NotAcceptable);
		}
	}
}
