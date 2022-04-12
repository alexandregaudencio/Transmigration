using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InteractableObjects
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class HealingFruit : MonoBehaviour
    {

        [SerializeField] [Min(0)] private int healingAmount;
        public event Action<GameObject> healing;

        private void OnEnable()
        {
            healing += OnHealing;
        }

        private void OnDisable()
        {
            healing -= OnHealing;

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("character"))
            {
                healing?.Invoke(collision.gameObject);
            }

        }

        private void OnHealing(GameObject targetObject)
        {
            targetObject.GetComponent<HPManager>()?.IncreaseHP(healingAmount);
            Destroy(gameObject);
        }






    }




}

