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
        public List<string> Upload(HttpFileCollection files, FileType type, bool isSignle, string subFolder)
        {
            if (!File.Exists(subFolder))
            {
                Directory.CreateDirectory(subFolder);
            }
            List<string> data = new List<string>();
            if (isSignle)
            {
                HttpPostedFile file = files[0];
                string fullPath = subFolder + file.FileName;
                data.Add(fullPath);
                file.SaveAs(fullPath);
            }
            else
            {
                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFile file = files[i];
                    string fullPath = subFolder + file.FileName;
                    data.Add(fullPath);
                    file.SaveAs(fullPath);
                }
            }
            return data;
        }

    }
}