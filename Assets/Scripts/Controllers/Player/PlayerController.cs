using Commons;
using InputSystem;
using UnityEngine;

namespace Controllers.Player
{
    public class PlayerController : MonoBehaviour
    {
        private IControllable _controllable;
        private InputState _inputState;
        
        [SerializeField] private GameObject defaultControllable;

        private void Start()
        {
            _inputState = States.Instance.Input;
            _controllable = GetControllable();
        }

        private IControllable GetControllable()
        {
            var playerControllable = States.Instance.PlayerControllable;
            SetStartControllable(playerControllable);
            
            return playerControllable.Controllable;
        }

        private void SetStartControllable(PlayerControllable playerControllable)
        {
            var controllable = defaultControllable.GetComponent<IControllable>();

            if (controllable == null) return ;

            playerControllable.Controllable = controllable;
        }

        private void FixedUpdate()
        {
            if (_controllable == null) return;
            
            if(_inputState.Horizontal.Value != 0)
            {
                _controllable.MoveHorizontal(_inputState.Horizontal.Value);
            }
            
            if(_inputState.Vertical.Value != 0)
            {
                _controllable.MoveVertical(_inputState.Vertical.Value);
            }
            
            if(_inputState.Fire1.IsPressed)
            {
                _controllable.Fire1();
            }
            
            if(_inputState.Fire2.IsPressed)
            {
                _controllable.Fire2();
            }
        }
    }
}