namespace StinkFly
{
	using System;

	public class StinkFlyApplication
	{
		public static IBuilder Builder { get; set;}
		
		protected static Func<URL> get(string url, Func<string> action)
		{
			Func<CallContext, string> executor = ctx => action();
			return Builder.Build(url, executor);
			
		}

		protected static Func<PARAM,URL> get<PARAM>(string url, Func<PARAM,string> action)
		{
			Func<CallContext, string> executor = ctx =>
				{
					var paramValue = (PARAM) ctx.Params["name"];
					return action(paramValue);
				};
			
			return Builder.Build<PARAM>(url, executor);
		}
	}
}