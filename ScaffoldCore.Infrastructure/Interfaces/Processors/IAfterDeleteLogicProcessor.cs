﻿using ScaffoldCore.Infrastructure.BaseModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ScaffoldCore.Infrastructure.Interfaces
{
	public interface IAfterDeleteLogicProcessor<in TModel> where TModel : BaseEntityModel
	{
		void Process(IDbConnection context, TModel newModel);
	}
}
