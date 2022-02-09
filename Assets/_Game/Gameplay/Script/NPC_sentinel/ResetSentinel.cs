using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSentinel : MonoBehaviour
{

    [SerializeField] private GameObject setinel;

    SentinelController sentinelController;
    DamageableSentinel damageableSentinel;
    private void Awake()
    {
        sentinelController = setinel.GetComponent<SentinelController>();
        damageableSentinel = setinel.GetComponent<DamageableSentinel>();

    }


    public IEnumerator ResetingSentinel()
    {
        yield return new WaitForSeconds(GameConfigs.instance.resetSentineltime);
        setinel.SetActive(true);
    }




}
