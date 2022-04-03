using UnityEngine;
using UnityEngine.UI;

public class TombstoneController : MonoBehaviour
{
    [SerializeField] private GameObject textObject;
    private ParticleSystem particle;
    [SerializeField] private KeyCode key;
    [SerializeField] private string targetTeam;
    [SerializeField] private float emissionRate = 20;
    ParticleSystem.EmissionModule emissionModule;

    [SerializeField] private float maxMeditating;
    public float meditatingCount;

    private bool canMeditate = false;
    [SerializeField] private bool RedTombstone;
    [SerializeField] private AudioSource audioSource;
    public AudioClip playDoneClip;

    [SerializeField] private ResetTombstone resetTombstone;


    [SerializeField] private Image image_meditateBar; 


    public float meditateBarFraction => meditatingCount / maxMeditating;

    private void Start()
    {
        particle = GetComponent<ParticleSystem>();
        emissionModule = particle.emission;
        emissionModule.rateOverTime = 0;

    }

    private void FixedUpdate()
    {
        if (canMeditate) Meditate();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (/*!IsDifferentLayer(collision.gameObject.layer) && */collision.gameObject.CompareTag("character"))
        {     
            Debug.Log("On Meditation.");
            OnMeditationZone(true);
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       if(/*!IsDifferentLayer(collision.gameObject.layer) &&*/ collision.gameObject.CompareTag("character")) 
        {
            Debug.Log("Out Meditation.");
            OnMeditationZone(false);
        }

    }

    public void OnMeditationZone(bool value)
    {
        canMeditate = value;
        textObject.SetActive(value);
        updateUImeditate();


    }

    void updateUImeditate()
    {
        image_meditateBar.fillAmount = meditateBarFraction;
    }

    public void Meditate()
    {

        if (Input.GetKey(key))
        {
            UpdateMeditateCount();
        }


        if (Input.GetKeyDown(key))
        {
            OnMeditate(emissionRate);

        }

        if(Input.GetKeyUp(key))
        {
            OnMeditate(0);
        }

        if (meditatingCount >= maxMeditating)
        {
            //PONTUAÇÃO
            MeditationCompleted();
        }


    }

    public void OnMeditate(float isMeditating)
    {
        emissionModule.rateOverTime = isMeditating;
    }

    public void UpdateMeditateCount()
    {
        meditatingCount += Time.fixedDeltaTime;
    }

    public void MeditationCompleted()
    {
        audioSource.clip = playDoneClip;
        audioSource.Play();
        resetTombstone.ResetingTombstone();
        gameObject.SetActive(false);
    }

    private bool IsDifferentLayer(LayerMask layer)
    {

        if (gameObject.layer == LayerMask.NameToLayer("TeamA") && layer.value == LayerMask.NameToLayer("TeamB"))
        {
            return true;
        }
        else if (gameObject.layer == LayerMask.NameToLayer("TeamB") && layer.value == LayerMask.NameToLayer("TeamA"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }


}
