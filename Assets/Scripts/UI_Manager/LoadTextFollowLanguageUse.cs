/* 
* -------------------------------------------Copyright--By--Thuan.NguyenDuc-------------------------------------------------
* -----------------------------------------Email--nguyenducthuanbkdn@gmail.com----------------------------------------------
*/

using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace UIManager
{
    public class LoadTextFollowLanguageUse : MonoBehaviour
    {

        public string assetFileName;
        public bool isUseTextMeshPro;
        public Text[] arrayTexts;
        public TMP_Text[] arrayTextMPs;


        private void Awake()
        {
            ReloadTexts(Utils.LanguageManager.GetLanguageUsing());
        }


        public void ReloadTexts(string language)
        {
            string contentOfAssetFile = Utils.ReadWriteData.LoadContentFileFromStreamingAssetsFolder(assetFileName);
            if (string.IsNullOrEmpty(contentOfAssetFile))
            {
                return;
            }

            Utils.ColumnData dataOfTextsFollowLanguageUse = Utils.CSVReader.GetDataForAColumn(contentOfAssetFile, language);

            if (isUseTextMeshPro)
            {
                int numberTexts = arrayTextMPs.Length;

                for (int i = 0; i < numberTexts; i++)
                {
                    if (arrayTextMPs[i] != null)
                    {
                        arrayTextMPs[i].text = Utils.CSVReader.ReplaceStringInABoxOfCSVFileIntoUnityText(dataOfTextsFollowLanguageUse.DataInColumn[i]);
                    }
                }
            }
            else
            {
                int numberTexts = arrayTexts.Length;

                for (int i = 0; i < numberTexts; i++)
                {
                    if (arrayTexts[i] != null)
                    {
                        arrayTexts[i].text = Utils.CSVReader.ReplaceStringInABoxOfCSVFileIntoUnityText(dataOfTextsFollowLanguageUse.DataInColumn[i]);
                    }
                }
            }
        }
    }
}
