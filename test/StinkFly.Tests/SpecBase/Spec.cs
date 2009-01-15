namespace StinkFly.Tests
{
	using System;
	using System.Linq;
	using System.Reflection;

	using Xunit;
	using Xunit.Sdk;

	//Thanks to http://iridescence.no/post/Extending-xUnit-with-a-Custom-ObservationAttribute-for-BDD-Style-Testing.aspx

	/// <summary>
	/// Identifies a method as an observation which asserts the specification
	/// </summary>
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
	public class ObservationAttribute : FactAttribute
	{
		protected override System.Collections.Generic.IEnumerable<Xunit.Sdk.ITestCommand> EnumerateTestCommands(System.Reflection.MethodInfo method) {
			foreach(var command in base.EnumerateTestCommands(method))
			{
				yield return new ObservationCommand(command);
			}
		}
	}

	internal class ObservationCommand : ITestCommand
	{
		private ITestCommand _innerCommand;
		public ObservationCommand(ITestCommand command)
		{
			_innerCommand = command;
		}

		public MethodResult Execute(object testClass)
		{
			if(testClass is Spec)
			{
				var spec = (Spec) testClass;
				spec.EstablishContext();
				spec.Because();
			}

			return _innerCommand.Execute(testClass);
		}

		 public string Name
    {
        get { return _innerCommand.Name; }
    }
 
    public bool ShouldCreateInstance
    {
        get { return _innerCommand.ShouldCreateInstance; }
    }
	}

	public abstract class Spec
	{
		public virtual void EstablishContext() { }
		public virtual void Because() {}
	}
}