namespace InputSystem
{
    public class InputState
    {
        public AxisInput Horizontal { get; private set; }
        public AxisInput Vertical { get; private set; }
        public ButtonInput Fire1 { get; private set; }
        public ButtonInput Fire2 { get; private set; }
        
        public void SetAxis(Axis axis, float value)
        {
            var currentValue = axis == Axis.Horizontal ? Horizontal.Value : Vertical.Value;
            
            if (value == currentValue) return;
            
            if (axis == Axis.Horizontal)
            {
                Horizontal = new AxisInput(value);
            }
            else
            {
                Vertical = new AxisInput(value);
            }
        }
        
        public void SetFire(Buttons button, bool value)
        {
            var currentValue = button == Buttons.Fire1 ? Fire1.IsPressed : Fire2.IsPressed;
            
            if (value == currentValue) return;
            
            if (button == Buttons.Fire1)
            {
                Fire1 = new ButtonInput(value);
            }
            else
            {
                Fire2 = new ButtonInput(value);
            }
        }
    }
}