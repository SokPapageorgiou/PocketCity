using System;
using System.Collections.Generic;
using System.Linq;
using Controllers.Controllable;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ObjPool
{
   public class Pool 
   {
      private readonly Queue<Humanoid> _poolHumanoids;

      public Pool()
      {
         _poolHumanoids = new Queue<Humanoid>();
      }

      public void Load(PoolLibrary library)
      {
         library.Humanoids.ToList().ForEach( humanoid =>
         {
            Enumerable.Range(0, library.SizeHumanoids).ToList().ForEach(_ =>
            {
               var instance = Object.Instantiate(humanoid);
               Deposit(AITypes.Humanoid, instance);
            });
         });
      }

      public void Deposit<T>(AITypes aiType, T component) where T : Component
      {
         component.gameObject.SetActive(false);
         
         switch (aiType)
         {
            case AITypes.Humanoid:
               _poolHumanoids.Enqueue(component as Humanoid);
               break;
            
            default:
               throw new ArgumentOutOfRangeException(nameof(aiType), aiType, null);
         }
      }
      
      public T Draw<T>(AITypes aiType) where T : Component
      {
         var component = aiType switch
         {
            AITypes.Humanoid => _poolHumanoids.Dequeue() as T,
            _ => throw new ArgumentOutOfRangeException(nameof(aiType), aiType, null)
         };

         component.gameObject.SetActive(true);

         return component;
      } 
   }
}
