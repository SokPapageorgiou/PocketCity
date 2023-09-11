namespace Controllers.Player
{
    public class PlayerControllable
    {
        public IControllable Controllable { get; private set; }

        public void SetControllable(IControllable controllable)
        {
            Controllable = controllable;
        }
    }
}