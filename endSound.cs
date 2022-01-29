using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endSound: MonoBehaviour
{
    public AudioClip soundEnd;
    AudioSource myAudio;
    public static endSound instance;
    // Start is called before the first frame update
    void Awake()
    {
        if (endSound.instance == null)
        {
            endSound.instance = this;
        }
    }
    void Start()
    {
        myAudio = this.gameObject.GetComponent<AudioSource>();
    }
    public void PlaySound()
    {
        myAudio.PlayOneShot(soundEnd);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
