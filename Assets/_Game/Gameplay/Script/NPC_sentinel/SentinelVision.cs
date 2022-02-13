using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentinelVision : MonoBehaviour
{

    [SerializeField] List<string> targetTagsToIgnore;
    public  List<Transform> characterOnVision;

    public event Action UpdateTargetEvent;

    //private void Start()
    //{
    //    UpdateTargetEvent += OnUpdateTargetList;
    //}

    //private void OnDestroy()
    //{
    //    UpdateTargetEvent -= OnUpdateTargetList;
    //}

    public bool TargetOnVision
    {
        get
        {
            return (characterOnVision?.Count > 0) ? true : false;
        }
    }

    public Vector3 targetDirection
    {
        get
        {
            Vector2 vectorResult = Vector2.zero;
            float distanceResult = 0f;
            foreach (Transform t in characterOnVision)
            {
                if (Vector3.Distance(t.position, transform.position) > distanceResult)
                {
                    vectorResult = t.position;
                }
            }
            return vectorResult;
        }
    }

    public Quaternion targetRotation
    {
        get
        {
            Vector2 direction = targetDirection - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            return Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!targetTagsToIgnore.Contains(collision.tag))
        {
            characterOnVision.Add(collision.gameObject.transform);
            UpdateTargetEvent?.Invoke();
            //ChangeState();


        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(!targetTagsToIgnore.Contains(collision.tag))
        {
            characterOnVision.Remove(collision.gameObject.transform);
            UpdateTargetEvent?.Invoke();
            //ChangeState();

        }
    }


    ////TODO: cirar um evento para atualizar a lista de targets
    //public void OnUpdateTargetList()
    //{

    //}


    //TODO: passar isso para dentro da maquina de estados.
    public void ChangeState()
    {
        SentinelStateController stateC = GetComponentInChildren<SentinelStateController>();

        if (characterOnVision.Count > 0)
        {
            stateC.TransitionToState(stateC.listedStates.attackSentinelState);

        }
        else
        {
            stateC.TransitionToState(stateC.listedStates.sleepSentinelState);

        }
    }

}
