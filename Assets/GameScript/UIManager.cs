using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject textArea;
    public Text gameText;
    public Text subText;
    public Text distanceText;
    public Text timeText;
    public Text playingDistance;
    public Text playingTime;
    public GameObject player;
    float startTime;

    string distance;
    string time;

    private void Start()
    {
        startTime = 0;
    }

    private void Update()
    {
        ShowDisTance();

        startTime += Time.deltaTime; //재시작 시 다시 0초로 돌아가야 하므로

        distance = player.transform.position.z + "km";
        time = "시간 : " + Mathf.Round(startTime) + "초";
    }

    public void GameOver()
    {
        //게임 정지
        player.GetComponent<PlayerMove>().nowGame = false;
        playingDistance.gameObject.SetActive(false);
        playingTime.gameObject.SetActive(false);

        //UI 보이기
        textArea.SetActive(true);
        gameText.text = "Game Over";
        subText.text = "아깝다! 다시 하면 될 것 같아!";
        distanceText.text = distance;
        timeText.text = time;
    }

    public void GameClear()
    {
        //게임 정지
        playingDistance.gameObject.SetActive(false);
        playingTime.gameObject.SetActive(false);

        //UI 보이기
        textArea.SetActive(true);
        gameText.GetComponent<Text>().text = "Game Clear";
        subText.GetComponent<Text>().text = "이 정도야 쉽지!";
        distanceText.text = distance;
        timeText.text = time;
    }

    public void ReStart()
    {
        SceneManager.LoadScene(1);
    }

    void ShowDisTance()
    {
        playingDistance.text = distance;
        playingTime.text = time;
    }
}
