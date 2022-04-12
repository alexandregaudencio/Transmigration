using System.Collections;
using UnityEngine;

namespace PowerUps
{
    public class Shield : MonoBehaviour
    {


        private void OnEnable()
        {
            StartCoroutine(InitializeShield());
        }


        private IEnumerator InitializeShield()
        {
            yield return new WaitForSeconds(5);
            this.gameObject.SetActive(false);
        }

    }
}

