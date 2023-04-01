using UnityEngine;

namespace Station
{
    public class UiPanel : UiElementAnim
    {

        protected override void Start()
        {
            base.Start();
            UiSystem.RegisterPanel(this);
        }
        
        protected virtual void OnDestroy()
        {
            UiSystem.UnRegisterPanel(this);
        }

      
    }

    public abstract class UiPanel<T> : UiPanel
    {
        public virtual void ShowPanel(T data)
        {
        }
    }
}

