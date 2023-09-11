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

            playerControllable.SetControllable(controllable);
        }

        private void FixedUpdate()
        {
            if (_controllable == null) return;
            
            if(_inputState.Horizontal != 0)
            {
                _controllable.MoveHorizontal(_inputState.Horizontal);
            }
            
            if(_inputState.Vertical != 0)
            {
                _controllable.MoveVertical(_inputState.Vertical);
            }
            
            if(_inputState.Fire1)
            {
                _controllable.Fire1();
            }
            
            if(_inputState.Fire2)
            {
                _controllable.Fire2();
            }
        }
    }
}