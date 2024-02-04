using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Team1.Models.Infra
{
    public class UploadFileHelper
    {
        public string UploadFile(HttpPostedFileBase file, string path) 
        {
            //判斷資料夾是否存在
            if (!Directory.Exists(path)) throw new ArgumentNullException($"資料夾不存在{path}");
            //判斷有無上傳檔案，若沒有，在ModelState裡加入error
            if (file == null || file.ContentLength == 0) throw new ArgumentNullException("file");

            //取得副檔名定判斷是不是允許的檔案類型
            string[] allowExts = { ".jpg", ".jpeg", ".png" };
            string ext = Path.GetExtension(file.FileName).ToLower();
            if (!allowExts.Contains(ext)) throw new ArgumentNullException($"不允許上傳此類檔案({ext})");

            //為了避免不同時間傳相同檔名，造成覆蓋，所以每次都要取一個唯一檔名
            string fileName = Path.GetRandomFileName();
            string path1 = "../Uploads/";
            //與附檔名合併成一個正常檔名
            string newFileName = fileName + ext;
            string fullName = Path.Combine(path, newFileName);

            string fullName1 = Path.Combine(path1, newFileName);

            //將上傳檔案存放，並取得檔名
            file.SaveAs(fullName);

            return fullName1; 
            //
        }
    }
}