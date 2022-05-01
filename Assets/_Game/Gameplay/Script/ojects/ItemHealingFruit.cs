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
            collect += HealingApply;
        }

        private void OnDisable()
        {
            collect -= HealingApply;

        }

        private void HealingApply(GameObject targetObject)
        {
            targetObject.GetComponent<HPManager>()?.IncreaseHP(healingAmount);
            targetObject.GetComponentInChildren<HealingEffect>()?.InitializeAnimator();
            Destroy(gameObject);

        }






    }




}

