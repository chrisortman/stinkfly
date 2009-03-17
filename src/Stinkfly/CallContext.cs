namespace StinkFly
{
	using System.Collections.Generic;

	public class CallContext
	{
		public IDictionary<string,object> Params { get; set;}
		private static CallContext _current;

		public CallContext()
		{
			Params = new Dictionary<string, object>();
			Params["name"] = "chris";
		}

		public static CallContext Current
		{
			get { return _current; }
			set { _current = value; }
		}
	}
}