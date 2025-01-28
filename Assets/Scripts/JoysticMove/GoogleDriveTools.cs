using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityGoogleDrive;
using UnityGoogleDrive.Data;
using System.Text;
using Unity.VisualScripting;

namespace lesson2M.Assets.Scripts.JoysticMove
{
    public static class GoogleDriveTools
    {
        public static List<File> FileList()
        {
            List<File> output = new List<File>();
            GoogleDriveFiles.List().OnDone += fileList => { output = fileList.Files; };
            return output;
        }

        public static File Upload(String obj, Action OnDone)
        {
            var file = new UnityGoogleDrive.Data.File {Name = "GameData.json", Content = Encoding.ASCII.GetBytes(obj)};
            GoogleDriveFiles.Create(file).Send();
            return file;
        }

        public static File Download(String fileID)
        {
            File output = new File();
            GoogleDriveFiles.Download(fileID).Send().OnDone += file => { output = file; };
            return output;
        }
    }
}