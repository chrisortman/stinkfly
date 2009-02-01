namespace StinkFly
{
	public class UrlPart
	{
		public string Value { get; private set; }

		protected UrlPart(string value)
		{
			Value = value;
		}

		public virtual bool CanMatch(UrlPart other,RequestContext context)
		{
			return true;
		}
	}
}