using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBehaviour : MonoBehaviour {

    AudioSource firesound;
    private void Start()
    {
        firesound = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ghost"))
        {
            if (other.transform.name == "PF_GoodSoul(Clone)")
                GameManager.instance.UpdateLife();

            if (!firesound.isPlaying)
            {
                firesound.Play();
            }
            Destroy(other.gameObject);


        }
    }
}
