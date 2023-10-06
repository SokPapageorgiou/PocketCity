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
               Deposit(PoolTypes.Humanoid, instance);
            });
         });
      }

      public void Deposit<T>(PoolTypes poolType, T component) where T : Component
      {
         component.gameObject.SetActive(false);
         
         switch (poolType)
         {
            case PoolTypes.Humanoid:
               _poolHumanoids.Enqueue(component as Humanoid);
               break;
            
            default:
               throw new ArgumentOutOfRangeException(nameof(poolType), poolType, null);
         }
      }
      
      public T Draw<T>(PoolTypes poolType) where T : Component
      {
         var component = poolType switch
         {
            PoolTypes.Humanoid => _poolHumanoids.Dequeue() as T,
            _ => throw new ArgumentOutOfRangeException(nameof(poolType), poolType, null)
         };

         component.gameObject.SetActive(true);

         return component;
      } 
   }
}
