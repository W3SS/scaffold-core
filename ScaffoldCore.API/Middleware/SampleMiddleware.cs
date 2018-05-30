using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using ScaffoldCore.Composition;

namespace ScaffoldCore.Service.Middleware
{
	public class SampleMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly ContainerOptions _apiSettings;

		public SampleMiddleware(RequestDelegate next, IOptions<ContainerOptions> options)
		{
			_next = next;
			_apiSettings = options.Value;
		}

		public async Task Invoke(HttpContext context)
		{
			await _next.Invoke(context);
		}
	}
}
