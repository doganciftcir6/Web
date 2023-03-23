using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using shopapp.businness.Abstract;

namespace shopapp.webui.ViewComponents
{
    public class CategoriesViewComponent:ViewComponent
    {
        //inject
        private ICategoryService _categoryService;
        public CategoriesViewComponent(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }
        public IViewComponentResult Invoke()
        {
            if (RouteData.Values["category"] != null)
                ViewBag.SelectedCategory = RouteData?.Values["category"];
            //Category Repository i�indeki  _categories listemizi bu �ekilde alabiliriz get metotu sayesinde
            return View(_categoryService.GetAll());
        }
    }
}