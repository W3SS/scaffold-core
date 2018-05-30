using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScaffoldCore.Infrastructure.Testing
{
	public interface IBaseTestClass
	{
		[ClassInitialize]
		void ClassInit();

		[TestInitialize]
		void TestInit();

		[TestCleanup]
		void Cleanup();
	}
}
