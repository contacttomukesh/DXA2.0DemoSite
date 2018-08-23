using Sdl.Web.Common.Configuration;
using Sdl.Web.Common.Logging;
using Sdl.Web.Common.Models;
using Sdl.Web.Mvc.Configuration;
using Sdl.Web.Mvc.Controllers;
using SDL.Web.Modules.GhostScript.Providers;
using SDL.Web.Modules.Thumbnail.Models;
using System;
using System.IO;

namespace SDL.Web.Modules.Thumbnail.Controllers
{
    /// <summary>
    /// Custom controller to generate thumbnail of files
    /// </summary>
	public class ThumbController : EntityController
    {
        private const string Xl = "application/ms-excel";
        private const string Xlx = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        private const string Zipc = "application/x-zip-compressed";
        private const string Zip = "application/zip";
        private const string Doc = "application/msword";
        private const string Docx = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
        private const string Pptx = "application/vnd.openxmlformats-officedocument.presentationml.presentation";
        private const string Ppt = "application/ms-powerpoint";
        /// <summary>
        /// Enrich the SearchQuery View Model with request querystring parameters and populate the results using a configured Search Provider.
        /// </summary>
        protected override ViewModel EnrichModel(ViewModel model)
        {
            using (new Tracer(model))
            {
                base.EnrichModel(model);
                MediaFileItem mediaFile = model as MediaFileItem;
                if (mediaFile.GeneratedThumbImage.Equals(true))
                {
                    string inputPath = GetFilePathFromUrl(mediaFile.Url, WebRequestContext.Localization);
                    if (inputPath.Contains("\\downloads\\"))
                    {
                        FileInfo inputFileInfo = new FileInfo(inputPath);
                        mediaFile.FileSize = inputFileInfo.Exists ? inputFileInfo.Length : mediaFile.FileSize;
                    }
                    string outputPath = Server.MapPath("~/downloads/" + WebRequestContext.Localization.LocalizationId + WebRequestContext.Localization.Path + "/thumb/" + System.IO.Path.ChangeExtension(mediaFile.FileName, ".jpg"));
                    int width = 64;
                    int height = 82;
                    FileInfo fileInfo = new FileInfo(outputPath);
                    if (!System.IO.File.Exists(outputPath))
                    {
                        if (fileInfo.Directory != null && !fileInfo.Directory.Exists)
                        {
                            fileInfo.Directory.Create();
                        }
                        if (!System.IO.File.Exists(inputPath))
                        {
                            try
                            {
                                SiteConfiguration.ContentProvider.GetStaticContentItem(mediaFile.Url, WebRequestContext.Localization);
                            }
                            catch (Exception ex)
                            {
                                Log.Warn("No static content found: " + ex.StackTrace);
                            }
                        }
                        if (mediaFile.MimeType.Equals("application/pdf"))
                        {
                            pdfthumbprovider.GenerateThumbnailImageForPdf(inputPath, outputPath, 1, width, height);
                        }
                    }
                    string imageUrl = fileInfo.Exists ? WebRequestContext.Localization.Path + "/downloads/" + WebRequestContext.Localization.LocalizationId + WebRequestContext.Localization.Path + "/thumb/" + System.IO.Path.ChangeExtension(mediaFile.FileName, ".jpg") : "/Content/images/2006/downloads/thumbnail-pdf.jpg"; ;
                    if (mediaFile.MimeType.Equals("application/pdf") && System.IO.File.Exists(outputPath))
                    {

                    }
                    switch (mediaFile.MimeType)
                    {
                        case Xl:
                        case Xlx:
                            imageUrl = "/Content/images/2006/downloads/thumbnail-xls.jpg";
                            break;
                        case Zip:
                        case Zipc:
                            imageUrl = "/Content/images/2006/downloads/thumbnail-zip.jpg";
                            break;
                        case Doc:
                        case Docx:
                            imageUrl = "/Content/images/2006/downloads/thumbnail-default.jpg";
                            break;
                        case Ppt:
                        case Pptx:
                            imageUrl = "/Content/images/2006/downloads/thumbnail-ppt.jpg";
                            break;

                    }
                }
                return mediaFile;
            }
        }
        //Get Image Url
        private string GetImageUrl()
        {
            return "";
        }

        public string GetFilePathFromUrl(string urlPath, Localization loc)
        {
            return "";
        }
    }
}
