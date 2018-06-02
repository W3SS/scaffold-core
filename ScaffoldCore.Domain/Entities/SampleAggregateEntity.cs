﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using ScaffoldCore.Infrastructure.BaseModels;

namespace ScaffoldCore.Domain.Entities
{
	public class SampleAggregateEntity : BaseAggregateModel
	{
		public string Name { get; set; }
		public string Description { get; set; }
	}
}
