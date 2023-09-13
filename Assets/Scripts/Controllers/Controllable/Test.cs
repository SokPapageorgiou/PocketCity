using UnityEngine;

namespace Controllers.Controllable
{
    public class Test : 
        MonoBehaviour, IControllableAxis, IControllableFire1, IControllableFire2
    {
        void IControllableAxis.Control(float inputX, float inputY)
        {
            Debug.Log($"Axis: {inputX}, {inputY}" );
        }

        void IControllableFire1.Trigger()
        {
            Debug.Log("Fire01");
        }

        void IControllableFire2.Trigger()
        {
            Debug.Log("Fire02");
        }
    }
}