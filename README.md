# Load Unity Texts Follow Language Use
This project provides a small plugin to load the content of texts of the screen that follow the language is using.
The content of texts will be loaded from CSV file. Only need some mins to understand about this plugin.

Via __CustomLoadText.cs__ (Assets/Editor/Scripts/CustomLoadText.cs) script, a script is used to custom Unity Editor. And __LoadTextFollowLanguageUse.cs__ (Assets/Scripts/UI_Manager/LoadTextFollowLanguageUse.cs) script, a script is used to reload the texts if user just changed the language.


# Usage

Step 1: Create a CSV file to contain the contents that you want to load into Unity-texts (you can use Excel tool or Google Sheets to create CSV file)
        Put this CSV file to StreamingAssets folder on Unity Editor (Assets/StreamingAssets)
        Check example below to know about the contents of CSV file:
        <div align="center">
        <img width="900" src="https://github.com/NguyenDucThuanBKDN/LoadTextsFollowLanguageUse/blob/master/Document/IMG_1.png"></img>
        </div>

Step 2: Create a new gameobject and attach __LoadTextFollowLanguageUse.cs__ script.
        In Inspector window, enter the name of CSV file to __Asset File Name__ property, then an array of Texts will appear.
        This array contains all Unity-texts that you want to auto change follow the language is using.
        <div align="center">
        <img width="900" src="https://github.com/NguyenDucThuanBKDN/LoadTextsFollowLanguageUse/blob/master/Document/IMG_2.gif"></img>
        </div>
        Drag-drop the corresponding text gameobjects to that array.
        <div align="center">
        <img width="900" src="https://github.com/NguyenDucThuanBKDN/LoadTextsFollowLanguageUse/blob/master/Document/IMG_3.gif"></img>
        </div>

Step 3: Call __ReloadTexts(string language)__ from __LoadTextFollowLanguageUse__ component when have the event that user is changing language.

Done, if you change the language, the content of all Unity-texts will be changed following that language.
<div align="center">
<img width="900" src="https://github.com/NguyenDucThuanBKDN/LoadTextsFollowLanguageUse/blob/master/Document/IMG_4.gif"></img>
</div>

If you are using __Text Mesh Pro__ instead of the default Text UI of Unity, you only need to check __Is Use Text Mesh Pro__ at __LoadTextFollowLanguageUse__ component.
<div align="center">
<img width="900" src="https://github.com/NguyenDucThuanBKDN/LoadTextsFollowLanguageUse/blob/master/Document/IMG_5.gif"></img>
</div>


# Note

There are two rules that you have to implement as below:
1. If you want to implement another language, open __LanguageManager.cs__ script and then edit for __Languages__ enum and __dicLanguages__ dictionary.
   The value of __dicLanguages__ dictionary must be like as the column name of CSV file.
   <div align="center">
   <img width="900" src="https://github.com/NguyenDucThuanBKDN/LoadTextsFollowLanguageUse/blob/master/Document/IMG_5.png"></img>
   </div>

2. If the content of text has the break line charater __('\n')__ or comma character __(',')__, you must be changed these charater to the symbol below:
   __<bl>__  <===> break line character __('\n')__
   __<nc>__  <===> comma character __(',')__
        
   For example:
   <div align="center">
   <img width="900" src="https://github.com/NguyenDucThuanBKDN/LoadTextsFollowLanguageUse/blob/master/Document/IMG_6.png"></img>
   </div>
   <div align="center">
   <img width="900" src="https://github.com/NguyenDucThuanBKDN/LoadTextsFollowLanguageUse/blob/master/Document/IMG_7.png"></img>
   </div>
  
# Example
For example, you can checkout this project and try to test. 
