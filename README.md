# Load Unity Texts Follow Language Use
This project provides a small plugin to load the content of texts of the screen that follow the language is using.
The content of texts will be loaded from CSV file. Only need some mins to understand about this plugin.

Via --CustomLoadText.cs-- (Assets/Editor/Scripts/CustomLoadText.cs) script, a script is used to custom Unity Editor. And --LoadTextFollowLanguageUse.cs-- (Assets/Scripts/UI_Manager/LoadTextFollowLanguageUse.cs) script, a script is used to reload the texts if user just changed the language.


# Usage

Step 1: Create a CSV file to contain the contents that you want to load into Unity-texts (you can use Excel tool or Google Sheets to create CSV file)
        Put this CSV file to StreamingAssets folder on Unity Editor (Assets/StreamingAssets)
        Check example below to know about the contents of CSV file:
        <img width=“900” src=“https://github.com/NguyenDucThuanBKDN/LoadTextsFollowLanguageUse/edit/master/Document/IMG_1.png”>

Step 2: Create a new gameobject and attach --LoadTextFollowLanguageUse.cs-- script.
        In Inspector window, enter the name of CSV file to --Asset File Name-- property, then an array of Texts will appear.
        This array contains all Unity-texts that you want to auto change follow the language is using.
        <img width=“900” src=“https://github.com/NguyenDucThuanBKDN/LoadTextsFollowLanguageUse/edit/master/Document/IMG_2.gif”>
        
        Drag-drop the corresponding text gameobjects to that array.
        <img width=“900” src=“https://github.com/NguyenDucThuanBKDN/LoadTextsFollowLanguageUse/edit/master/Document/IMG_3.gif”>

Step 3: Call --ReloadTexts(string language)-- from --LoadTextFollowLanguageUse-- component when have the event that user is changing language.

Done, if you change the language, the content of all Unity-texts will be changed following that language.
<img width=“900” src=“https://github.com/NguyenDucThuanBKDN/LoadTextsFollowLanguageUse/edit/master/Document/IMG_4.gif”>

If you are using --Text Mesh Pro-- instead of the default Text UI of Unity, you only need to check --Is Use Text Mesh Pro-- at --LoadTextFollowLanguageUse-- component.
<img width=“900” src=“https://github.com/NguyenDucThuanBKDN/LoadTextsFollowLanguageUse/edit/master/Document/IMG_5.gif”>


# Note

There are two rules that you have to implement as below:
1. If you want to implement another language, open --LanguageManager.cs-- script and then edit for --Languages-- enum and --dicLanguages-- dictionary
   The value of --dicLanguages-- dictionary must be like as the column name of CSV file.
   <img width=“900” src=“https://github.com/NguyenDucThuanBKDN/LoadTextsFollowLanguageUse/edit/master/Document/IMG_5.png”>
   
2. If the content of text has the break line charater --('\n')-- or comma character --(',')--, you must be changed these charater to the symbol below:
   --<bl>--  <===> break line character --('\n')--
   --<nc>--  <===> comma character --(',')--
   For example: 
        <img width=“900” src=“https://github.com/NguyenDucThuanBKDN/LoadTextsFollowLanguageUse/edit/master/Document/IMG_6.png”>
        <img width=“900” src=“https://github.com/NguyenDucThuanBKDN/LoadTextsFollowLanguageUse/edit/master/Document/IMG_7.png”>
  
# Example
For example, you can checkout this project and try to test. 
