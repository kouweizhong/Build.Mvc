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
    using System.Web.Mvc.Html;

    using Build.Mvc.Helpers;

    /// <summary>
    /// An HTML Builder for Html.DropDownListFor(expression, selectList, optionLabel, htmlAttributes)
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    /// <typeparam name="TProperty"></typeparam>
    public class DropDownListBuilder<TModel, TProperty> : FormInputBuilder<TModel, TProperty>, ISelectListBuilder
    {
        public override string ToHtmlString()
        {
            return this.ApplySurroundWithTemplate(Html.DropDownListFor(InitExpression, this.SelectList(), this.OptionLabel(), HtmlAttributes).ToHtmlStringSafe());
        }
    }

    /// <summary>
    /// An HTML Builder for Html.DropDownList(name, selectList, optionLabel, htmlAttributes)
    /// </summary>
    public class DropDownListBuilder : FormInputBuilder, ISelectListBuilder
    {
        public override string ToHtmlString()
        {
            return this.ApplySurroundWithTemplate(Html.DropDownList(this.Name(), this.SelectList(), this.OptionLabel(), HtmlAttributes).ToHtmlStringSafe());
        }
    }
}