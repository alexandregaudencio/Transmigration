using System.Collections;
using UnityEngine;

namespace PowerUps
{
    public class Barrier : MonoBehaviour
    {
        [SerializeField] private float timeToDisableInSeconds;
        private Animator animator;
        private CircleCollider2D circleCollider2D;
        private void Awake()
        {
            animator = GetComponent<Animator>();
            circleCollider2D = GetComponent<CircleCollider2D>();

        }

        private void OnEnable()
        {
            StartCoroutine(InitializeShield());
            animator.Play("Barrier Cast");
        }

        private void OnDestroy()
        {
            StopCoroutine(InitializeShield());

        }


        private IEnumerator InitializeShield()
        {
           // SwitchComponents(value);
            yield return new WaitForSeconds(timeToDisableInSeconds);
            //SwitchComponents(!value);
            animator.Play("Barrier Dissolve");



        }
        
        public void DisableBarrier()
        {
            gameObject.SetActive(false);
        }

        //private void SwitchComponents(bool value)
        //{
        //    circleCollider2D.enabled = value;
        //}

        
    }
}

