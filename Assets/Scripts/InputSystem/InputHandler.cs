using System;
using UnityEngine;

namespace InputSystem
{
    public class InputHandler : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        private void Update()
        {
            InputState.Horizontal = Input.GetAxis("Horizontal");
            InputState.Vertical = Input.GetAxis("Vertical");
            InputState.Fire1 = Input.GetButton("Fire1");
            InputState.Fire2 = Input.GetButton("Fire2");
        }
    }
}
