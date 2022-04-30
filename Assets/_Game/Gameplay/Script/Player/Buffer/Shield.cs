using System.Collections;
using UnityEngine;

namespace PowerUps
{
    public class Shield : MonoBehaviour
    {
        [SerializeField] private float timeToDisableInSeconds;

        private void OnEnable()
        {
            StartCoroutine(InitializeShield());
        }

        private void OnDestroy()
        {
            StopCoroutine(InitializeShield());

        }

        private IEnumerator InitializeShield()
        {
            yield return new WaitForSeconds(timeToDisableInSeconds);
            this.gameObject.SetActive(false);
        }

    }
}

