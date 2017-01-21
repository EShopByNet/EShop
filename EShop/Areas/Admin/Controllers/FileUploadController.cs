using EShop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShop.Areas.Admin.Controllers
{
    public class FileUploadController : Controller
    {
        private FileUploadService fileUpload = new FileUploadService();

        private readonly string defSubFolder = "upload/";

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="httpContent"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Upload(string type)
        {
            string subFolder = Request.Params.Get("subFolder");
            if (null == subFolder || "" == subFolder || " " == subFolder)
            {
                subFolder = Server.MapPath(defSubFolder);
            }
            else
            {
                subFolder = Server.MapPath(subFolder+"/");
            }
            HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
            bool isSingle = false;
            if (files.Count <= 1)
            {
                isSingle = true;
            }
            List<string> data = null;
            switch (type)
            {
                case "picture":
                    data = fileUpload.Upload(files, FileType.picture, isSingle, subFolder);
                    break;
                case "video":
                    data = fileUpload.Upload(files, FileType.video, isSingle, subFolder);
                    break;
                case "zip":
                    data = fileUpload.Upload(files, FileType.zip, isSingle, subFolder);
                    break;
                default:
                    data = fileUpload.Upload(files, FileType.other, isSingle, subFolder);
                    break;
            }
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = data;
            return result;
        } 

    }
}