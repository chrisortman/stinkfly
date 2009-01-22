namespace StinkFly
{
	using System.Collections.Generic;

	public class UrlMapper<RETURNS>
	{
		private readonly UrlParser _parser;
		private readonly UrlTree<UrlPart> _partTree;

		public UrlMapper()
		{
			_parser = new UrlParser();
			_partTree = new UrlTree<UrlPart>(new FixedStringUrlPart("/"));
		}


		public void AddUrl(string url, RETURNS mapsTo)
		{
			_partTree.MoveToRoot();

			IEnumerable<UrlPart> parts = _parser.Parse(url);

			var partsToDo = new Queue<UrlPart>(parts);
			while (partsToDo.Count > 0)
			{
				UrlPart currentPart = partsToDo.Dequeue();

				if (_partTree.MoveTo(currentPart))
				{
					continue;
				}
				else
				{
					_partTree.Add(currentPart);
					_partTree.MoveTo(currentPart);
				}
			}

			_partTree.AddExtensionData("mapsto", mapsTo);
		}

		public RETURNS Map(string url)
		{
			IEnumerable<UrlPart> parts = _parser.Parse(url);
			_partTree.MoveToRoot();
			foreach (UrlPart part in parts)
			{
				if (_partTree.MoveTo(part))
				{
					continue;
				}
				else if (_partTree.MoveToFirst(x => x.CanMatch(part)))
				{
					continue;
				}
			}

			return (RETURNS) _partTree.GetExtensionData("mapsto");
		}
	}
}