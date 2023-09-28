namespace Controllers
{
    public interface IControllableAxis
    {
        void Control(bool autopilot, float horizontal, float vertical);
    }
}