using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PowerUps
{
    public class PowerUpManager : MonoBehaviour
    {
        [SerializeField] private GameObject shield;

        public void ActiveShield()
        {
            shield.SetActive(true);
        }

    }

}
