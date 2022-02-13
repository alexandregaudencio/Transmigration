using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SentinelController : MonoBehaviour
{
    [Header("Generic Properties")]
    [SerializeField] private AudioClip onVisionClip;


    [Header("SLEEP State Properties")]
    [SerializeField] private Sprite spriteSleep;


    [Header("ATTACK State Properties")]
    [SerializeField] private GameObject sentinelBullet;
    [SerializeField] [Range(0, 5)] private float bulletSpawnInterval;
    [SerializeField] private Transform spawnTransform;
    [SerializeField] private Transform weaponBase;
    [SerializeField] private Sprite spriteAttack;
    [SerializeField] private AudioClip shootClip;


    [Header("STOP State Properties")]
    [SerializeField] [Min(0)] private int secondsToResestSentinel;
    [SerializeField] private GameObject sentinelPrefab;


    private SentinelVision sentinelVision;
    private SentinelStateController sentinelStateController;
    private AudioSource audioSource;
    private SpriteRenderer spriteRenderer;
    private PhotonView PV;


    public SentinelVision SentinelVision { get => sentinelVision; set => sentinelVision = value; }
    public AudioSource AudioSource { get => audioSource; set => audioSource = value; }
    public SpriteRenderer SpriteRenderer { get => spriteRenderer; set => spriteRenderer = value; }
    public Transform WeaponBase { get => weaponBase; set => weaponBase = value; }
    public Sprite SpriteSleep { get => spriteSleep; set => spriteSleep = value; }
    public Sprite SpriteAttack { get => spriteAttack; set => spriteAttack = value; }
    public GameObject SentinelBullet { get => sentinelBullet; set => sentinelBullet = value; }
    public Transform SpawnTransform { get => spawnTransform; set => spawnTransform = value; }
    public float BulletSpawnInterval { get => bulletSpawnInterval; set => bulletSpawnInterval = value; }
    public int SecondsToResestSentinel { get => secondsToResestSentinel; set => secondsToResestSentinel = value; }
    public SentinelStateController SentinelStateController { get => sentinelStateController; set => sentinelStateController = value; }
    public GameObject SentinelPrefab { get => sentinelPrefab; }

    //public static SentinelController instance;

    private void Awake()
    {
        //instance = this;
        sentinelStateController = GetComponent<SentinelStateController>();
        SentinelVision = GetComponentInParent<SentinelVision>();
        AudioSource = GetComponentInParent<AudioSource>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        PV = GetComponent<PhotonView>();
        
    }

    public void Shoot()
    {
        //atira
        GameObject bullet = Instantiate(sentinelBullet, spawnTransform.position, spawnTransform.rotation);
        bullet.layer = this.gameObject.layer;


    }


    }
