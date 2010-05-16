﻿// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

#region T4MVC

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;

[CompilerGenerated]
public static class MVC {
    public static Stinkfly.Mvc.Controllers.AccountController Account = new T4MVC_AccountController();
    public static Stinkfly.Mvc.Controllers.HomeController Home = new T4MVC_HomeController();
    public static T4MVC.SharedController Shared = new T4MVC.SharedController();
}


namespace Stinkfly.Mvc.Controllers {
    public partial class AccountController {

        [CompilerGenerated]
        protected AccountController(_Dummy d) { }

        protected RedirectToRouteResult RedirectToAction(ActionResult result) {
            var callInfo = (IT4MVCActionResult)result;
            return RedirectToRoute(callInfo.RouteValues);
        }


        [CompilerGenerated]
        public readonly string Name = "Account";

        static readonly _Actions s_actions = new _Actions();
        [CompilerGenerated]
        public _Actions Actions { get { return s_actions; } }
        [CompilerGenerated]
        public class _Actions {
            public readonly string LogOn = "LogOn";
            public readonly string LogOff = "LogOff";
            public readonly string Register = "Register";
            public readonly string ChangePassword = "ChangePassword";
            public readonly string ChangePasswordSuccess = "ChangePasswordSuccess";
        }

        static readonly _Views s_views = new _Views();
        [CompilerGenerated]
        public _Views Views { get { return s_views; } }
        [CompilerGenerated]
        public class _Views {
            public readonly string ChangePassword = "ChangePassword";
            public readonly string ChangePasswordSuccess = "ChangePasswordSuccess";
            public readonly string LogOn = "LogOn";
            public readonly string Register = "Register";
        }
    }
}
namespace Stinkfly.Mvc.Controllers {
    public partial class HomeController {

        public HomeController() { }

        [CompilerGenerated]
        protected HomeController(_Dummy d) { }

        protected RedirectToRouteResult RedirectToAction(ActionResult result) {
            var callInfo = (IT4MVCActionResult)result;
            return RedirectToRoute(callInfo.RouteValues);
        }

        [NonAction]
        public ActionResult Hello() {
            return new T4MVC_ActionResult(Name, Actions.Hello);
        }


        [CompilerGenerated]
        public readonly string Name = "Home";

        static readonly _Actions s_actions = new _Actions();
        [CompilerGenerated]
        public _Actions Actions { get { return s_actions; } }
        [CompilerGenerated]
        public class _Actions {
            public readonly string Index = "Index";
            public readonly string Hello = "Hello";
            public readonly string About = "About";
        }

        static readonly _Views s_views = new _Views();
        [CompilerGenerated]
        public _Views Views { get { return s_views; } }
        [CompilerGenerated]
        public class _Views {
            public readonly string About = "About";
            public readonly string Hello = "Hello";
            public readonly string Index = "Index";
        }
    }
}
namespace T4MVC {
    public class SharedController {


        static readonly _Views s_views = new _Views();
        [CompilerGenerated]
        public _Views Views { get { return s_views; } }
        [CompilerGenerated]
        public class _Views {
            public readonly string Error = "Error";
            public readonly string LogOnUserControl = "LogOnUserControl";
        }
    }
}

namespace T4MVC {
    [CompilerGenerated]
    public class T4MVC_AccountController: Stinkfly.Mvc.Controllers.AccountController {
        public T4MVC_AccountController() : base(_Dummy.Instance) { }

        public override ActionResult LogOn() {
            var callInfo = new T4MVC_ActionResult("Account", Actions.LogOn);
            return callInfo;
        }

        public override ActionResult LogOn(string userName, string password, bool rememberMe, string returnUrl) {
            var callInfo = new T4MVC_ActionResult("Account", Actions.LogOn);
            callInfo.RouteValues.Add("userName", userName);
            callInfo.RouteValues.Add("password", password);
            callInfo.RouteValues.Add("rememberMe", rememberMe);
            callInfo.RouteValues.Add("returnUrl", returnUrl);
            return callInfo;
        }

