using System.Collections.Generic;
using RPG.Editor;
using UnityEditor;
using UnityEngine;

namespace Station
{
    [CustomEditor(typeof(ClipsAnimation))]
    [CanEditMultipleObjects]
    public class ClipsAnimationEditor : UnityEditor.Editor
    {
        private Dictionary<int,bool> _isFolded = new Dictionary<int,bool>();
       

        public override void OnInspectorGUI()
        {
  
            var anim = target as ClipsAnimation;
            if (anim == null) return;
            
        
          
            serializedObject.Update();
            EditorGUILayout.PropertyField(serializedObject.FindProperty("UseDefaultState"));
            if (anim.UseDefaultState)
            {
                EditorGUILayout.BeginVertical("box");
               
               EditorGUILayout.PropertyField(serializedObject.FindProperty("DefaultState"));

               EditorGUILayout.EndVertical();
            }

            if (EditorStatic.Button(true, 28, "Add state", "plus"))
            {
                anim.AnimationModels.Add(new StateData());
                return;
            }
            EditorStatic.DrawLargeLine(2);
            
          for (var index = 0; index < anim.AnimationModels.Count; index++)
          {
              var model = anim.AnimationModels[index];
              if (_isFolded.ContainsKey(index) == false)
              {
                  _isFolded.Add(index, false);
              }

              EditorGUILayout.BeginHorizontal();
              _isFolded[index] = ModelFoldout(model.State, _isFolded[index]);
              if (EditorStatic.Button(24, "plus"))
              {
                  model.AnimationClipModels.Add(new ClipData());
              }

              if (EditorStatic.Button(24, "cross"))
              {
                  anim.AnimationModels.RemoveAt(index);
                  return;
              }
              EditorGUILayout.EndHorizontal();

              EditorGUILayout.BeginVertical("box");
              if (_isFolded[index])
              {
                  model.State = EditorGUILayout.TextField(model.State);
                
                  foreach (var clipData in model.AnimationClipModels)
                  {
                      EditorGUILayout.BeginHorizontal();
                      clipData.Clip = (AnimationClip)EditorGUILayout.ObjectField("Clip:", clipData.Clip, typeof(AnimationClip),false);
                      if (EditorStatic.Button(true, 20, "", "cross"))
                      {
                          model.AnimationClipModels.Remove(clipData);
                          return;
                      }
                      EditorGUILayout.EndHorizontal();
                      clipData.Weight = EditorGUILayout.FloatField("weight:", clipData.Weight);
                      clipData.LayerIndex= EditorGUILayout.IntField("Layer index:", clipData.LayerIndex);
                  }
              }

            
              EditorGUILayout.EndVertical();
              EditorStatic.DrawThinLine(1);
          }

          SetClipLegacy();
            SetAnimation();
            serializedObject.ApplyModifiedProperties();
        }
        
        public static bool ModelFoldout(string title, bool display)
        {
            int height = 30;
            Color bgColor = Color.white;
            var style = new GUIStyle("ShurikenModuleTitle");
            style.font = new GUIStyle(EditorStyles.boldLabel).font;
            float verticalOffset = height * 0.2f;
            GUI.backgroundColor = bgColor;

            style.border = new RectOffset(15, 7, (int)verticalOffset, (int)verticalOffset);
            style.fixedHeight = height;
            style.contentOffset = new Vector2(20f, -2);

            var rect = GUILayoutUtility.GetRect(16f, height, style);
            GUI.Box(rect, title, style);
            var e = Event.current;

            var toggleRect = new Rect(rect.x + 4f, rect.y+5, 13f, 13f);
            if (e.type == EventType.Repaint) {
                EditorStyles.foldout.Draw(toggleRect, false, false, display, false);
            }

            if (e.type == EventType.MouseDown && rect.Contains(e.mousePosition)) 
            {
                display = !display;
                e.Use();
            }
            GUI.backgroundColor = Color.white;
            return display;
        }

        private void SetClipLegacy()
        {
            var anim = target as ClipsAnimation;

            if (anim || anim.AnimationModels!= null)
            {
                foreach (var animation in anim.AnimationModels)
                {
                    if (animation.AnimationClipModels != null)
                    {
                        foreach (var entry in animation.AnimationClipModels)
                        {
                            if (entry.Clip)
                            {
                                entry.Clip.legacy = true;
                            }

                          
                        }
                    }

                   
                }
            }
        }

        private void SetAnimation()
        {
            var anim = target as ClipsAnimation;
            var animation = anim.GetComponent<Animation>();
            if (animation)
            {
                animation.playAutomatically = false;
            }
        }
    }
}

