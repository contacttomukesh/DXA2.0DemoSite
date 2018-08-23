using Sdl.Web.Common.Models;
using System;

namespace SDL.Web.Modules.Thumbnail.Models
{
    [SemanticEntity(Vocab = SchemaOrgVocabulary, EntityName = "MultimediaFile", Prefix = "tri", Public = true)]
    [Serializable]
    public partial class MediaFileItem : MediaItem
    {
        [SemanticProperty("tri:headline")]
        public string GenerateThumbnail { get; set; }
        [SemanticProperty("tri:headline")]
        public int Height { get; set; }
        [SemanticProperty("tri:headline")]
        public int Width { get; set; }
        [SemanticProperty("tri:headline")]
        public Image ThumbImage { get; set; }
        public Image GeneratedThumbImage { get; set; }
        public override string ToHtml(string widthFactor, double aspect = 0, string cssClass = null, int containerSize = 0)
        {
            throw new NotImplementedException();
        }
    }
}
