using Xunit;
using Xunit.Extensions.AssertExtensions;
namespace StinkFly.Tests
{
	public class TreeSpecs : Spec
	{
		protected UrlTree<string> tree;

		public override void EstablishContext() 
		{
				tree = new UrlTree<string>("chris");
				tree.Add("damon");
				tree.Add("mason");
				tree.Add("clara");
		}

		public class A_tree_with_three_nodes : TreeSpecs
		{

			[Observation]
			public void Should_be_able_to_count()
			{
				tree.NodeCount.ShouldEqual(3);
			}

			[Observation]
			public void Current_should_be_initial()
			{
				tree.Current.ShouldEqual("chris");
			}

			[Observation]
			public void Move_to_should_change_current()
			{
				tree.MoveTo("mason");
				tree.Current.ShouldEqual("mason");
			}
			
		}

		public class When_moving_to_a_node_that_does_not_exist : TreeSpecs
		{
			private bool move_to_return;

			public override void Because() 
			{
				move_to_return = tree.MoveTo("bart");
			}

			[Observation]
			public void Should_not_destroy_current()
			{
				tree.Current.ShouldEqual("chris");
			}

			[Observation]
			public void Move_to_should_return_false()
			{
				move_to_return.ShouldBeFalse();
			}
		}

		public class When_you_have_moved_to_a_child_node : TreeSpecs
		{
			private bool move_to_return;
			public override void Because() 
			{
				move_to_return = tree.MoveTo("mason");
			}

			public void Move_to_should_return_true()
			{
				move_to_return.ShouldBeTrue();
			}

			[Observation]
			public void Count_should_be_new_current_node_count()
			{
				tree.NodeCount.ShouldEqual(0);
			}

			[Observation]
			public void Adding_should_add_to_that_node()
			{
				tree.Add("puppy");
				tree.NodeCount.ShouldEqual(1);
				tree.MoveTo("puppy");
				tree.Current.ShouldEqual("puppy");
			}
		}
	}
}