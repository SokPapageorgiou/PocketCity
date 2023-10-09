using System.Collections.Generic;
using Commons;
using ObjPool;
using UnityEngine;

namespace Controllers.AI.InterestLocations
{
    public class Location : MonoBehaviour
    {
        private Locations _locations;
     
        [SerializeField]
        private List<AITypes> types;
        
        private void Awake()
        {
            _locations = SceneState.Instance.Locations;

            types.ForEach(type => _locations.SetPoint(type, transform.position));
        }
    }
}