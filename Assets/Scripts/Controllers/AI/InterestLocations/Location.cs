using System.Collections.Generic;
using Commons;
using UnityEngine;

namespace Controllers.AI.InterestLocations
{
    public class Location : MonoBehaviour
    {
        private Locations _locations;
     
        [SerializeField]
        private List<AITypes> types;
        
        private void Start()
        {
            _locations = SceneState.Instance.Locations;

            types.ForEach(type => _locations.SetPoint(type, transform.position));
        }
    }
}