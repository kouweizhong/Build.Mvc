﻿// -----------------------------------------------------------------------------
// Designed by geeks in Michigan.  Assembled by a compiler near you.
// -----------------------------------------------------------------------------
// 
// Copyright (c) 2011-2012 Jeremy Bell, Laurence Blackledge
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// 
// It is pitch black. You are likely to be eaten by a grue.
// 

namespace Build.Mvc.Html
{
    using System.Threading;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;
    using System.Web.Routing;

    using Build.Mvc.Helpers;

    /// <summary>
    /// A Html Builder for creating &lt;form&gt; tags.
    /// </summary>
    public class MvcFormBuilder : FormInputBuilder, IMvcFormBuilder
    {
        private RouteValueDictionary _routeValues;

        /// <summary>
        ///     Initializes a new instance of the <see cref="MvcFormBuilder" /> class.
        /// </summary>
        public MvcFormBuilder()
        {
            this.Prop("FormMethod", System.Web.Mvc.FormMethod.Post);
            this.IncludeImplicitMvcValues(true);
        }

        /// <summary>
        ///     Gets or sets the form method.
        /// </summary>
        /// <value>
        ///     The form method.
        /// </value>
        public virtual System.Web.Mvc.FormMethod FormMethod
        {
            get { return this.Prop<System.Web.Mvc.FormMethod>("FormMethod"); }
            set { this.Prop("FormMethod", value); }
        }

        /// <summary>
        ///     Gets or sets the route values.
        /// </summary>
        /// <value>
        ///     The route values.
        /// </value>
        public virtual RouteValueDictionary RouteValues
        {
            get { return LazyInitializer.EnsureInitialized(ref _routeValues); }
            set { _routeValues = value; }
        }

        public virtual MvcForm Begin()
        {
            return BuildHelpers.FormHelper(Html, DetermineFormAction(), FormMethod, HtmlAttributes);
        }

        public override string ToHtmlString()
        {
            Begin();
            return "";
        }

        protected virtual string DetermineFormAction()
        {
            string formAction = this.Attr("action");
            if ( string.IsNullOrEmpty(formAction) )
            {
                string routeName = this.RouteName();
                if ( !string.IsNullOrEmpty(routeName) || RouteValues.Count > 0 )
                {
                    formAction = UrlHelper.GenerateUrl(routeName, null, null, RouteValues, Html.RouteCollection, Html.ViewContext.RequestContext, this.IncludeImplicitMvcValues());
                }
                else
                {
                    formAction = Html.ViewContext.HttpContext.Request.RawUrl;
                }
            }
            return formAction;
        }
    }
}