﻿

namespace Station
{
    
    public static partial class GameGlobalEvents 
    {
        /// <summary>
        /// the game is booting and all database are accessible now
        /// </summary>
        public static readonly StationEvent OnDataBaseLoaded = new StationEvent();
        
        /// <summary>
        /// trigger after character creation or when entering first zone
        /// </summary>
        public static readonly StationEvent OnEnterGame = new StationEvent();

        /// <summary>
        /// trigger when changing scene, the previous scene will be removed next
        /// </summary>
        public static readonly StationEvent OnSceneStartLoad = new StationEvent();
        
        /// <summary>
        /// the scene just finished loading, we load all the save for that area
        /// </summary>
        public static readonly StationEvent OnSceneInitialize = new StationEvent();
        
        /// <summary>
        /// trigger when it is time to initialize the npc, items, or other objects in the scene
        /// </summary>
        public static readonly StationEvent OnSceneLoadObjects = new StationEvent();
        
        
        /// <summary>
        /// the scene is ready, can hide loading screen
        /// </summary>
        public static readonly StationEvent OnSceneReady = new StationEvent();
      
        /// <summary>
        /// we are leaving this area, use this to cancel all pending actions, animation...
        /// </summary>
        public static readonly StationEvent OnBeforeLeaveScene = new StationEvent();
        
        #region UI
        public static readonly StationEvent<UiEventData> OnUiEvent = new StationEvent<UiEventData>();
        #endregion
    }
}

