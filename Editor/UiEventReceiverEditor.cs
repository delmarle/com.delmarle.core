using System.Collections.Generic;
using RPG.Editor;
using UnityEditor;
using UnityEngine;


namespace Station
{
    [CustomEditor(typeof(UiEventReceiver))]
    [CanEditMultipleObjects]
    public class UiEventReceiverEditor : UnityEditor.Editor
    {
        private List<bool> _foldoutStates = new List<bool>();
        public override void OnInspectorGUI()
        {
            var component = target as UiEventReceiver;
            if (component == null) return;
            SetFoldoutToCorrectSize(component.Events.Count);
            EditorStatic.DrawSectionTitle(24, "Ui Event Receiver");
            if (EditorStatic.Button(true,32,"Add event", "plus"))
            {
                component.Events.Add(new UiEventReceiverData());
                GUIUtility.ExitGUI();
            }
            for (int i = 0; i < component.Events.Count; i++)
            {
                var ev = component.Events[i];
                var so = ev.EventData;
                string name = so != null ? so.name : "empty";
                _foldoutStates[i] = EditorStatic.LevelFoldout(name,  _foldoutStates[i], 22, Color.gray);
               
                if (_foldoutStates[i])
                {
                    ev.EventData = (UiEventData)EditorGUILayout.ObjectField("event asset:", ev.EventData, typeof(UiEventData), false);
                    EditorGUILayout.BeginHorizontal();
                    {
                        if (EditorStatic.Button(true, 22, "Remove event", "cross"))
                        {
                            component.Events.RemoveAt(i);
                            EditorGUILayout.EndVertical();
                            GUIUtility.ExitGUI();
                        }

                     
                    }
                    EditorGUILayout.EndHorizontal();
                  
                    EditorStatic.DrawLargeLine();
                    EditorStatic.DrawSectionTitle(24, "Panels to show:");
                    ev._panelToShow = (UiPanel)EditorGUILayout.ObjectField($"", ev._panelToShow, typeof(UiPanel), true);
                }
            }
        }

        private void SetFoldoutToCorrectSize(int size)
        {
            while (_foldoutStates.Count < size) { _foldoutStates.Add(false); }
            while (_foldoutStates.Count > size) { _foldoutStates.RemoveAt(_foldoutStates.Count - 1); }
        }
    }
}

