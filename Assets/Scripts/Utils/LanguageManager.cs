/* 
* -------------------------------------------Copyright--By--Thuan.NguyenDuc-------------------------------------------------
* -----------------------------------------Email--nguyenducthuanbkdn@gmail.com----------------------------------------------
*/

using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public static class LanguageManager
    {

        private const string KEY_LANGUAGE_USING = "languageUsing";

        public enum Languages
        {
            VietNamese,
            English,
            Japanese,
        }

        public static readonly Dictionary<Languages, string> dicLanguages = new Dictionary<Languages, string>()
        {
            { Languages.VietNamese, "VietNamese"},
            { Languages.English, "English"},
            { Languages.Japanese, "Japanese"},
        };


        public static string GetLanguageUsing()
        {
            if (PlayerPrefs.HasKey(KEY_LANGUAGE_USING))
            {
                return PlayerPrefs.GetString(KEY_LANGUAGE_USING);
            }

            return dicLanguages[Languages.English];
        }


        public static void SetLanguageUsing(string languageUsing)
        {
            PlayerPrefs.SetString(KEY_LANGUAGE_USING, languageUsing);
        }
    }
}
