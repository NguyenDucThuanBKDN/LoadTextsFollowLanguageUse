/* 
* -------------------------------------------Copyright--By--Thuan.NguyenDuc-------------------------------------------------
* -----------------------------------------Email--nguyenducthuanbkdn@gmail.com----------------------------------------------
*/

#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

[UnityEditor.CustomEditor(typeof(UIManager.LoadTextFollowLanguageUse))]
public class CustomLoadText : UnityEditor.Editor
{

    private string[] mArrayTextName;

    private SerializedProperty mAssetFileName;
    private SerializedProperty mIsUseTextMeshPro;
    private SerializedProperty mPropArrayTexts;
    private SerializedProperty mPropArrayTextMeshPro;
    private MonoScript mScript;

    private const string ASSET_FILE_NAME_PROPERTY = "assetFileName";
    private const string IS_USE_TEXT_MESH_PRO_PROPERTY = "isUseTextMeshPro";
    private const string ARRAY_TEXTS_PROPERTY = "arrayTexts";
    private const string ARRAY_TEXTMESH_PRO_PROPERTY = "arrayTextMPs";
    private const string ARRAY_PROPERTY_RELATIVE = "Array.size";
    private const string SCRIPT_PROPERTY = "Script";


    private void OnEnable()
    {
        mAssetFileName = serializedObject.FindProperty(ASSET_FILE_NAME_PROPERTY);
        mPropArrayTexts = serializedObject.FindProperty(ARRAY_TEXTS_PROPERTY);
        mIsUseTextMeshPro = serializedObject.FindProperty(IS_USE_TEXT_MESH_PRO_PROPERTY);
        mPropArrayTextMeshPro = serializedObject.FindProperty(ARRAY_TEXTMESH_PRO_PROPERTY);
        mScript = MonoScript.FromMonoBehaviour((UIManager.LoadTextFollowLanguageUse)target);

        LoadNameOfTextsToArray();
    }


    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        if (mScript != null)
        {
            mScript = EditorGUILayout.ObjectField(SCRIPT_PROPERTY, mScript, typeof(MonoScript), false) as MonoScript;
        }

        EditorGUI.BeginChangeCheck();
        EditorGUILayout.PropertyField(mAssetFileName);

        if (EditorGUI.EndChangeCheck())
        {
            LoadNameOfTextsToArray();
        }

        if (mIsUseTextMeshPro != null)
        {
            EditorGUILayout.PropertyField(mIsUseTextMeshPro);

            if (mIsUseTextMeshPro.boolValue == true)
            {
                ShowArrayProperty(mPropArrayTextMeshPro);
            }
            else
            {
                ShowArrayProperty(mPropArrayTexts);
            }
        }

        serializedObject.ApplyModifiedProperties();
    }


    private void ShowArrayProperty(SerializedProperty array)
    {
        if (array == null || mArrayTextName == null)
        {
            return;
        }

        EditorGUILayout.PropertyField(array);
        array.arraySize = mArrayTextName.Length;
        EditorGUI.indentLevel++;

        if (array.isExpanded)
        {
            EditorGUILayout.PropertyField(array.FindPropertyRelative(ARRAY_PROPERTY_RELATIVE));

            for (int i = 0; i < array.arraySize; i++)
            {
                EditorGUILayout.PropertyField(array.GetArrayElementAtIndex(i), new GUIContent(mArrayTextName[i]));
            }
        }

        EditorGUI.indentLevel--;
    }


    private void LoadNameOfTextsToArray()
    {
        if (mAssetFileName == null)
        {
            return;
        }

        string contentOfAssetFile = Utils.ReadWriteData.LoadContentFileFromStreamingAssetsFolder(mAssetFileName.stringValue);
        if (contentOfAssetFile == null)
        {
            mArrayTextName = null;
            return;
        }

        int columnIndexOfTextName = 0;
        Utils.ColumnData nameOfTexts = Utils.CSVReader.GetDataForAColumn(contentOfAssetFile, columnIndexOfTextName);

        if (nameOfTexts != null)
        {
            mArrayTextName = nameOfTexts.DataInColumn;
        }
        else
        {
            mArrayTextName = null;
        }
    }
}
#endif
