namespace StinkFly.Tests
{
	using System;
	using System.Linq;

	using Xunit;


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