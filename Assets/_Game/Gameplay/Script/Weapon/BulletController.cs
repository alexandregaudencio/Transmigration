using Player.Data.Score;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    [SerializeField] private GameObject collisioneffect;

    [SerializeField] private List<string> collisionTagsToIgnore;
    [SerializeField] private List<string> collisionTagsToDetect;
    [SerializeField] private PlayerScore playerScore;

    public PlayerScore PlayerScore { get => playerScore; set => playerScore = value; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collisionTagsToIgnore.Contains(collision.tag) && gameObject.layer != collision.gameObject.layer)
        {
            OnBulletCollision(collision);

        }
    }

    void OnBulletCollision(Collider2D collision)
    {
        if(collisioneffect != null)
        {
            GameObject effect = Instantiate(collisioneffect, transform.position, Quaternion.identity);
            IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
            if (damageable != null) effect.GetComponent<AudioSource>().Play();

        }

        DestroyBullet();
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);

    }

}
