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
    private AudioSource audioSource;
    private SpriteRenderer spriteRenderer;
    private PhotonView PV;

    public AudioClip shootClip;
    public AudioClip onVisionClip;

    //private void Awake()
    //{
    //    audioSource = GetComponent<AudioSource>();
    //}

    public enum States
    {
        SLEEP,
        ATTACK,
        DEAD
    }

    public States sentinelState;

    private void Awake()
    {
        targetVision = GetComponentInParent<TargetVision>();
        audioSource = GetComponentInParent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        PV = GetComponent<PhotonView>();
        
    }


    void Start()
    {
        sentinelState = States.SLEEP;
        StartCoroutine(WaitToShoot());

    }

    private void Update()
    {



        if (sentinelState != States.DEAD)
        {
            if(targetVision.TargetOnVision)
            {
                sentinelState = States.ATTACK;
            } else
            {
                sentinelState = States.SLEEP;
            }
        }

        if(sentinelState == States.SLEEP)
        {
            spriteRenderer.sprite = spriteSleep;

        }

        if (sentinelState == States.ATTACK)
        {
            weaponBase.rotation = targetVision.targetRotation;
            spriteRenderer.sprite = spriteAttack;

        }
    }


    private IEnumerator WaitToShoot()
    {
        while (targetVision.TargetOnVision)
        {
            yield return new WaitForSeconds(bulletSpawnInterval);
            Shoot();
        }
        


    }



    private void Shoot()
    {

  
        //atira
        GameObject bullet = Instantiate(sentinelBullet, spawnTransform.position, spawnTransform.rotation);
        bullet.layer = this.gameObject.layer;


        //PV.RPC("DefaultShoot", RpcTarget.All);
        //INSTANCIAR EFEITOS AQUI
        audioSource.clip = shootClip;
        audioSource.Play();

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
