using System;
using System.Collections.Generic;
using System.Text;

namespace ScaffoldCore.Composition
{
	public class ContainerOptions
	{
		public ContainerOptions()
		{
			Database = new DatabaseSettings();
			Token = new TokenSettings();
			Caching = new CachingSettings();
			CORS = new CorsSettings();
		}

		public DatabaseSettings Database { get; set; }

		public TokenSettings Token { get; set; }

		public CachingSettings Caching { get; set; }

		public CorsSettings CORS { get; set; }

		public class DatabaseSettings
		{
			public string SqlConnectionString { get; set; }
			public string PostgresConnectionString { get; set; }
		}

		public class TokenSettings
		{
			public string Issuer { get; set; }
			public string Audience { get; set; }
			public string SecurityKey { get; set; }
		}

		public class CachingSettings
		{
			public string RedisHost { get; set; }
			public int RedisPort { get; set; }
			public int RedisDatabaseId { get; set; }
		}

		public class CorsSettings
		{
			public string PolicyName { get; set; }
			public string[] Origins { get; set; }
		}
	}
}
