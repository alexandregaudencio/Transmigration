
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable] 
public enum MenuStates
{
   PRE_MENU = 0,
   IN_MENU = 1
}

public class CanvasManager : MonoBehaviour
{
    [SerializeField]
    private List<MenuSate> menuState;


    private void Start()
    {
        SwitchCanvasActivity(MenuStates.PRE_MENU);
    }

    public void OnClick_SwitchState(int indexState)
    {
        SwitchCanvasActivity((MenuStates)indexState);
    }

    private void SwitchCanvasActivity(MenuStates actualState)
    {
        //Debug.Log(actualState);
        foreach(MenuSate menu in menuState)
        {
            menu.Canvastarget.SetActive(menu.State == actualState);   
        }
    }

}

[Serializable]
public class MenuSate
{
    [SerializeField]
    private MenuStates state;
    [SerializeField]
    private GameObject canvastarget;

    public MenuSate(MenuStates state, GameObject canvastarget)
    {
        this.State = state;
        this.Canvastarget = canvastarget;
    }

    public MenuStates State { get => state; set => state = value; }
    public GameObject Canvastarget { get => canvastarget; set => canvastarget = value; }
}
