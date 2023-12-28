using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMng : MonoBehaviour
{
    public GameObject HowToPlayPanel;   // 게임방법 및 조작방법 패널
    public GameObject MainPanel;   // 메인화면 패널

    // Start is called before the first frame update
    void Start()
    {
        // 메인화면 패널 활성화
        if (MainPanel != null)
        {
            MainPanel.SetActive(true);
        }

        // 게임 방법 패널 비활성화
        if (HowToPlayPanel != null)
        {
            HowToPlayPanel.SetActive(false);
        }
    }

    // 닫기 버튼 클릭 시 호출할 메서드
    public void Exit()
    {
        // 게임 방법 패널 비활성화
        if (HowToPlayPanel != null)
        {
            HowToPlayPanel.SetActive(false);
        }

        // 메인화면 패널 활성화
        if (MainPanel != null)
        {
            MainPanel.SetActive(true);
        }
    }

    // 게임 시작 버튼 클릭 시 호출할 메서드
    public void StartGame()
    {
        SceneManager.LoadScene("Dialogue");   // 대화씬 로드
    }

    // 게임방법 버튼 클릭 시 호출할 메서드
    public void ShowHowToPlayPanel()
    {
        // 게임방법 설명 패널 활성화
        if (HowToPlayPanel != null)
        {
            HowToPlayPanel.SetActive(true);
        }

        // 메인화면 패널 비활성화
        if (MainPanel != null)
        {
            MainPanel.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
