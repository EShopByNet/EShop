using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace EShop.Service
{

    public enum FileType
    {
        picture ,
        video , 
        zip , 
        other
    }

    /// <summary>
    /// 文件上传service
    /// </summary>
    public class FileUploadService
    {

        /// <summary>
        /// 多文件批量上传
        /// </summary>
        /// <param name="files"></param>
        /// <param name="type">文件类型</param>
        public string Upload(HttpPostedFileBase file, string subFolder)
        {
            if (!File.Exists(subFolder))
            {
                Directory.CreateDirectory(subFolder);
            }
            string fullPath = subFolder + file.FileName;
            file.SaveAs(fullPath);
            return fullPath.Substring(AppDomain.CurrentDomain.BaseDirectory.Length-1);
        }

    }
}