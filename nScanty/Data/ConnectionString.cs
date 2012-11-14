using System.Configuration;

namespace nScanty.Data
{
	public static class ConnectionString
	{
		public static string MongoLab
		{
			get { return ConfigurationManager.AppSettings.Get("MONGOLAB_URI"); }
		}
	}
}