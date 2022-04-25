using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfigs : MonoBehaviour
{
    [SerializeField] private byte maxTeamPlayers;


    
    [SerializeField] private int menuSceneIndex;
    [SerializeField] private int gameplaySceneIndex;

    //player
    //[SerializeField] private int hP;
    [SerializeField] private int timeToRespawn;

    //gameplay
    [SerializeField] private float timeGameplay;
    [SerializeField] private float timestartup;



    [SerializeField] private Color TeamAColor;
    [SerializeField] private Color TeamBColor;

    //public float resetSentineltime;
    //public float resetTombstonetime;

    [SerializeField] private float characterSpeedScale = 1;
    [SerializeField] private float bulletSpeedScale = 1;
    [SerializeField] private int bulletDamageScale = 1;
    [SerializeField] private int hPScale = 1;




    //public int HP { get => hP; }

    public KeyCode MeditateKey;



    public int MaxBattlePlayers
    {
        get => maxRoomPlayers;
    }
    public float BulletSpeedScale { get => bulletSpeedScale;}
    public int BulletDamageScale { get => bulletDamageScale; }
    public Color TeamAColor1 { get => TeamAColor; }
    public Color TeamBColor1 { get => TeamBColor;}
    public int MenuSceneIndex { get => menuSceneIndex;}
    public int GameplaySceneIndex { get => gameplaySceneIndex;}
    public int TimeToRespawn { get => timeToRespawn; }
    public float TimeGameplay { get => timeGameplay;  }
    public float Timestartup { get => timestartup; }
    public int MaxTeamPlayers { get => maxTeamPlayers; }
    public int maxRoomPlayers { get => maxTeamPlayers * 2; }
    public float CharacterSpeedScale { get => characterSpeedScale;}
    public int HPScale { get => hPScale; }

    public static GameConfigs instance;

    private void Start()
    {
        instance = this;
        //DontDestroyOnLoad(this.gameObject);

    }
}
