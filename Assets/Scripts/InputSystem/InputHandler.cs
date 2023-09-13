using Commons;
using UnityEngine;

namespace InputSystem
{
    public class InputHandler : MonoBehaviour
    {
        private InputState _inputState;
        
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        private void Start()
        {
            _inputState = States.Instance.Input;
        }

        private void Update()
        {
            _inputState.SetAxis(Axis.Horizontal,Input.GetAxis("Horizontal"));
            _inputState.SetAxis(Axis.Vertical, Input.GetAxis("Vertical"));
            _inputState.SetFire(Buttons.Fire1,Input.GetButton("Fire1"));
            _inputState.SetFire(Buttons.Fire2,Input.GetButton("Fire2"));
        }
    }
}
