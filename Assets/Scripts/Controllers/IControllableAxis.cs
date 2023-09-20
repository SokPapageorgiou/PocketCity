namespace Controllers
{
    public interface IControllableAxis
    {
        void Control(float horizontal, float vertical);
    }
}