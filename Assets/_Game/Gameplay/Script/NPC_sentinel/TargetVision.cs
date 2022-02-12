using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetVision : MonoBehaviour
{

    [SerializeField] List<string> targetTagsToIgnore;
    public  List<Transform> characterOnVision;


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
            ChangeState();


        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(!targetTagsToIgnore.Contains(collision.tag))
        {
            characterOnVision.Remove(collision.gameObject.transform);
            ChangeState();

        }
    }

    
    public void ChangeState()
    {
        SentinelStateController stateC = GetComponentInChildren<SentinelStateController>();

        if (characterOnVision.Count > 0)
        {
            stateC.TransitionToState(stateC.listedStates.attackSentinelState);

        } else
        {
            stateC.TransitionToState(stateC.listedStates.sleepSentinelState);

        }
    }

}
