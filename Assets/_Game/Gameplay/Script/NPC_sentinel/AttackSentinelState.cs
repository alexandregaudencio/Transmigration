using Assets._Game.Gameplay.Script.NPC_sentinel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSentinelState : SentinelState
{

        public float bulletSpawnInterval;
        public override void EnterState(SentinelController sentinelController)
        {
            sentinelController.SpriteRenderer.sprite = sentinelController.SpriteAttack;

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
            while (sentinelController.TargetVision)
            {
                Shoot(sentinelController);
                yield return new WaitForSeconds(bulletSpawnInterval);
            }

        }

        private void Shoot(SentinelController sentinelController)
        {
            Debug.Log("ATIRAR");
            //GameObject bullet =  (sentinelController.SentinelBullet,sentinelController.SpawnTransform.position, sentinelController.SpawnTransform.rotation);
            //bullet.layer = sentinelController.gameObject.layer;




            //PV.RPC("DefaultShoot", RpcTarget.All);
            //INSTANCIAR EFEITOS AQUI
            //AudioSource.clip = shootClip;
            //AudioSource.Play();

            //}

        }
    


}
