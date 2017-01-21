using System;
using System.Collections.Generic;
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
            List<string> data = new List<string>();
            if (isSignle)
            {
                HttpPostedFile file = files.Get(1);
                data.Add(subFolder + file.FileName);
                file.SaveAs(data[0]);
            }
            else
            {
                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFile file = files.Get(i);
                    data.Add(subFolder + file.FileName);
                    file.SaveAs(data[i]);
                }
            }
            return data;
        }

    }
}