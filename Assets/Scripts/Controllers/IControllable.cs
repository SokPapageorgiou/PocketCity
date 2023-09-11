namespace Controllers
{
    public interface IControllable
    {
        void MoveHorizontal(float input);
        void MoveVertical(float input);
        void Fire1();
        void Fire2();
    }
}