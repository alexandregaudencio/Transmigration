using Photon.Pun.UtilityScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum TeamName
{
    Blue,
    Red
}

public class DropManager : MonoBehaviour, IDropHandler
{

    [SerializeField] private TeamName team;

    public void OnDrop(PointerEventData eventData)
    {

        GameObject objectEventData = eventData.pointerDrag.GetComponent<RectTransform>().gameObject;
        objectEventData.transform.SetParent(transform);
        objectEventData?.GetComponent<PlayerTeam>().SwitchTeam(team.ToString());


    }


}
