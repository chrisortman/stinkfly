using System;

namespace StinkFly
{
	public class FixedStringUrlPart : UrlPart
	{
		private string _urlChunk;
		public FixedStringUrlPart(string urlChunk)
		{
			if(String.IsNullOrEmpty(urlChunk))
			{
				throw new ArgumentNullException("urlChunk", "urlChunk can not be null");
			}
			_urlChunk = urlChunk;
		}

		public bool Equals(FixedStringUrlPart obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			return Equals(obj._urlChunk, _urlChunk);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof (FixedStringUrlPart)) return false;
			return Equals((FixedStringUrlPart) obj);
		}

		public override int GetHashCode()
		{
			return _urlChunk.GetHashCode();
		}

		public override bool CanMatch(UrlPart other) {
			if(other is FixedStringUrlPart)
			{
				return ((FixedStringUrlPart) other)._urlChunk.Equals(_urlChunk, StringComparison.InvariantCultureIgnoreCase);
			}
			else
			{
				return false;
			}
		}
	}
}