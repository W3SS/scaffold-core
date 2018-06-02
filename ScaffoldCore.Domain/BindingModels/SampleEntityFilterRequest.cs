using ScaffoldCore.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ScaffoldCore.Domain.BindingModels
{
	public class SampleEntityFilterRequest : BasePaginatedRequest
	{
		[Required]
		public string Name { get; set; }
	}
}
