using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ScaffoldCore.Domain.BindingModels
{
	public class SampleAggregateBindingModel
	{
		public Guid? Id { get; set; }
		[Required]
		public string Name { get; set; }
		public string Description { get; set; }
	}
}
