using System;
using System.Collections;
using UnityEngine;

namespace Assets._Game.Gameplay.Script.NPC_sentinel
{
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
    public class StopSentinelState : SentinelState
    {
        public override void EnterState(SentinelController sentinelController)
        {
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

}
