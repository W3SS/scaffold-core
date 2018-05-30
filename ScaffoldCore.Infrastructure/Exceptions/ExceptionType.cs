using System;
using System.Collections.Generic;
using System.Text;

namespace ScaffoldCore.Infrastructure.Exceptions
{
	public enum ExceptionType
	{
		General,
		Service,
		Validation,
		Warning,
		Authentication,
		Security,
	}
}
