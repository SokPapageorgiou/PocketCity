using UnityEngine;

namespace Commons
{
    public abstract class MBSingleton<T> : MonoBehaviour where T :Component
    {
        public static T Instance { get; private set; }
        
        private void Awake()
        {
            SetSingleton();
            LoadStates();
        }

        protected abstract void LoadStates();
        
        private void SetSingleton()
        {
            if (Instance == null)
            {
                Instance = this as T;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(this);
            }
        }
    }
}