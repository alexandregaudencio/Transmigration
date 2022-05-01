using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PowerUps
{
    public class PowerUpManager : MonoBehaviour
    {
        [SerializeField] private GameObject barrier;

        public void ActiveBarrier()
        {
            barrier.SetActive(true);
        }

    }

}
