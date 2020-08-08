/* 
* -------------------------------------------Copyright--By--Thuan.NguyenDuc-------------------------------------------------
* -----------------------------------------Email--nguyenducthuanbkdn@gmail.com----------------------------------------------
*/

using UnityEngine;
using System.IO;

namespace Utils
{
    public static class ReadWriteData
    {

        public enum SpecialFolders
        {
            STREAMING_ASSETS = 11111,
            ASSET_BUNDLE = 22222,
            RESOURCES = 33333,
        }


        public static string GetFilePathFromPersistentDataPath(string fileName)
        {
            #if UNITY_EDITOR
            return Application.dataPath + "/DataOnEditor/" + fileName;
            #elif UNITY_ANDROID
            return Path.Combine(Application.persistentDataPath, fileName);
            #elif UNITY_IOS
            return Path.Combine(Application.persistentDataPath, fileName);
            #else
            return Path.Combine(Application.persistentDataPath, fileName);
            #endif
        }


        public static string LoadContentFileFromResources(string fileName, string fileNameExtension = ".json")
        {
            fileName = fileName.Replace(fileNameExtension, "");
            TextAsset content = Resources.Load<TextAsset>(fileName);
            return content.ToString();
        }


        public static string LoadContentFileFromStreamingAssetsFolder(string fileName)
        {
            string filePath = Path.Combine(Application.streamingAssetsPath, fileName);

            if (Application.platform == RuntimePlatform.Android)
            {
                WWW www = new WWW(filePath);

                while (!www.isDone)
                {
                }

                return www.text;
            }
            else
            {
                if (File.Exists(filePath) == false)
                {
                    return null;
                }

                return File.ReadAllText(filePath);
            }
        }


        public static string GetDataFromPersistentDataPath(string fileName, SpecialFolders copyFileFromThisSpecialFolder)
        {
            string filePath = GetFilePathFromPersistentDataPath(fileName);

            if (!File.Exists(filePath))
            {
                File.Create(filePath).Dispose();

                if (File.Exists(filePath))
                {
                    if (copyFileFromThisSpecialFolder == SpecialFolders.RESOURCES)
                    {
                        File.WriteAllBytes(filePath, System.Text.Encoding.UTF8.GetBytes(LoadContentFileFromResources(fileName)));
                    }
                    else if (copyFileFromThisSpecialFolder == SpecialFolders.STREAMING_ASSETS)
                    {
                        File.WriteAllBytes(filePath, System.Text.Encoding.UTF8.GetBytes(LoadContentFileFromStreamingAssetsFolder(fileName)));
                    }
                }
            }

            return System.Text.Encoding.UTF8.GetString(File.ReadAllBytes(filePath));
        }


        public static T GetJsonDataFromResourcesFolder<T>(string fileName)
        {
            string jsonString = LoadContentFileFromResources(fileName);
            return JsonUtility.FromJson<T>(jsonString);
        }


        public static T GetJsonDataFromFromPersistentDataPath<T>(string fileName)
        {
            string jsonString = GetDataFromPersistentDataPath(fileName, SpecialFolders.RESOURCES);
            return JsonUtility.FromJson<T>(jsonString);
        }


        public static void SaveDataIntoPersistentDataPath<T>(T classData, string fileName)
        {
            string filePath = GetFilePathFromPersistentDataPath(fileName);
            string jsonDatas = JsonUtility.ToJson(classData, true);

            if (File.Exists(filePath))
            {
                File.WriteAllBytes(filePath, System.Text.Encoding.UTF8.GetBytes(jsonDatas));
            }
        }
    }
}
