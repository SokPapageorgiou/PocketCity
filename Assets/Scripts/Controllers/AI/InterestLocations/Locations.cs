using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Controllers.AI.InterestLocations
{
   public class Locations
   {
      private readonly List<Vector3> _humanoidPoints = new();
      
      public void SetPoint(AITypes type, Vector3 point)
      {
         switch (type)
         {
            case AITypes.Humanoid:
               _humanoidPoints.Add(point);
               break;
            default:
               throw new ArgumentOutOfRangeException(nameof(type), type, null);
         }
      }
      
      public Vector3 GetRandomPoint(AITypes type)
      {
         return type switch
         {
            AITypes.Humanoid => _humanoidPoints[Random.Range(0, _humanoidPoints.Count)],
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
         };
      }
   }
}
