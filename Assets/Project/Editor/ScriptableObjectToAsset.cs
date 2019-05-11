using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;

/// <summary>
// ScriptableObject���v���n�u�Ƃ��ďo�͂���ėp�X�N���v�g  
/// </summary>
// <remarks>
// �w�肵��ScriptableObject���v���n�u�ɕϊ�����B
// 1.Editor�t�H���_����CreateScriptableObjectPrefub.cs��z�u  
// 2.ScriptableObject�̃t�@�C����I�����ĉE�N���b�N��Create ScriptableObject��I��  
// </remarks>
public class ScriptableObjectToAsset
{
    readonly static string[] labels = { "Data", "ScriptableObject", string.Empty };

    [MenuItem("Assets/Create ScriptableObject")]
    static void Create()
    {
        foreach (Object selectedObject in Selection.objects)
        {
            // get path
            string path = getSavePath(selectedObject);

            // create instance
            ScriptableObject obj = ScriptableObject.CreateInstance(selectedObject.name);
            AssetDatabase.CreateAsset(obj, path);
            labels[2] = selectedObject.name;
            // add label
            ScriptableObject sobj = AssetDatabase.LoadAssetAtPath(path, typeof(ScriptableObject)) as ScriptableObject;
            AssetDatabase.SetLabels(sobj, labels);
            EditorUtility.SetDirty(sobj);
        }
    }

    static string getSavePath(Object selectedObject)
    {
        string objectName = selectedObject.name;
        string dirPath = Path.Combine("Assets", "Resources");
        string path = string.Format("{0}/{1}.asset", dirPath, objectName);

        if (File.Exists(path))
            for (int i = 1; ; i++)
            {
                path = string.Format("{0}/{1}({2}).asset", dirPath, objectName, i);
                if (!File.Exists(path))
                    break;
            }

        return path;
    }
}