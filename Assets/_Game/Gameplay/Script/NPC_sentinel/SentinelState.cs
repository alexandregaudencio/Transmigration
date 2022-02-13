using System;
using System.Collections;
using UnityEngine;


    public abstract class SentinelState
    {
        public abstract void EnterState(SentinelController sentinelController);

        public abstract void UpdateState(SentinelController sentinelController);

        public abstract void ExitState(SentinelController sentinelController);

    }



    public class SleepSentinelState : SentinelState
    {
        private SentinelController sentinelController; 
        public override void EnterState(SentinelController sentinelController)
        {
            this.sentinelController = sentinelController;
            
            sentinelController.SpriteRenderer.sprite = sentinelController.SpriteSleep;
            sentinelController.SentinelVision.UpdateTargetEvent += OnUpdateTargetEvent;
        }

        public override void ExitState(SentinelController sentinelController)
        {
            sentinelController.SentinelVision.UpdateTargetEvent -= OnUpdateTargetEvent;

        }

        public override void UpdateState(SentinelController sentinelController)
        {
        }

        //NÃO SERVE POIS PRECISA CONFERIR SE A LISTA DO VISION É MAIOR DO QUE 0
        public void OnUpdateTargetEvent()
        {
        Debug.Log("TARGET atualizou e o SLEEP viu.");
        if (sentinelController.SentinelVision.TargetOnVision)
        {
            sentinelController.SentinelStateController.TransitionToState(sentinelController.SentinelStateController.listedStates.attackSentinelState);
        }

    }

    }


    public class AttackSentinelState : SentinelState
    {
    private SentinelController sentinelController;

    public override void EnterState(SentinelController sentinelController)
        {
            this.sentinelController = sentinelController;
            sentinelController.SpriteRenderer.sprite = sentinelController.SpriteAttack;
            sentinelController.StartCoroutine(WaitToShoot(sentinelController));
        }
        public override void ExitState(SentinelController sentinelController)
        {
        sentinelController.SentinelVision.UpdateTargetEvent -= OnUpdateTargetEvent;
        sentinelController.StopCoroutine(WaitToShoot(sentinelController));
        }

        public override void UpdateState(SentinelController sentinelController)
        {
        sentinelController.WeaponBase.rotation = sentinelController.SentinelVision.targetRotation;

    }

    public void OnUpdateTargetEvent()
    {
        Debug.Log("TARGET atualizou e o SLEEP viu.");

        if (!sentinelController.SentinelVision.TargetOnVision)
        {
            sentinelController.SentinelStateController.TransitionToState(sentinelController.SentinelStateController.listedStates.attackSentinelState);
        }

    }

    private IEnumerator WaitToShoot(SentinelController sentinelController)
        {
            while (sentinelController.SentinelVision.TargetOnVision)
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

    public class DeathStateSentinel : SentinelState
    {

        public override void EnterState(SentinelController sentinelController)
        {
            //sentinelController.SpriteRenderer.sprite = null;
            //SwitchPropsOnDeath(sentinelController, false);
            sentinelController.StartCoroutine(WaitingResetSentinel(sentinelController));
            //SwitchPropsOnDeath(sentinelController, true);

        }

        public override void ExitState(SentinelController sentinelController)
        {
            
        }


        public override void UpdateState(SentinelController sentinelController)
        {

        }

        private IEnumerator WaitingResetSentinel(SentinelController sentinel)
        {
            
            yield return new WaitForSeconds(sentinel.SecondsToResestSentinel);
            
            if(sentinel.SentinelVision.TargetOnVision)
            {
                sentinel.SentinelStateController.TransitionToState(sentinel.SentinelStateController.listedStates.attackSentinelState);

            } else
            {
                sentinel.SentinelStateController.TransitionToState(sentinel.SentinelStateController.listedStates.sleepSentinelState);

            }

        }

        //private void SwitchPropsOnDeath(SentinelController sentinel, bool value)
        //{
        //    sentinel.SentinelPrefab.SetActive(value);
        //}

    }

    public class ListedSentinelStates
    {
        public readonly DeathStateSentinel deathStateSentinel;
        public readonly AttackSentinelState attackSentinelState;

        public readonly SleepSentinelState sleepSentinelState;

        public ListedSentinelStates()
        {
            deathStateSentinel = new DeathStateSentinel();
            attackSentinelState = new AttackSentinelState();
            sleepSentinelState = new SleepSentinelState();
        }

    }


