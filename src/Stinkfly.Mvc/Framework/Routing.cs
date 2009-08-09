using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;

namespace Stinkfly.Mvc.Framework
{
	public class NamespaceRouteDefinitions : RouteDefinitions
	{
		private string _namespace;

		public NamespaceRouteDefinitions(string @namespace)
		{
			_namespace = @namespace;
		}

		public override void Connect(string url)
		{
			if (!url.StartsWith("/" ))
			{
				url = "/" + url;
			}
			base.Connect(_namespace + url);
		}
	}

	public class RouteOptions
	{
		private RouteValueDictionary _defaults = new RouteValueDictionary();
		private RouteValueDictionary _constraints = new RouteValueDictionary();

		public RouteOptions Default(string name, object value)
		{
			_defaults.Add(name, value);
			return this;
		}

		public RouteOptions Constrain(string name, object pattern)
		{
			_defaults.Add(name, pattern);
			return this;
		}

		public RouteValueDictionary GetDefaults()
		{
			return _defaults;
		}

		public RouteValueDictionary GetConstraints()
		{
			return _constraints;
		}
	}

	public class RouteDefinitions
	{
		private List<Action<RouteCollection>> _actions = new List<Action<RouteCollection>>();

		public virtual void Connect(string url)
		{
			_actions.Add(x => x.Add(new Route(url, new MvcRouteHandler())));
		}

		public virtual void Connect(string url, Action<RouteOptions> gatherOptions)
		{
			var options = new RouteOptions();
			gatherOptions(options);
			var defaults = options.GetDefaults();
			var constraints = options.GetConstraints();

			_actions.Add(x => x.Add(new Route(url, defaults, constraints, new MvcRouteHandler())));
		}

		public void Namespace(string name, Action<RouteDefinitions> defineNamespaceRoutes)
		{
			var subRouteDefinitions = new NamespaceRouteDefinitions(name);
			defineNamespaceRoutes(subRouteDefinitions);
			_actions.Add(x => subRouteDefinitions.BuildRoutes(x));
		}

		public void BuildRoutes(RouteCollection routes)
		{
			_actions.ForEach(x => x(routes));
		}
	}

	public static class RouteCollectionExtensions
	{
		public static void Define(this RouteCollection routes, Action<RouteDefinitions> defineRoutes)
		{
			var definitions = new RouteDefinitions();
			defineRoutes(definitions);
			definitions.BuildRoutes(RouteTable.Routes);
		}
	}
}