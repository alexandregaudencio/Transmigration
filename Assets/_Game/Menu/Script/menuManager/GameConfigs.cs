using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfigs : MonoBehaviour
{
    public static GameConfigs instance;
    public byte maxRoomPlayers;
    public int menuSceneIndex;
    public int gameplaySceneIndex;

    //player
    public int HP;
    public int timeToRespawn;

    //gameplay
    public float timeGameplay;
    public float timestartup;



    public Color TeamAColor;
    public Color TeamBColor;

    //public float resetSentineltime;
    //public float resetTombstonetime;


    public KeyCode MeditateKey;
    private void Start()
    {
        instance = this;
    }



}
