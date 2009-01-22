using System.Collections.Generic;

namespace StinkFly
{
	public class TreeNode<VALUE>
	{
		private VALUE _value;
		private List<TreeNode<VALUE>> _children;
		private IDictionary<string, object> _extensionData;

		public TreeNode(VALUE _value)
		{
			this._value = _value;
			_children = new List<TreeNode<VALUE>>();
			_extensionData = new Dictionary<string, object>();
		}

		public int NodeCount
		{
			get
			{
				return _children.Count;
			}
		}

		public IDictionary<string,object> ExtensionData
		{
			get { return _extensionData; }
		}

		public VALUE Value
		{
			get{ return _value;}
		}

		public void AddChild(VALUE value)
		{
			_children.Add(new TreeNode<VALUE>(value));
		}

		public IEnumerable<TreeNode<VALUE>> ChildNodes()
		{
			foreach(var c in _children)
			{
				yield return c;
			}
		}
	}
}