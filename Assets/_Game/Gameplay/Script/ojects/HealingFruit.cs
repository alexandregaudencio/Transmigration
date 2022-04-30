using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InteractableObjects
{
    [RequireComponent(typeof(Collider2D))]
    public class HealingFruit : MonoBehaviour
    {

        [SerializeField] [Min(0)] private int healingAmount;
        public event Action<GameObject> healing;
        private ItemSpawnManager itemSpawnManager;

        private void Start()
        {
            itemSpawnManager = GetComponentInParent<ItemSpawnManager>();
        }
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
                itemSpawnManager.ItemCollect();
            }

        }

        private void OnHealing(GameObject targetObject)
        {
            targetObject.GetComponent<HPManager>()?.IncreaseHP(healingAmount);
            Destroy(gameObject);
        }






    }




}

