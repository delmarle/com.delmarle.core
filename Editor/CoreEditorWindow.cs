using System.Collections;
using System.Collections.Generic;
using Station;
using UnityEditor;
using UnityEngine;

namespace RPG.Editor
{
    public class CoreEditorWindow : EditorWindow
    {
        int _toolBarIndex;
        
        [MenuItem("Tools/Core")]
        private static void ShowWindow()
        {
            EditorStatic.LoadStyles();
            CoreEditorWindow myWindow = GetWindow<CoreEditorWindow>("Core");
            myWindow.minSize = new Vector2(1024, 600);
            myWindow.maxSize = myWindow.minSize*2;
            myWindow.titleContent = new GUIContent("Core");
            myWindow.Show();
        }
        
        private void OnDestroy()
        {
           // Debug.Log("saving all items entries");
        }

        private void OnGUI()
        {
            if (EditorApplication.isCompiling) return;
            if (EditorStatic.PublisherNameStyle == null)
            {
                EditorStatic.LoadStyles();
                return;
            }

      
            DrawHeader();
            DrawBody();
            DrawFooter();
        }

        private void DrawHeader()
        { 
            EditorStatic.Space();
      
            GUILayout.Label(new GUIContent(EditorStatic.WINDOW_TITLE, EditorStatic.GetEditorTexture("core_small")), EditorStatic.PublisherNameStyle);
            EditorStatic.Space();
            _toolBarIndex = GUILayout.Toolbar(_toolBarIndex, EditorStatic.ToolbarOptions, EditorStatic.ToolBarStyle,
                EditorStatic.ToolbarHeight);
        }

        private void DrawBody()
        {
            switch (_toolBarIndex)
            {
                case 0:
                    ConfigTabEditor.DrawContent();
                    break;
                case 1:
                    //StatsTab.DrawTab();
                    break;
                case 5:
                    FloatingPopupEditor.DrawContent();
                    break;
                case 6:
                    UiNotificationChannelsEditor.DrawContent();
                    break;
                case 7:
                    SoundTabEditor.DrawContent();
                    break;
                case 8:
                    FootStepsTabEditor.DrawContent();
                    break;
                case 9:
                    FieldsPrefabsEditor.DrawContent();
                    break;
            }
        }

        private void DrawFooter()
        {
            EditorGUILayout.LabelField(new GUIContent("version 1.0"), EditorStatic.CenteredVersionLabel);
        }
    }
}

