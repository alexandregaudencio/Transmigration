using PowerUps;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InteractableObjects
{

    public class ItemBarrier : Item
    {

        private void OnEnable()
        {
            collect += BarrierApply;
        }

        private void OnDisable()
        {
            collect -= BarrierApply;

        }

        private void BarrierApply(GameObject targetObject)
        {
            targetObject.GetComponent<PowerUpManager>()?.ActiveBarrier();
            Destroy(gameObject);
        }


    }

}
