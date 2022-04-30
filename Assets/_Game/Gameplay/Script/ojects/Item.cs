using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InteractableObjects
{

    [RequireComponent(typeof(Collider2D))]
    public class Item : MonoBehaviour
    {
        public event Action<GameObject> collect;
        private ItemSpawnManager itemSpawnManager;

        virtual public void Start()
        {
            itemSpawnManager = GetComponentInParent<ItemSpawnManager>();
        }


        virtual public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("character"))
            {
                collect?.Invoke(collision.gameObject);
                itemSpawnManager.ItemCollect();
            }

        }





    }

}

