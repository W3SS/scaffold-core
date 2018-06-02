using ScaffoldCore.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ScaffoldCore.Domain.BindingModels;
using System.Collections.Generic;
using System;

namespace ScaffoldCore.Service.Controllers
{
	[Route("api/[controller]")]
	public class PostgresSampleController
	{
		private readonly PostgresSampleService _Service;

		/// <summary>
		/// Initializes a new instance of the <see cref="TestController"/> class.
		/// </summary>
		/// <param name="Service">The service.</param>
		public PostgresSampleController(PostgresSampleService Service)
		{
			_Service = Service;
		}

		/// <summary>
		/// Lists all Sample Entities.
		/// </summary>
		/// <returns></returns>
		[HttpGet, Route("")]
		public List<SampleAggregateBindingModel> List()
		{
			return _Service.List();
		}

		/// <summary>
		/// Reads a single Sample Entity by Id.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		[HttpGet, Route("{id}")]
		public SampleAggregateBindingModel Read(Guid id)
		{
			return _Service.Read(id);
		}

		/// <summary>
		/// Saves the specified binding model.
		/// </summary>
		/// <param name="bindingModel">The binding model.</param>
		/// <returns></returns>
		[HttpPost, HttpPut, Route("")]
		public SampleAggregateBindingModel Save(SampleAggregateBindingModel bindingModel)
		{
			return _Service.Save(bindingModel);
		}

		/// <summary>
		/// Deletes the specified model by id.
		/// </summary>
		/// <param name="id">The identifier.</param>
		[HttpDelete, Route("{id}")]
		public void Delete(Guid id)
		{
			_Service.Delete(id);
		}

		/// <summary>
		/// This is a sample error.
		/// </summary>
		/// <returns></returns>
		[HttpGet, Route("SampleError")]
		public object SampleError()
		{
			return _Service.SampleError();
		}

	}
}
