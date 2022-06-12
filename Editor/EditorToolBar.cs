using UnityEngine;

namespace RPG.Editor
{
  public static partial class EditorStatic
  {
    #region FIELDS
    public static GUIContent[] ToolbarOptions;  
    public static GUILayoutOption ToolbarHeight;
    
    public static GUIContent[] FootStepsToolbarOptions;  
    public static GUIContent[] FieldsPrefabsToolbarOptions;  

    #endregion

    private static void LoadToolBar()
    {
      ToolbarHeight = GUILayout.Height(50);
      ToolbarOptions = new GUIContent[10];
      
      ToolbarOptions[0] = new GUIContent("<size=11><b> Configuration</b></size>",GetEditorTexture("cog"),"");
      ToolbarOptions[1] = new GUIContent("<size=11><b> Difficulty</b></size>", GetEditorTexture("heart"), "");
      ToolbarOptions[2] = new GUIContent("<size=11><b> Options</b></size>", GetEditorTexture("group"), "");
      ToolbarOptions[3] = new GUIContent("<size=11><b> Platforms</b></size>", GetEditorTexture("flag_flyaway_green"), "");
      ToolbarOptions[4] = new GUIContent("<size=11><b> Inputs Event</b></size>", GetEditorTexture("flag_flyaway_green"), "");
      ToolbarOptions[5] = new GUIContent("<size=11><b> Floating Popups</b></size>", GetEditorTexture("flag_flyaway_green"), "");
      ToolbarOptions[6] = new GUIContent("<size=11><b> Ui Channels</b></size>", GetEditorTexture("flag_flyaway_green"), "");
      ToolbarOptions[7] = new GUIContent("<size=11><b> Sounds</b></size>", GetEditorTexture("flag_flyaway_green"), "");
      ToolbarOptions[8] = new GUIContent("<size=11><b> FootSteps</b></size>", GetEditorTexture("flag_flyaway_green"), "");
      ToolbarOptions[9] = new GUIContent("<size=11><b> Ui Prefabs</b></size>", GetEditorTexture("flag_flyaway_green"), "");

      FootStepsToolbarOptions = new GUIContent[3];
      FootStepsToolbarOptions[0] = new GUIContent("<size=11><b> Settings</b></size>", GetEditorTexture("zone"), "");
      FootStepsToolbarOptions[1] = new GUIContent("<size=11><b>  Surfaces</b></size>",GetEditorTexture("legend"),"");
      FootStepsToolbarOptions[2] = new GUIContent("<size=11><b> Templates</b></size>", GetEditorTexture("zone"), "");
      
      FieldsPrefabsToolbarOptions = new GUIContent[3];
      FieldsPrefabsToolbarOptions[0] = new GUIContent("<size=11><b> Fields</b></size>", GetEditorTexture("toolbar_add"), "");
      FieldsPrefabsToolbarOptions[1] = new GUIContent("<size=11><b>  Ui Popups prefabs</b></size>",GetEditorTexture("legend"),"");
      FieldsPrefabsToolbarOptions[2] = new GUIContent("<size=11><b> Pooled prefabs</b></size>", GetEditorTexture("arrow_repeat"), "");
      LoadRpgToolBar();
    }
    
    private static void LoadRpgToolBar()
    {
      ToolbarHeight = GUILayout.Height(50);
      RpgToolbarOptions = new GUIContent[9];
      
      RpgToolbarOptions[0] = new GUIContent("<size=11><b> Game config</b></size>",GetEditorTexture("cog"),"");
      RpgToolbarOptions[1] = new GUIContent("<size=11><b> Stats</b></size>", GetEditorTexture("heart"), "");
      RpgToolbarOptions[2] = new GUIContent("<size=11><b> Characters</b></size>", GetEditorTexture("group"), "");
      RpgToolbarOptions[3] = new GUIContent("<size=11><b> Factions</b></size>", GetEditorTexture("flag_flyaway_green"), "");
      RpgToolbarOptions[4] = new GUIContent("<size=11><b> Progression</b></size>", GetEditorTexture("plus_button"), "");
      RpgToolbarOptions[5] = new GUIContent("<size=11><b> Skills</b></size>", GetEditorTexture("tree_list"), "");
      RpgToolbarOptions[6] = new GUIContent("<size=11><b> Items</b></size>", GetEditorTexture("package"), "");
      RpgToolbarOptions[7] = new GUIContent("<size=11><b> World</b></size>", GetEditorTexture("map"), "");
      RpgToolbarOptions[8] = new GUIContent("<size=11><b> Interactions</b></size>", GetEditorTexture("hand_property"), "");
      
      FootStepsToolbarOptions = new GUIContent[3];
      FootStepsToolbarOptions[0] = new GUIContent("<size=11><b> Settings</b></size>", GetEditorTexture("zone"), "");
      FootStepsToolbarOptions[1] = new GUIContent("<size=11><b>  Surfaces</b></size>",GetEditorTexture("legend"),"");
      FootStepsToolbarOptions[2] = new GUIContent("<size=11><b> Templates</b></size>", GetEditorTexture("zone"), "");
      
      FieldsPrefabsToolbarOptions = new GUIContent[3];
      FieldsPrefabsToolbarOptions[0] = new GUIContent("<size=11><b> Fields</b></size>", GetEditorTexture("toolbar_add"), "");
      FieldsPrefabsToolbarOptions[1] = new GUIContent("<size=11><b>  Ui Popups prefabs</b></size>",GetEditorTexture("legend"),"");
      FieldsPrefabsToolbarOptions[2] = new GUIContent("<size=11><b> Pooled prefabs</b></size>", GetEditorTexture("arrow_repeat"), "");

    }
    public static GUIContent[] RpgToolbarOptions;  
  }
}


