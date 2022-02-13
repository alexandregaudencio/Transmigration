using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SentinelController : MonoBehaviour
{
    [Header("Generic Properties")]
    [SerializeField] private AudioClip onVisionClip;
    [SerializeField] private GameObject sentinelPrefab;


    [Header("SLEEP State Properties")]
    [SerializeField] private Sprite spriteSleep;


    [Header("ATTACK State Properties")]
    [SerializeField] private GameObject sentinelBullet;
    [SerializeField] [Range(0, 5)] private float bulletSpawnInterval;
    [SerializeField] private Transform spawnTransform;
    [SerializeField] private Transform weaponBase;
    [SerializeField] private Sprite spriteAttack;
    [SerializeField] private AudioClip attackClip;


    [Header("STOP State Properties")]
    [SerializeField] [Min(0)] private int secondsToResestSentinel;
    [SerializeField] private AudioClip deathClip;
    [SerializeField] private GameObject canvasObj;

        


    private SentinelVision sentinelVision;
    private SentinelStateController sentinelStateController;
    private AudioSource audioSource;
    private SpriteRenderer spriteRenderer;
    private PhotonView PV;
    private DamageableSentinel damageable;
    private BoxCollider2D sentinelCollider;


    public SentinelVision SentinelVision { get => sentinelVision; set => sentinelVision = value; }
    public AudioSource AudioSource { get => audioSource; set => audioSource = value; }
    public SpriteRenderer SpriteRenderer { get => spriteRenderer; set => spriteRenderer = value; }
    public Transform WeaponBase { get => weaponBase; }
    public Sprite SpriteSleep { get => spriteSleep; }
    public Sprite SpriteAttack { get => spriteAttack; }
    public GameObject SentinelBullet { get => sentinelBullet; }
    public Transform SpawnTransform { get => spawnTransform; }
    public float BulletSpawnInterval { get => bulletSpawnInterval; set => bulletSpawnInterval = value; }
    public int SecondsToResestSentinel { get => secondsToResestSentinel; set => secondsToResestSentinel = value; }
    public SentinelStateController SentinelStateController { get => sentinelStateController; }
    public GameObject SentinelPrefab { get => sentinelPrefab; }
    public AudioClip DeathClip { get => deathClip; set => deathClip = value; }
    public AudioClip AttackClip { get => attackClip; set => attackClip = value; }
    public DamageableSentinel Damageable { get => damageable; set => damageable = value; }
    public BoxCollider2D Collider2D { get => sentinelCollider; set => sentinelCollider = value; }
    public GameObject CanvasObj { get => canvasObj; set => canvasObj = value; }

    private void Awake()
    {
        sentinelStateController = GetComponent<SentinelStateController>();
        sentinelCollider = GetComponent<BoxCollider2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        PV = GetComponent<PhotonView>();
        SentinelVision = GetComponentInParent<SentinelVision>();
        AudioSource = GetComponentInParent<AudioSource>();
        damageable = GetComponent<DamageableSentinel>();



        
    }

    public void Shoot()
    {
        //atira bala: PASSAR PARA OS STATES
        GameObject bullet = Instantiate(sentinelBullet, spawnTransform.position, spawnTransform.rotation);
        bullet.layer = this.gameObject.layer;

        audioSource.clip = AttackClip;
        audioSource.Play();


    }


}
