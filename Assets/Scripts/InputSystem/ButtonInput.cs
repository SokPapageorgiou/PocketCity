namespace InputSystem
{
    public readonly struct ButtonInput
    {
        public readonly bool IsPressed;

        public ButtonInput(bool isPressed)
        {
            IsPressed = isPressed;
        }
    }
}