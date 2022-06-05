using System;
using System.Collections.Generic;
using RPG.Editor;
using UnityEditor;
using UnityEngine;

namespace Station
{
    public static class ConfigTabEditor
    {
        public static void DrawContent()
        {
           DrawDbCheck();
        }

        private static void DrawDbCheck()
        {
            var dbsType = ReflectionUtils.FindAllDbTypes();
            foreach (var t in dbsType)
            {
                EditorGUILayout.BeginHorizontal("box");
                var dbAsset = EditorStatic.GetDb(t);
                Debug.Log($"t={t} found={dbAsset}");
                if (dbAsset == null)
                {
                    EditorGUILayout.LabelField("missing DB"+t);
                    if (EditorStatic.ButtonAdd("create DB"))
                    {
                        
                        ScriptableHelper.CreateScriptableObject(t, EditorStatic.EDITOR_DB_PATH, t.Name+@".asset");
                    }
                }
                
                EditorGUILayout.EndHorizontal();
            }
        }
    }
}