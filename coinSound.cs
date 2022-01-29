using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinSound : MonoBehaviour
{
    public AudioClip soundCoin;
    AudioSource myAudio;
    public static coinSound instance;
    // Start is called before the first frame update
    void Awake()
    {
        if(coinSound.instance == null)
        {
            coinSound.instance = this;
        }    
    }
    void Start()
    {
        myAudio = this.gameObject.GetComponent<AudioSource>();
    }
    public void PlaySound()
    {
        myAudio.PlayOneShot(soundCoin);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
