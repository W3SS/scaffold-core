﻿using ScaffoldCore.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ScaffoldCore.Domain.BindingModels;
using System.Collections.Generic;

namespace ScaffoldCore.Service.Controllers
{
	[Route("api/[controller]")]
	public class ContextSampleController
	{
		private readonly ContextSampleService _Service;

		/// <summary>
		/// Initializes a new instance of the <see cref="TestController"/> class.
		/// </summary>
		/// <param name="Service">The service.</param>
		public ContextSampleController(ContextSampleService Service)
		{
			_Service = Service;
		}

		/// <summary>
		/// Lists all Sample Entities.
		/// </summary>
		/// <returns></returns>
		[HttpGet, Route("")]
		public SampleEntityFilterResponse List(SampleEntityFilterRequest request)
		{
			return _Service.List(request);
		}

		/// <summary>
		/// Reads a single Sample Entity by Id.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		[HttpGet, Route("{id}")]
		public SampleEntityBindingModel Read(int id)
		{
			return _Service.Read(id);
		}

		/// <summary>
		/// Saves the specified binding model.
		/// </summary>
		/// <param name="bindingModel">The binding model.</param>
		/// <returns></returns>
		[HttpPost, HttpPut, Route("")]
		public SampleEntityBindingModel Save(SampleEntityBindingModel bindingModel)
		{
			return _Service.Save(bindingModel);
		}

		/// <summary>
		/// Deletes the specified model by id.
		/// </summary>
		/// <param name="id">The identifier.</param>
		[HttpDelete, Route("{id}")]
		public void Delete(int id)
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