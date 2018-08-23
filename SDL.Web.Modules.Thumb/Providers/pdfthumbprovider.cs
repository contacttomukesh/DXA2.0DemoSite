using GhostscriptSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDL.Web.Modules.GhostScript.Providers
{
    public class pdfthumbprovider
    {
        /// <summary>
        /// Create thumbnail of pdf file
        /// </summary>
        /// <param name="inputFile">pdf file full path</param>
        /// <param name="thumbnailPath">thumbnail image full path</param>
        /// <param name="pageNo">page no of which to create thumbnail</param>
        /// <param name="width">Width of thumbnail</param>
        /// <param name="height">Height of thumbnail</param>
        public static void GenerateThumbnailImageForPdf(string inputFile, string thumbnailPath, int pageNo, int width, int height)
        {
            try
            {
                GhostscriptWrapper.GeneratePageThumb(inputFile, thumbnailPath, pageNo, width, height);
            }
            catch (Exception ex)
            {
                // Ignores to show the default thumb
            }
        }
    }
}
