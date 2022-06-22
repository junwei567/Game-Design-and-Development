using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBrick : MonoBehaviour
{
    private bool broken = false;
    public GameObject debris;
    private AudioSource breakAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        breakAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void  OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.CompareTag("Player") &&  !broken){
            broken  =  true;
            breakAudioSource.Play();
            // assume we have 5 debris per box
            for (int x =  0; x<5; x++){
                Instantiate(debris, transform.position, Quaternion.identity);
            }
            // breakAudioSource.PlayOneShot(breakAudioSource.clip);
            GetComponent<EdgeCollider2D>().enabled  =  false;
            Destroy(gameObject);
        }
    }
}
