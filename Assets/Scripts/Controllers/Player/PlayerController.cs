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
            
            if(_controllable.Horizontal != null && _inputState.Horizontal.Value != 0)
            {
                _controllable.Horizontal.Control(_inputState.Horizontal.Value);
            }
            
            if(_controllable.Vertical != null && _inputState.Vertical.Value != 0)
            {
                _controllable.Vertical.Control(_inputState.Vertical.Value);
            }
            
            if(_controllable.Fire1 != null && _inputState.Fire1.IsPressed)
            {
                _controllable.Fire1.Trigger();
            }
            
            if(_controllable.Fire1 != null && _inputState.Fire2.IsPressed)
            {
                _controllable.Fire2.Trigger();
            }
        }
    }
}