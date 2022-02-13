using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHandle : MonoBehaviour
{
    [SerializeField] List<GameObject> MissionObjects;
    [SerializeField] private float waitingTime;
    private void OnEnable()
    {
        StartCoroutine(F());
    }

    public void SetActiveMissionObjects()
    {
        foreach(GameObject objects in MissionObjects)
        {
            objects?.SetActive(true);
        }
    }

    IEnumerator F ()
    {
        yield return new WaitForSeconds(waitingTime);
        SetActiveMissionObjects();
        
    }

}
