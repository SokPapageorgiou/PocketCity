using UnityEngine;

namespace Controllers.Player
{
    public class PlayerControllable
    {
        public IControllableAxis Axis { get; private set; }
        public IControllableFire1 Fire1 { get; private set; }
        public IControllableFire2 Fire2 { get; private set; }

        public void Set(GameObject target)
        {
            Axis = target.GetComponent<IControllableAxis>();
            Fire1 = target.GetComponent<IControllableFire1>();
            Fire2 = target.GetComponent<IControllableFire2>();
        }
    }
}