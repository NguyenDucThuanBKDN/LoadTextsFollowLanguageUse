using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Test
{
    public class TestLoadTexts : MonoBehaviour
    {

        [SerializeField] private Dropdown languageDropdown;

        private UIManager.LoadTextFollowLanguageUse mLoadTextFollowLanguageUse;
        private string mCurrentLanguage;


        private void Awake()
        {
            SettupLanguageDropdown();
        }


        private void Start()
        {
            RegisterAllListeners();
            mLoadTextFollowLanguageUse = FindObjectOfType<UIManager.LoadTextFollowLanguageUse>();
            mCurrentLanguage = Utils.LanguageManager.GetLanguageUsing();
        }


        private void OnDisable()
        {
            Utils.LanguageManager.SetLanguageUsing(mCurrentLanguage);
            RemoveAllListeners();
        }


        private void RegisterAllListeners()
        {
            if (languageDropdown)
            {
                languageDropdown.onValueChanged.AddListener(delegate { OnLanguageChange(); });
            }
        }


        private void RemoveAllListeners()
        {
            if (languageDropdown)
            {
                languageDropdown.onValueChanged.RemoveListener(delegate { OnLanguageChange(); });
            }
        }


        private void SettupLanguageDropdown()
        {
            if (languageDropdown == null)
            {
                return;
            }

            languageDropdown.ClearOptions();
            List<string> options = new List<string>();

            foreach (var item in Utils.LanguageManager.dicLanguages)
            {
                options.Add(item.Value);
            }

            languageDropdown.AddOptions(options);

            int length = languageDropdown.options.Count;
            for (int i = 0; i < length; i++)
            {
                if (languageDropdown.options[i].text == Utils.LanguageManager.GetLanguageUsing())
                {
                    languageDropdown.value = i;
                    break;
                }
            }
        }


        private void OnLanguageChange()
        {
            if (languageDropdown == null)
            {
                return;
            }

            string languageWantToChange = languageDropdown.options[languageDropdown.value].text;

            if (mCurrentLanguage.Equals(languageWantToChange) == false)
            {
                if (mLoadTextFollowLanguageUse != null)
                {
                    mLoadTextFollowLanguageUse.ReloadTexts(languageWantToChange);
                    mCurrentLanguage = languageWantToChange;
                }
            }
        }
    }
}
