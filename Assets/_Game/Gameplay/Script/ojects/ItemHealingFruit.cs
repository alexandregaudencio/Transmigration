using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InteractableObjects
{
    public class ItemHealingFruit : Item
    {

        [SerializeField] [Min(0)] private int healingAmount;

        private void OnEnable()
        {
            collect += Healing;
        }

        private void OnDisable()
        {
            collect -= Healing;

        }

        private void Healing(GameObject targetObject)
        {
            targetObject.GetComponent<HPManager>()?.IncreaseHP(healingAmount);
            Destroy(gameObject);

        }






    }




}

