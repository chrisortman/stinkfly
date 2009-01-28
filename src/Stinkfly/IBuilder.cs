namespace StinkFly
{
	using System;

	public interface IBuilder
	{
		Func<URL> Build(string url, Func<CallContext, string> action);
		Func<PARAM, URL> Build<PARAM>(string url, Func<CallContext, string> action);
	}
}