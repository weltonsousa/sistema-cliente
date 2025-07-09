﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace WebAppMVC.Extensions
{
    public static class ControllerExtensions
    {
        public static async Task<string> RenderViewAsync<TModel>(this Controller controller, string viewName, TModel model, bool partial = false)
        {
            controller.ViewData.Model = model;

            using var sw = new StringWriter();
            var viewEngine = controller.HttpContext.RequestServices.GetService(typeof(ICompositeViewEngine)) as ICompositeViewEngine;
            var viewResult = viewEngine.FindView(controller.ControllerContext, viewName, !partial);

            if (viewResult.Success == false)
            {
                throw new FileNotFoundException($"View {viewName} not found.");
            }

            var viewContext = new ViewContext(
                controller.ControllerContext,
                viewResult.View,
                controller.ViewData,
                controller.TempData,
                sw,
                new HtmlHelperOptions()
            );

            await viewResult.View.RenderAsync(viewContext);
            return sw.GetStringBuilder().ToString();
        }
    }
}
