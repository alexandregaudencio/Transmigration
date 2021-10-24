using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfigs : MonoBehaviour
{
    public static GameConfigs instance;
    public  byte maxRoomPlayers;
    public  int menuSceneIndex;
    public  int gameplaySceneIndex;

    //player
    public int HP;
    public int timeToRespawn;

    private void Start()
    {
        instance = this;
    }

}
