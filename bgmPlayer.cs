using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgmPlayer : MonoBehaviour
{
    public AudioClip[] Music = new AudioClip[5];
    AudioSource AS;

    void Awake()
    {
        AS = this.GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!AS.isPlaying)
        {
            RandomPlay();
        }
    }
    void RandomPlay()
    {
        AS.clip = Music[Random.Range(0, Music.Length)];
        AS.Play();
    }
}
