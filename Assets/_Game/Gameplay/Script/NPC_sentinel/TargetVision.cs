using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetVision : MonoBehaviour
{

    public  List<Transform> targetCharacters;
    public bool TargetOnVision
    {
        get
        {
            return (targetCharacters?.Count > 0) ? true : false;
        }
    }

    public Vector3 targetDirection
    {
        get
        {
            Vector2 vectorResult = Vector2.zero;
            float distanceResult = 0f;
            foreach (Transform t in targetCharacters)
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

        targetCharacters.Add(collision.gameObject.transform);

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        targetCharacters.Remove(collision.gameObject.transform);
    }



}
