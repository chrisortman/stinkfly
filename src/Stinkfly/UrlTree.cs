using System;

namespace StinkFly
{
	public class UrlTree<TYPE>
	{
		private readonly TreeNode<TYPE> _rootNode;
		private TreeNode<TYPE> _currentNode;

		public UrlTree(TYPE initialValue)
		{
			_rootNode = new TreeNode<TYPE>(initialValue);
			_currentNode = _rootNode;
		}

		public void Add(TYPE value)
		{
			_currentNode.AddChild(value);
		}

		public TYPE Current
		{
			get
			{
				return _currentNode.Value;
			}
		}

		public int NodeCount
		{
			get
			{
				return _currentNode.NodeCount;
			}
		}

		public void AddExtensionData(string key, object value)
		{
			_currentNode.ExtensionData[key] = value;
		}

		public object GetExtensionData(string key)
		{
			return _currentNode.ExtensionData[key];
		}

		public bool MoveTo(TYPE value)
		{
			foreach(var childNode in _currentNode.ChildNodes())
			{
				if(childNode.Value.Equals(value))
				{
					_currentNode = childNode;
					return true;
				}
			}
			return false;
		}

		public bool MoveToFirst(Predicate<TYPE> matcher)
		{
			foreach( var child in _currentNode.ChildNodes())
			{
				if(matcher(child.Value))
				{
					_currentNode = child;
					return true;
				}
			}
			return false;
		}

		public bool MoveToRoot()
		{
			_currentNode = _rootNode;
			return true;
		}
		
	}
}