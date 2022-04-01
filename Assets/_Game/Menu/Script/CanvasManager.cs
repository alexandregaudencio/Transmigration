
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

    bool inMenu = false;


    private void Start()
    {
        SwitchCanvasActivity(MenuStates.PRE_MENU);

    }
    private void Update()
    {
        if(Input.anyKeyDown && !inMenu)
        {
            OnClick_SwitchState(1);
        }
        //if (Input.GetButton("Joy1LHorizontal"))
        //{

        //    Debug.Log("Joysstick press!");
        //}
    }
    

    public void OnClick_SwitchState(int indexState)
    {
        SwitchCanvasActivity((MenuStates)indexState);
        inMenu = (((MenuStates)indexState) == MenuStates.IN_MENU) ? 
            true : false;
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
