using UnityEngine;

namespace Controllers.Controllable
{
    public class Test : MonoBehaviour, IControllable
    {
        public void MoveHorizontal(float input) =>  Debug.Log($"Horizontal: {input}" );
        
        public void MoveVertical(float input) =>  Debug.Log($"Vertical: {input}");
        
        public void Fire1() =>  Debug.Log("Fire01");
   
        public void Fire2() =>  Debug.Log("Fire02");
    }
}