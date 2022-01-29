using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour
{
    public float speed = 0.03f;
    public GameObject player;
    //public GameObject head;
    public Transform mainCam;


    public GameObject missionClear;
    public GameObject gameOver;
    public GameObject trapMessage;
    public GameObject timeMessage;
    public Text limitTimer;
    //public Transform playerTrans;
    // Start is called before the first frame update
    void Start()
    {
        missionClear.SetActive(false);
        gameOver.SetActive(false);
        trapMessage.SetActive(false);
        StartCoroutine(NoneTimeMessage());
    }

    // Update is called once per frame
    void Update()
    {
        MazeGenerator.timer -= Time.deltaTime;
        limitTimer.text = "남은 시간 : " + Mathf.Round(MazeGenerator.timer)+ " 초";
        
        Vector3 dir = mainCam.TransformDirection(Vector3.forward);
        if (Input.GetMouseButton(0))
        {
            player.transform.Translate(dir * speed);
        }

        //level.text = lev + " 단계";
        if (Mathf.Round(MazeGenerator.timer) == 0f)
        {
            gameOver.SetActive(true);
            SceneManager.LoadScene("GameScene");
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("EndPoint"))
        {
            missionClear.SetActive(true);
            endSound.instance.PlaySound();
            StartCoroutine(StageUp());
        }
        if (other.gameObject.tag.Equals("Trap")) //순간이동
        {
            trapSound.instance.PlaySound();
            player.transform.position = new Vector3(MazeGenerator.cellMap[Random.Range(0, MazeGenerator.width - 1), Random.Range(0, MazeGenerator.height - 1)].transform.position.x + 0.5f,
                MazeGenerator.cellMap[Random.Range(0, MazeGenerator.width - 1), Random.Range(0, MazeGenerator.height - 1)].transform.position.y + 1.5f,
                MazeGenerator.cellMap[Random.Range(0, MazeGenerator.width - 1), Random.Range(0, MazeGenerator.height - 1)].transform.position.z - 0.5f);
            Destroy(other.gameObject);
            trapMessage.SetActive(true);
            StartCoroutine(NoneTrapMassage());
        }
        if (other.gameObject.tag.Equals("Coin"))
        {
            Destroy(other.gameObject);
            coinSound.instance.PlaySound();
        }
    }
    IEnumerator StageUp()
    {
        yield return new WaitForSeconds(2.0f);

        MazeGenerator.width += 2;
        MazeGenerator.height += 2;
        MazeGenerator.lev += 1;
        SceneManager.LoadScene("GameScene");
    }
    IEnumerator NoneTrapMassage()
    {
        yield return new WaitForSeconds(1.5f);
        trapMessage.SetActive(false);
    }
    IEnumerator NoneTimeMessage()
    {
        yield return new WaitForSeconds(1.5f);
        timeMessage.SetActive(false);
    }
}
