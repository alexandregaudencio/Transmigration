using PowerUps;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InteractableObjects
{

    public class ItemShield : Item
    {

        private void OnEnable()
        {
            collect += Shield;
        }

        private void OnDisable()
        {
            collect -= Shield;

        }

        private void Shield(GameObject targetObject)
        {
            targetObject.GetComponent<PowerUpManager>()?.ActiveShield();
            Destroy(gameObject);
        }


    }

}
