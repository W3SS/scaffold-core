using System;
using System.Collections.Generic;
using System.Text;

namespace ScaffoldCore.Domain.Base
{
	public class BasePaginatedResponse<T> where T : class
	{
		public BasePaginatedResponse(List<T> collection)
		{
			Collection = collection;
		}

		public int Total { get; set; }

		public int CurrentPage { get; set; }

		public int PageSize { get; set; }

		public List<T> Collection { get; set; }
	}
}
