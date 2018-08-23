using Sdl.Web.Mvc.Configuration;
using SDL.Web.Modules.Thumbnail.Models;

namespace SDL.Web.Modules.Thumbnail
{
    public class ThumbnailAreaRegistration : BaseAreaRegistration
    {
        public override string AreaName => "Thumbnail";

        protected override void RegisterAllViewModels()
        {
            // Thumb Entity Views
            RegisterViewModel("ThumbIcon", typeof(MediaFileItem), "Thumb");
        }
    }
}