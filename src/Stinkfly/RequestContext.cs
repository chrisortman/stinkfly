namespace StinkFly
{
	using System.Collections.Generic;

	//TODO: probably merges with CallContext 
	public class RequestContext
	{
		private IDictionary<string, object> _requestParameters;

		public RequestContext()
		{
			_requestParameters = new Dictionary<string, object>();
		}

		public string Url { get; set; }
		public void AddParameter(string name, string value)
		{
			_requestParameters.Add(name,value);
		}

	}
}