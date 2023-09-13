using UnityEngine;

namespace Controllers.Controllable
{
    public class Test : 
        MonoBehaviour, IControllableHorizontally, IControllableVertically, IControllableFire1, IControllableFire2
    {
        void IControllableHorizontally.Control(float input)
        {
            Debug.Log($"Horizontal: {input}" );
        }

        void IControllableVertically.Control(float input)
        {
            Debug.Log($"Vertical: {input}");
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