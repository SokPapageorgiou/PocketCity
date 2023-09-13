namespace Controllers
{
    public interface IControllableAxis
    {
        void Control(float inputX, float inputY);
    }
}