        public override ActionResult LogOff() {
            var callInfo = new T4MVC_ActionResult("Account", Actions.LogOff);
            return callInfo;
        }

        public override ActionResult Register() {
            var callInfo = new T4MVC_ActionResult("Account", Actions.Register);
            return callInfo;
        }

        public override ActionResult Register(string userName, string email, string password, string confirmPassword) {
            var callInfo = new T4MVC_ActionResult("Account", Actions.Register);
            callInfo.RouteValues.Add("userName", userName);
            callInfo.RouteValues.Add("email", email);
            callInfo.RouteValues.Add("password", password);
            callInfo.RouteValues.Add("confirmPassword", confirmPassword);
            return callInfo;
        }

        public override ActionResult ChangePassword() {
            var callInfo = new T4MVC_ActionResult("Account", Actions.ChangePassword);
            return callInfo;
        }

        public override ActionResult ChangePassword(string currentPassword, string newPassword, string confirmPassword) {
            var callInfo = new T4MVC_ActionResult("Account", Actions.ChangePassword);
            callInfo.RouteValues.Add("currentPassword", currentPassword);
            callInfo.RouteValues.Add("newPassword", newPassword);
            callInfo.RouteValues.Add("confirmPassword", confirmPassword);
            return callInfo;
        }

        public override ActionResult ChangePasswordSuccess() {
            var callInfo = new T4MVC_ActionResult("Account", Actions.ChangePasswordSuccess);
            return callInfo;
        }

    }
    [CompilerGenerated]
    public class T4MVC_HomeController: Stinkfly.Mvc.Controllers.HomeController {
        public T4MVC_HomeController() : base(_Dummy.Instance) { }

        public override ActionResult Index() {
            var callInfo = new T4MVC_ActionResult("Home", Actions.Index);
            return callInfo;
        }

        public override ActionResult Hello(string name) {
            var callInfo = new T4MVC_ActionResult("Home", Actions.Hello);
            callInfo.RouteValues.Add("name", name);
            return callInfo;
        }

        public override ActionResult About() {
            var callInfo = new T4MVC_ActionResult("Home", Actions.About);
            return callInfo;
        }

    }

    [CompilerGenerated]
    public class _Dummy {
        private _Dummy() { }
        public static _Dummy Instance = new _Dummy();
    }
}

namespace System.Web.Mvc {
    [CompilerGenerated]
    public static class T4Extensions {
        public static string ActionLink(this HtmlHelper htmlHelper, string linkText, ActionResult result) {
            return htmlHelper.RouteLink(linkText, result.GetRouteValueDictionary());
        }

        public static string ActionLink(this HtmlHelper htmlHelper, string linkText, ActionResult result, object htmlAttributes) {
            return ActionLink(htmlHelper, linkText, result, new RouteValueDictionary(htmlAttributes));
        }

        public static string ActionLink(this HtmlHelper htmlHelper, string linkText, ActionResult result, IDictionary<string, object> htmlAttributes) {
            return htmlHelper.RouteLink(linkText, result.GetRouteValueDictionary(), htmlAttributes);
        }

        public static MvcForm BeginForm(this HtmlHelper htmlHelper, ActionResult result, FormMethod formMethod) {
            return htmlHelper.BeginForm(result, formMethod, null);
        }

        public static MvcForm BeginForm(this HtmlHelper htmlHelper, ActionResult result, FormMethod formMethod, object htmlAttributes) {
            return BeginForm(htmlHelper, result, formMethod, new RouteValueDictionary(htmlAttributes));
        }

        public static MvcForm BeginForm(this HtmlHelper htmlHelper, ActionResult result, FormMethod formMethod, IDictionary<string, object> htmlAttributes) {
            var callInfo = (IT4MVCActionResult)result;
            return htmlHelper.BeginForm(callInfo.Action, callInfo.Controller, callInfo.RouteValues, formMethod, htmlAttributes);
        }

        public static string Action(this UrlHelper urlHelper, ActionResult result) {
            return urlHelper.RouteUrl(result.GetRouteValueDictionary());
        }

