namespace StinkFly
{
	using System;

	public class StinkFlyProcessor : IBuilder
	{
		private UrlMapper<Func<CallContext, string>> _urlMapper;

		public StinkFlyProcessor()
		{
			_urlMapper = new UrlMapper<Func<CallContext, string>>();
		}

		public void Add(string url, Func<CallContext,string> action)
		{
			_urlMapper.AddUrl(url, action);
		}

		

		public Func<URL> Build(string url, Func<CallContext, string> action)
		{
			_urlMapper.AddUrl(url, action);
			Func<URL> returnValue = () => new URL(url);
			return returnValue;
		}

		public Func<PARAM,URL> Build<PARAM>(string url, Func<CallContext, string> action)
		{
			_urlMapper.AddUrl(url, action);
			Func<PARAM,URL> returnValue = x => new URL("");
			return returnValue;
		}

		public string Process(string url)
		{

			//var func = _lookup.ContainsKey(url) ? _lookup[url] : _lookup.Values.First();
			var context = new CallContext();
			var func = _urlMapper.Map(url);
			return func(context);
		}
	}
}