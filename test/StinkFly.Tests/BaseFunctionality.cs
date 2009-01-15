namespace StinkFly.Tests
{
	using System;
	using System.Collections.Generic;

	using Xunit;



	public class StinkFlyProcessor
	{
		private Dictionary<string, Func<string>> _lookup;
		public StinkFlyProcessor()
		{
			_lookup = new Dictionary<string, Func<string>>();
		}

		public void Add(string url, Func<string> action)
		{
			_lookup.Add(url, action);
		}

		public Func<URL> Builder(string url, Func<string> action)
		{
			Add(url, action);
			Func<URL> returnValue = () => new URL();
			return returnValue;
		}

		public string Process(string url)
		{
			var func = _lookup[url];
			return func();
		}
	}

	public class URL
	{
		
	}
	public class StinkFlyApplication
	{
		public static Func<string, Func<string>, Func<URL>> Builder { get; set;}
		
		protected static Func<URL> get(string url, Func<string> action)
		{
			return Builder(url, action);
			
		}
	}


	public class BaseFunctionality
	{
		
		
		public class Can_take_a_url_and_return_a_string : Spec
		{
			
			class MyApp : StinkFlyApplication
			{
				private Func<URL> hello_url = get("/hello/world", () => "Hello World");

			}

			private string _response;
			public override void EstablishContext() 
			{

				
				StinkFlyProcessor processor = new StinkFlyProcessor();
				StinkFlyApplication.Builder = processor.Builder;

				var app = new MyApp();

				_response = processor.Process("/hello/world");
			}

			[Observation]
			public void Response_should_be_hello_world()
			{
				Assert.Equal("Hello World",_response);
			}
		}
	}
}