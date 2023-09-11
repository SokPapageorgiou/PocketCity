using Controllers.Player;
using InputSystem;
using UnityEngine;

namespace Commons
{
    public class States : MonoBehaviour
    { 
        public static States Instance { get; private set; }
        
        public InputState Input { get; private set; }
        public PlayerControllable PlayerControllable { get; private set; }

        private void Awake()
        {
            SetSingleton();
            LoadStates();
        }

        private void LoadStates()
        {
            Input = new InputState();
            PlayerControllable = new PlayerControllable();
        }

        private void SetSingleton()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(this);
            }
        }
    }
}