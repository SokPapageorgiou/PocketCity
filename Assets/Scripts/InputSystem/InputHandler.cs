using System;
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
            _inputState.Horizontal = Input.GetAxis("Horizontal");
            _inputState.Vertical = Input.GetAxis("Vertical");
            _inputState.Fire1 = Input.GetButton("Fire1");
            _inputState.Fire2 = Input.GetButton("Fire2");
        }
    }
}
