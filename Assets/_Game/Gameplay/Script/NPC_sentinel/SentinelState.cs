using System;
using System.Collections;
using UnityEngine;


    public abstract class SentinelState
    {
        public abstract void EnterState(SentinelController sentinelController);

        public abstract void UpdateState(SentinelController sentinelController);

        public abstract void OnTriggerEnter2D(SentinelController sentinelController, Collider2D collision);
        public abstract void OnTriggerExit2D(SentinelController sentinelController, Collider2D collision);

    }



    public class SleepSentinelState : SentinelState
    {
        public override void EnterState(SentinelController sentinelController)
        {
            sentinelController.testText.text = "state: SLEEP";
            sentinelController.SpriteRenderer.sprite = sentinelController.SpriteSleep;

        }

        public override void OnTriggerEnter2D(SentinelController sentinelController, Collider2D collision)
        {
        }

        public override void OnTriggerExit2D(SentinelController sentinelController, Collider2D collision)
        {
        }

        public override void UpdateState(SentinelController sentinelController)
        {
        }
    }


    public class AttackSentinelState : SentinelState
    {
        public override void EnterState(SentinelController sentinelController)
        {
            sentinelController.testText.text = "state: ATTACK";
            sentinelController.SpriteRenderer.sprite = sentinelController.SpriteAttack;
        sentinelController.StartCoroutine(WaitToShoot(sentinelController));
        }

        public override void OnTriggerEnter2D(SentinelController sentinelController, Collider2D collision)
        {

        }

        public override void OnTriggerExit2D(SentinelController sentinelController, Collider2D collision)
        {
        }

        public override void UpdateState(SentinelController sentinelController)
        {
            sentinelController.WeaponBase.rotation = sentinelController.TargetVision.targetRotation;

        }

        private IEnumerator WaitToShoot(SentinelController sentinelController)
        {
            while (sentinelController.TargetVision.TargetOnVision)
            {
                sentinelController.Shoot();
                //Shoot(sentinelController);
                yield return new WaitForSeconds(sentinelController.BulletSpawnInterval);
            }

        }


        //TODO: implemntar corretamente aqui.
        private void Shoot(SentinelController sentinelController)
        {

        Debug.Log("ATIRAR");
        //GameObject bullet =  sentinelController.Instantiate(sentinelController.SentinelBullet,
        //    sentinelController.SpawnTransform.position,
        //    sentinelController.SpawnTransform.rotation);

        //bullet.layer = sentinelController.gameObject.layer;




            //PV.RPC("DefaultShoot", RpcTarget.All);
            //INSTANCIAR EFEITOS AQUI
            //AudioSource.clip = shootClip;
            //AudioSource.Play();

            //}
        }
    }

    public class StopSentinelState : SentinelState
    {

        public override void EnterState(SentinelController sentinelController)
        {
            sentinelController.testText.text = "state: STOP";

        }

        public override void OnTriggerEnter2D(SentinelController sentinelController, Collider2D collision)
        {
        }

        public override void OnTriggerExit2D(SentinelController sentinelController, Collider2D collision)
        {
        }

        public override void UpdateState(SentinelController sentinelController)
        {
        }
    }

    public class ListedSentinelStates
    {
        public readonly StopSentinelState stopSentinelState;
        public readonly AttackSentinelState attackSentinelState;

        public readonly SleepSentinelState sleepSentinelState;

        public ListedSentinelStates()
        {
            stopSentinelState = new StopSentinelState();
            attackSentinelState = new AttackSentinelState();
            sleepSentinelState = new SleepSentinelState();
        }

    }


