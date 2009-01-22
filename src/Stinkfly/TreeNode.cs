namespace StinkFly
{
	using System.Collections.Generic;

	public class TreeNode<VALUE>
	{
		private readonly List<TreeNode<VALUE>> _children;
		private readonly IDictionary<string, object> _extensionData;
		private readonly VALUE _value;

		public TreeNode(VALUE _value)
		{
			this._value = _value;
			_children = new List<TreeNode<VALUE>>();
			_extensionData = new Dictionary<string, object>();
		}

		public int NodeCount
		{
			get { return _children.Count; }
		}

		public IDictionary<string, object> ExtensionData
		{
			get { return _extensionData; }
		}

		public VALUE Value
		{
			get { return _value; }
		}

		public void AddChild(VALUE value)
		{
			_children.Add(new TreeNode<VALUE>(value));
		}

		public IEnumerable<TreeNode<VALUE>> ChildNodes()
		{
			foreach (var c in _children)
			{
				yield return c;
			}
		}
	}
}