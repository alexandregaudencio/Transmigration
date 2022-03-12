using Photon.Pun.UtilityScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class DropManager : MonoBehaviour, IDropHandler
{

    public enum TeamName
    {
        Blue,
        Red
    }

    [SerializeField] private TeamName team;

    public void OnDrop(PointerEventData eventData)
    {

        GameObject objectEventData = eventData.pointerDrag.GetComponent<RectTransform>().gameObject;
        objectEventData.transform.SetParent(transform);
        objectEventData?.GetComponent<SetPlayerTeam>().SwitchTeam(team.ToString());


    }


}
