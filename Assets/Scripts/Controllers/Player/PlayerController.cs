using Commons;
using InputSystem;
using UnityEngine;

namespace Controllers.Player
{
    public class PlayerController : MonoBehaviour
    {
        private PlayerControllable _controllable;
        private InputState _inputState;
        
        [SerializeField] private GameObject defaultControllable;

        private void Start()
        {
            _inputState = States.Instance.Input;
            
            _controllable = States.Instance.PlayerControllable;
            _controllable.Set(defaultControllable);
        }

        private void FixedUpdate()
        {
            if (_controllable == null) return;
            
            _controllable.Axis?.Control(_inputState.Horizontal.Value, _inputState.Vertical.Value);
            
            if(_inputState.Fire1.IsPressed)
            {
                _controllable.Fire1?.Trigger();
            }
            
            if(_inputState.Fire2.IsPressed)
            {
                _controllable.Fire2?.Trigger();
            }
        }
    }
}