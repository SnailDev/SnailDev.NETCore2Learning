using Microsoft.AspNetCore.Mvc.Razor;

namespace MyWebsite.Utils
{
    public abstract class CustomRazorPage<TModel> : RazorPage<TModel>
    {
        public string CustomText { get; } = "CustomRazorPage.CustomText";
    }
}