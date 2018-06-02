using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ScaffoldCore.Domain.Base
{
	public class BasePaginatedRequest
	{
		public const int DefaultPageSize = 25;
		public const int DefaultCurrentPage = 0;

		public BasePaginatedRequest()
		{
			PageSize = DefaultPageSize;
			CurrentPage = DefaultCurrentPage;
		}

		[DefaultValue(DefaultPageSize)]
		public int PageSize { get; set; }

		[DefaultValue(DefaultCurrentPage)]
		public int CurrentPage { get; set; }
	}
}
