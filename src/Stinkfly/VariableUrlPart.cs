namespace StinkFly
{
	using System;

	public class VariableUrlPart : UrlPart
	{
		private readonly string _paramName;

		public VariableUrlPart(string chunk) : base(chunk)
		{
			//chunk should contain the { and }

			if (String.IsNullOrEmpty(chunk))
			{
				throw new Exception("Can't use empty chunk");
			}
			_paramName = chunk;
		}

		public override bool CanMatch(UrlPart other,RequestContext context)
		{
			if (other is FixedStringUrlPart)
			{
				context.AddParameter(_paramName, other.Value);
				return true;
			}
			else if (other is VariableUrlPart)
			{
				return ((VariableUrlPart) other)._paramName.Equals(_paramName, StringComparison.InvariantCultureIgnoreCase);
			}
			else
			{
				return false;
			}
		}

		public override string GenerateUrlFragment(System.Collections.Generic.IDictionary<string, object> parameters) {
			return parameters[_paramName.Trim('{', '}')] as string;
		}
	}
}