namespace StinkFly
{
	using System.Collections.Generic;

	public class CallContext
	{
		public IDictionary<string,object> Params { get; set;}
		public CallContext()
		{
			Params = new Dictionary<string, object>();
			Params["name"] = "chris";
		}
	}
}