namespace BinarySearchTree
{
	using System;

	public class TreeNode<T> where T : IComparable
	{
		private TreeNode<T> _left;
		private TreeNode<T> _right;
		private T _value;

		public TreeNode(T value)
		{
			Value = value;
		}

		public TreeNode(TreeNode<T> left, TreeNode<T> right, T value)
		{
			Left = left;
			Right = right;
			Value = value;
		}

		public TreeNode<T> Left
		{
			get
			{
				return _left;
			}

			set
			{
				_left = value;
			}
		}

		public TreeNode<T> Right
		{
			get
			{
				return _right;
			}

			set
			{
				_right = value;
			}
		}

		public T Value
		{
			get
			{
				return _value;
			}

			set
			{
				_value = value;
			}
		}

		public void Add(T insertValue)
		{
			int comparison = insertValue.CompareTo(Value);

			if (comparison == 0)
			{
				return;
			}

			if (comparison < 0)
			{
				if (Left == null)
				{
					Left = new TreeNode<T>(insertValue);
				}
				else
				{
					Left.Add(insertValue);
				}
			}
			else
			{
				if (Right == null)
				{
					Right = new TreeNode<T>(insertValue);
				}
				else
				{
					Right.Add(insertValue);
				}
			}
		}

		public bool Contains(T searchItem, T searchFromNode, bool searchFromNodeFound = false)
		{
			int comparison = searchItem.CompareTo(Value);
			int searchFromNodeComparison = searchFromNode.CompareTo(Value);

			if (searchFromNodeComparison == 0)
			{
				searchFromNodeFound = true;
			}

			if (comparison == 0 && searchFromNodeFound)
			{
				return true;
			}

			if (comparison < 0)
			{
				if (Left == null)
				{
					return false;
				}
				else
				{
					return Left.Contains(searchItem, searchFromNode, searchFromNodeFound);
				}
			}
			else
			{
				if (Right == null)
				{
					return false;
				}
				else
				{
					return Right.Contains(searchItem, searchFromNode, searchFromNodeFound);
				}
			}
		}
	}

	/// <summary>
	/// Please note this is not a self balancing binary tree its beyond the scope of the question.
	/// Add the items in the order you expect them to be represented, no re-parenting will take place on add.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class BinaryTree<T> where T : IComparable
	{
		private readonly TreeNode<T> _root;

		public BinaryTree(T rootValue)
		{
			_root = new TreeNode<T>(rootValue);
		}

		public TreeNode<T> Root
		{
			get
			{
				return _root;
			}
		}

		public void Add(T value)
		{
			_root.Add(value);
		}

		public bool Contains(T searchItem, T searchFromNode)
		{
			return _root.Contains(searchItem, searchFromNode);
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			BinaryTree<int> binaryTree = new BinaryTree<int>(7);

			binaryTree.Add(5);
			binaryTree.Add(6);
			binaryTree.Add(3);
			binaryTree.Add(4);
			binaryTree.Add(1);
			binaryTree.Add(2);
			binaryTree.Add(0);
			binaryTree.Add(9);
			binaryTree.Add(8);
			binaryTree.Add(10);

			Console.WriteLine(binaryTree.Contains(10, 5));
			Console.WriteLine(binaryTree.Contains(10, 7));
			Console.WriteLine(binaryTree.Contains(7, 7));
			Console.WriteLine(binaryTree.Contains(0, 7));
			Console.WriteLine(binaryTree.Contains(-5, 7));
			Console.WriteLine(binaryTree.Contains(0, 0));
			Console.ReadLine();
		}
	}
}
