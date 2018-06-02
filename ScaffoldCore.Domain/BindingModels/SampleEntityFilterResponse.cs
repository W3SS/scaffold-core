using ScaffoldCore.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScaffoldCore.Domain.BindingModels
{
	public class SampleEntityFilterResponse : BasePaginatedResponse<SampleEntityBindingModel>
	{
		public SampleEntityFilterResponse(List<SampleEntityBindingModel> collection) : base(collection)
		{

		}
	}
}
