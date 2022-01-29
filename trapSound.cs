using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapSound : MonoBehaviour
{
    public AudioClip soundTrap;
    AudioSource myAudio;
    public static trapSound instance;
    void Awake()
    {
        if (trapSound.instance == null)
        {
            trapSound.instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        myAudio = this.gameObject.GetComponent<AudioSource>();
    }
    public void PlaySound()
    {
        myAudio.PlayOneShot(soundTrap);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
