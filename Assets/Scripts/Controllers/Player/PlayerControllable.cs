using UnityEngine;

namespace Controllers.Player
{
    public class PlayerControllable
    {
        public IControllableHorizontally Horizontal { get; private set; }
        public IControllableVertically Vertical { get; private set; }
        public IControllableFire1 Fire1 { get; private set; }
        public IControllableFire2 Fire2 { get; private set; }

        public void Set(GameObject target)
        {
            Horizontal = target.GetComponent<IControllableHorizontally>();
            Vertical = target.GetComponent<IControllableVertically>();
            Fire1 = target.GetComponent<IControllableFire1>();
            Fire2 = target.GetComponent<IControllableFire2>();
        }
    }
}