using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterButtonInteractableVizualize : MonoBehaviourPunCallbacks
{
    DragManager dragManager;
    private Image image;
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        dragManager = GetComponent<DragManager>();
        image = GetComponent<Image>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    private new void OnEnable()
    {
        base.OnEnable();
        if (PhotonNetwork.IsMasterClient) MasterPrefabConfig();
        else ClientsPrefabConfig();
    }

    private void ClientsPrefabConfig()
    {
        canvasGroup.alpha = 0.5f;
        dragManager.enabled = false;
        image.color = new Color(113,1134,113);
    }
    private void MasterPrefabConfig()
    {
        canvasGroup.alpha = 1;
        dragManager.enabled = true;
        image.color = Color.magenta;
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        if (newMasterClient == PhotonNetwork.LocalPlayer)
        {
            MasterPrefabConfig();
        }

    }



}
