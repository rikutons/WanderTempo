using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SymbolReplacer : UnityEditor.AssetModificationProcessor {
    
    public static void OnWillCreateAsset(string path) {
        const int NameSpaceDepth = 2;
        // メタファイルからファイルパスを
        path = path.Replace(".meta", "");
        // 拡張子チェック
        int index = path.LastIndexOf(".");
        // フォルダなどの場合は拡張子なし
        if (index < 0) {
            return;
        }
        string ext = path.Substring(index);
        if (ext != ".cs" && ext != ".js" && ext != ".boo") {
            return;
        }
        
        // 対象ファイルの読み込み
        index = Application.dataPath.LastIndexOf("Assets");
        string fullPath = Application.dataPath.Substring(0, index) + path;
        string file = System.IO.File.ReadAllText(fullPath);
        
        // カスタム置換シンボルを走査して変換
        file = file.Replace("#CREATED#", System.DateTime.Now.ToString("yyy-MM-dd"));
        file = file.Replace("#PROJECT_NAME#", PlayerSettings.productName);
        
        List<string> array = path.Split('/').ToList();
        index = array.LastIndexOf("Scripts");
        if (index >= 0) {   // 見つかった場合
            array[index] = "";            // namespace用にScriptsを消す（これは好み）
            array.RemoveRange(0, index);     // App（Scripts）上位を削除
            while(array.Count>NameSpaceDepth)
                array.Remove(array.Last());      // ファイル名部分を削除
            
            string pathBelowScripts = string.Join(".", array.ToArray());    // ドットでつなげる
            file = file.Replace( "#NAMESPACE#", pathBelowScripts);
            
        }
        
        // ファイル上書きで作成完了
        System.IO.File.WriteAllText(fullPath, file);
        AssetDatabase.Refresh();
    }
}