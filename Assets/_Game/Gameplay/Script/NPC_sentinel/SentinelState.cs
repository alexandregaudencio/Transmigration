using System;
using System.Collections;
using UnityEngine;


public abstract class SentinelState
    {
        public abstract void EnterState(SentinelController sentinelController);

        //public abstract void UpdateState(SentinelController sentinelController);

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

    //public override void UpdateState(SentinelController sentinelController)
    //{
    //}

    public void OnUpdateTargetEvent()
    {
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
        sentinelController.SentinelVision.UpdateTargetEvent += OnUpdateTargetEvent;
        sentinelController.StartCoroutine(SetWeaponRotation(sentinelController));
        sentinelController.StartCoroutine(WaitToShoot(sentinelController));

    }
    public override void ExitState(SentinelController sentinelController)
    {
        sentinelController.StopCoroutine(SetWeaponRotation(sentinelController));
        sentinelController.StopCoroutine(WaitToShoot(sentinelController));
        sentinelController.SentinelVision.UpdateTargetEvent -= OnUpdateTargetEvent;
    }

    //public override void UpdateState(SentinelController sentinelController)
    //{

    //}



    public void OnUpdateTargetEvent()
    {
        if (!sentinelController.SentinelVision.TargetOnVision)
        {
            sentinelController.SentinelStateController.TransitionToState(
                sentinelController.SentinelStateController.listedStates.sleepSentinelState);
        }

    }
    private IEnumerator SetWeaponRotation(SentinelController sentinel)
    {
        while(sentinel.SentinelVision.TargetOnVision)

        {
            sentinel.WeaponBase.rotation = sentinel.SentinelVision.targetRotation;
            yield return new WaitForSeconds(0.1f);

        }
    }

    private IEnumerator WaitToShoot(SentinelController sentinel)
    {
        while (sentinel.SentinelVision.TargetOnVision)
        {
            sentinel.Shoot();

            //Shoot(sentinelController);
            yield return new WaitForSeconds(sentinel.BulletSpawnInterval);

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
        
        OnEnterDeath(sentinelController);


    }

    public override void ExitState(SentinelController sentinelController)
    {
        SwitchPropsOnDeath(sentinelController, true);
        sentinelController.Damageable.ResetHP();
    }



    private void OnEnterDeath(SentinelController sentinelController)
    {
        sentinelController.StopAllCoroutines();
        //sentinelController.SentinelVision.characterOnVision.Clear();
        sentinelController.SpriteRenderer.sprite = null;
        sentinelController.AudioSource.clip = sentinelController.DeathClip;
        sentinelController.AudioSource.Play();
        SwitchPropsOnDeath(sentinelController, false);
        sentinelController.StartCoroutine(WaitingResetSentinel(sentinelController));
    }
    private IEnumerator WaitingResetSentinel(SentinelController sentinel)
    {

        yield return new WaitForSeconds(sentinel.SecondsToResestSentinel);

        if (sentinel.SentinelVision.TargetOnVision)
            sentinel.SentinelStateController.TransitionToState(sentinel.SentinelStateController.listedStates.attackSentinelState);
        else
            sentinel.SentinelStateController.TransitionToState(sentinel.SentinelStateController.listedStates.sleepSentinelState);

    }

    private void SwitchPropsOnDeath(SentinelController sentinel, bool value)
    {

        sentinel.Collider2D.enabled = value;
        sentinel.Damageable.enabled = value;
        sentinel.CanvasObj.SetActive(value);
        
        //sentinel.SentinelPrefab.SetActive(value);

    }

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


