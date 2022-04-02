using Managers;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetupGameplay : MonoBehaviour
{
    [SerializeField]  private Timer timer;
    [SerializeField] private List<GameObject> GameObjectsToDisable;
    [SerializeField] private List<GameObject> GameObjectsToEnable;


    private void OnEnable()
    {
        timer.timeOver += InitializeGameplay;
    }

    private void OnDisable()
    {
        timer.timeOver -= InitializeGameplay;
    }

    private void InitializeGameplay()
    {
        foreach (GameObject objects in GameObjectsToDisable)
        {
            objects.SetActive(false);
        }
        foreach (GameObject objects in GameObjectsToEnable)
        {
            objects.SetActive(true);
        }
        this.enabled = false;
    }
}
