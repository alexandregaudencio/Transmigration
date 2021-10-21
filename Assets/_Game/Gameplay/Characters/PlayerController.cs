using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRigidbody2D;
    [SerializeField] private float speed;
    [SerializeField] private int impulse;
    [SerializeField] private int maxYVelocity;

    [Header("Jatkack Settings")]
    [SerializeField] private int minFloatingToJatpack;
    [SerializeField] private int jatpackImpulse;
    [SerializeField] private KeyCode jetpackInput;
    public Text text;

    public bool isGround;
    public bool canJatpack;

    public bool IsGround { get => isGround; set => isGround = value; }

    // Start is called before the first frame update
    void Awake()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Move();
        ProcessJatpack();
        //text.text = Mathf.Round(playerRigidbody2D.velocity.y).ToString();

    //FLIP
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        if(direction.x < 0.0000f)
        {
            transform.rotation = Quaternion.Euler(0,180f, 0);
        } else
        {
            transform.rotation = Quaternion.Euler(0, 0f, 0);

        }
    }

    private void Move()
    {
        playerRigidbody2D.velocity = new Vector2(Input.GetAxis("Horizontal")*Time.fixedDeltaTime*speed, playerRigidbody2D.velocity.y);
    }

    void ProcessJatpack()
    {

        if (isGround)
        {
            if (Input.GetKeyDown(jetpackInput))
            {
                playerRigidbody2D.AddForce(new Vector2(playerRigidbody2D.velocity.x, impulse), ForceMode2D.Impulse);
            }
        } 



        if(canJatpack)
        {

            if (Input.GetKey(jetpackInput) ) {
                if(Mathf.Round(playerRigidbody2D.velocity.y) <= maxYVelocity)
                {
                    playerRigidbody2D.AddForce(new Vector2(0, jatpackImpulse), ForceMode2D.Force);
                    GetComponent<SpriteRenderer>().color = Color.blue;
                }

            } else
            {
                GetComponent<SpriteRenderer>().color = Color.yellow;

            }
        }
           



        if(!IsGround && Mathf.Round(playerRigidbody2D.velocity.y) < minFloatingToJatpack && !canJatpack)
        {

            canJatpack = true;
            GetComponent<SpriteRenderer>().color = Color.yellow;

        } 


    }




    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("ground"))
        {
            isGround = true;
            canJatpack = false;
            GetComponent<SpriteRenderer>().color = Color.white;

        }
    }

    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGround = false;
        }
    }



}
