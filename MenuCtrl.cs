using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuCtrl : MonoBehaviour
{
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
        AudioSource AS = GetComponent<AudioSource>();
        AS.Play();
    }
    public void InfoView()
    {
        SceneManager.LoadScene("InfoScene");
        AudioSource AS = GetComponent<AudioSource>();
        AS.Play();
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void MenuView()
    {
        SceneManager.LoadScene("MenuScene");
        AudioSource AS = GetComponent<AudioSource>();
        AS.Play();
    }
}
