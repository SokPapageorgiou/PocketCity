using Controllers.Player;
using InputSystem;

namespace Commons
{
    public class GameState : MBSingleton<GameState>
    {
        public InputState Input { get; private set; }
        public PlayerControllable PlayerControllable { get; private set; }

        protected override void LoadStates()
        {
            Input = new InputState();
            PlayerControllable = new PlayerControllable();
        }
    }
}