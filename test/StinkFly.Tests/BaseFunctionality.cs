namespace StinkFly.Tests
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using Xunit;



	public class StinkFlyProcessor : IBuilder
	{
		private Dictionary<string, Func<CallContext,string>> _lookup;
		public StinkFlyProcessor()
		{
			_lookup = new Dictionary<string, Func<CallContext,string>>();
		}

		public void Add(string url, Func<CallContext,string> action)
		{
			_lookup.Add(url, action);
		}

		

		public Func<URL> Build(string url, Func<CallContext, string> action)
		{
			_lookup.Add(url, action);
			Func<URL> returnValue = () => new URL();
			return returnValue;
		}

		public Func<PARAM,URL> Build<PARAM>(string url, Func<CallContext, string> action)
		{
			_lookup.Add(url, action);
			Func<PARAM,URL> returnValue = x => new URL();
			return returnValue;
		}

		public string Process(string url)
		{

			var func = _lookup.ContainsKey(url) ? _lookup[url] : _lookup.Values.First();
			var context = new CallContext();
			return func(context);
		}
	}

	public class URL
	{
		
	}

	public interface IBuilder
	{
		Func<URL> Build(string url, Func<CallContext, string> action);
		Func<PARAM, URL> Build<PARAM>(string url, Func<CallContext, string> action);
	}


	public class CallContext
	{
		public IDictionary<string,object> Params { get; set;}
		public CallContext()
		{
			Params = new Dictionary<string, object>();
			Params["name"] = "chris";
		}
	}
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


	public class Executing_urls_with_anonymous_methods
	{
		
		
		public class a_static_url : Spec
		{
			
			class MyApp : StinkFlyApplication
			{
				private Func<URL> hello_url = get("/hello/world", () => "Hello World");

			}

			private string _response;
			public override void EstablishContext() 
			{
				StinkFlyProcessor processor = new StinkFlyProcessor();
				StinkFlyApplication.Builder = processor;

				var app = new MyApp();

				_response = processor.Process("/hello/world");
			}

			[Observation]
			public void Response_should_be_able_to_respond()
			{
				Assert.Equal("Hello World",_response);
			}
		}

		public class a_url_with_a_a_variable : Spec
		{
			class MyApp : StinkFlyApplication
			{
				private Func<string,URL> hello_url = get<string>("hello/{name}", name => "Hello " + name);
			}

			private string _response;

			public override void EstablishContext() {
				StinkFlyProcessor processor = new StinkFlyProcessor();
				StinkFlyApplication.Builder = processor;

				var app = new MyApp();
				_response = processor.Process("hello/chris");

			}

			[Observation]
			public void be_able_to_pass_the_variables_value_to_the_method()
			{
				Assert.Equal("Hello chris",_response);
			}
		}
	}
}