        public static string ActionLink(this AjaxHelper ajaxHelper, string linkText, ActionResult result, AjaxOptions ajaxOptions) {
            return ajaxHelper.RouteLink(linkText, result.GetRouteValueDictionary(), ajaxOptions);
        }

        public static string ActionLink(this AjaxHelper ajaxHelper, string linkText, ActionResult result, AjaxOptions ajaxOptions, object htmlAttributes) {
            return ajaxHelper.RouteLink(linkText, result.GetRouteValueDictionary(), ajaxOptions, new RouteValueDictionary(htmlAttributes));
        }

        public static string ActionLink(this AjaxHelper ajaxHelper, string linkText, ActionResult result, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes) {
            return ajaxHelper.RouteLink(linkText, result.GetRouteValueDictionary(), ajaxOptions, htmlAttributes);
        }

        public static Route MapRoute(this RouteCollection routes, string name, string url, ActionResult result) {
            return routes.MapRoute(name, url, result, (ActionResult)null);
        }

        public static Route MapRoute(this RouteCollection routes, string name, string url, ActionResult result, object defaults) {
            // Start by adding the default values from the anonymous object (if any)
            var routeValues = new RouteValueDictionary(defaults);

            // Then add the Controller/Action names and the parameters from the call
            foreach (var pair in result.GetRouteValueDictionary()) {
                routeValues.Add(pair.Key, pair.Value);
            }

            // Create and add the route
            var route = new Route(url, routeValues, new MvcRouteHandler());
            routes.Add(name, route);
            return route;
        }

        public static RouteValueDictionary GetRouteValueDictionary(this ActionResult result) {
            return ((IT4MVCActionResult)result).RouteValues;
        }

        public static void InitMVCT4Result(this IT4MVCActionResult result, string controller, string action) {
            result.Controller = controller;
            result.Action = action; ;
            result.RouteValues = new RouteValueDictionary();
            result.RouteValues.Add("Controller", controller);
            result.RouteValues.Add("Action", action);
        }
    }
}

[CompilerGenerated]
public interface IT4MVCActionResult {
    string Action { get; set; }
    string Controller { get; set; }
    RouteValueDictionary RouteValues { get; set; }
}

[CompilerGenerated]
public class T4MVC_ActionResult : ActionResult, IT4MVCActionResult {
    public T4MVC_ActionResult(string controller, string action): base()  {
        this.InitMVCT4Result(controller, action);
    }
     
    public override void ExecuteResult(System.Web.Mvc.ControllerContext context) { }
    
    public string Controller { get; set; }
    public string Action { get; set; }
    public RouteValueDictionary RouteValues { get; set; }
}


namespace Links {
    [CompilerGenerated]
    public static class @Scripts {
        public static string Url() { return VirtualPathUtility.ToAbsolute("~/Scripts"); }
        public static string Url(string fileName) { return VirtualPathUtility.ToAbsolute("~/Scripts/" + fileName); }
        public static readonly string jquery_1_3_2_vsdoc_js = Url("jquery-1.3.2-vsdoc.js");
        public static readonly string jquery_1_3_2_js = Url("jquery-1.3.2.js");
        public static readonly string jquery_1_3_2_min_vsdoc_js = Url("jquery-1.3.2.min-vsdoc.js");
        public static readonly string jquery_1_3_2_min_js = Url("jquery-1.3.2.min.js");
        public static readonly string MicrosoftAjax_debug_js = Url("MicrosoftAjax.debug.js");
        public static readonly string MicrosoftAjax_js = Url("MicrosoftAjax.js");
        public static readonly string MicrosoftMvcAjax_debug_js = Url("MicrosoftMvcAjax.debug.js");
        public static readonly string MicrosoftMvcAjax_js = Url("MicrosoftMvcAjax.js");
    }

    [CompilerGenerated]
    public static class @Content {
        public static string Url() { return VirtualPathUtility.ToAbsolute("~/Content"); }
        public static string Url(string fileName) { return VirtualPathUtility.ToAbsolute("~/Content/" + fileName); }
        public static readonly string Site_css = Url("Site.css");
    }

}

#endregion T4MVC
