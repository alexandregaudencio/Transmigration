using Assets._Game.Gameplay.Script.NPC_sentinel;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentinelController : MonoBehaviour
{
    [SerializeField] [Range(0,5)] private float bulletSpawnInterval;

    [SerializeField] private GameObject sentinelBullet;
    [SerializeField] private Transform weaponBase;
    [SerializeField] private Transform spawnTransform;

    [SerializeField] private Sprite spriteSleep;
    [SerializeField] private Sprite spriteAttack;

    private TargetVision targetVision;
    private SentinelStateController SentinelStateController;
    private AudioSource audioSource;
    private SpriteRenderer spriteRenderer;
    private PhotonView PV;

    public AudioClip shootClip;
    public AudioClip onVisionClip;

    public TargetVision TargetVision { get => targetVision; set => targetVision = value; }
    public AudioSource AudioSource { get => audioSource; set => audioSource = value; }
    public SpriteRenderer SpriteRenderer { get => spriteRenderer; set => spriteRenderer = value; }
    public Transform WeaponBase { get => weaponBase; set => weaponBase = value; }
    public Sprite SpriteSleep { get => spriteSleep; set => spriteSleep = value; }
    public Sprite SpriteAttack { get => spriteAttack; set => spriteAttack = value; }
    public GameObject SentinelBullet { get => sentinelBullet; set => sentinelBullet = value; }
    public Transform SpawnTransform { get => spawnTransform; set => spawnTransform = value; }

    //private enum States
    //{
    //    SLEEP,
    //    ATTACK,
    //    DEAD
    //}

    //private States sentinelState;


    private void Awake()
    {
        SentinelStateController = new SentinelStateController();
        TargetVision = GetComponentInParent<TargetVision>();
        AudioSource = GetComponentInParent<AudioSource>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        PV = GetComponent<PhotonView>();
        
    }


    void Start()
    {
        //sentinelState = States.SLEEP;
        //StartCoroutine(WaitToShoot());
        

    }

    private void Update()
    {

        ////if (sentinelState != States.DEAD)
        ////{
        //    if (targetVision.TargetOnVision)
        //    {
        //        sentinelState = States.ATTACK;
        //    }
        //    else
        //    {
        //        sentinelState = States.SLEEP;
        //    }
        //}

        //if (sentinelState == States.SLEEP)
        //{
        //    spriteRenderer.sprite = spriteSleep;
        //    //StopCoroutine(WaitToShoot());

        //}

        ////if (sentinelState == States.ATTACK)
        ////{
        //    weaponBase.rotation = targetVision.targetRotation;
        //    spriteRenderer.sprite = spriteAttack;

        ////}
    }


    //private IEnumerator WaitToShoot()
    //{
    //    while (TargetVision.TargetOnVision)
    //    {
    //        Shoot();
    //        yield return new WaitForSeconds(bulletSpawnInterval);
    //    }

    //}



    private void Shoot()
    {
        //atira
        GameObject bullet = Instantiate(sentinelBullet, spawnTransform.position, spawnTransform.rotation);
        bullet.layer = this.gameObject.layer;



        //PV.RPC("DefaultShoot", RpcTarget.All);
        //INSTANCIAR EFEITOS AQUI
        AudioSource.clip = shootClip;
        AudioSource.Play();

        //}

    }

    //[PunRPC]
    //public void DefaultShoot()
    //{
    //    GameObject bullet = Instantiate(sentinelBullet, spawnTransform.position, spawnTransform.rotation);
    //    bullet.layer = this.gameObject.layer;

    //}


    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (/*IsDifferentLayer(collision.gameObject.layer) && */!collision.gameObject.CompareTag("bullet"))
    //    {
    //        //audioSource.clip = onVisionClip;
    //        //audioSource.Play();
    //    }

    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{

    //    if (/*IsDifferentLayer(collision.gameObject.layer) &&*/ !collision.gameObject.CompareTag("bullet"))
    //    {

    //        GetComponent<SpriteRenderer>().sprite = spriteStandard;

    //    }
    //}

    // private bool IsDifferentLayer(LayerMask layer)
    // {

    //     if(this.gameObject.layer == LayerMask.NameToLayer("TeamA") && layer.value == LayerMask.NameToLayer("TeamB"))
    //     {
    //         return true;
    //     }
    //     else if(this.gameObject.layer == LayerMask.NameToLayer("TeamB") && layer.value == LayerMask.NameToLayer("TeamA"))
    //     {
    //         return true;
    //     }
    //     else
    //     {
    //         return false;
    //     }

    //}




}
