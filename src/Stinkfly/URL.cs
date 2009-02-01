namespace StinkFly
{
	public class URL
	{
		private string _value;

		public URL(string value)
		{
			_value = value;
		}
		public override string ToString() {
			return _value;
		}
	}

	public class WillBeDeferredLaterUrl
	{
		public override string ToString() {
		
			//TODO: An extension method on Part[] that returns string?

		}
	}
}