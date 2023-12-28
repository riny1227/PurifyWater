using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject pauseMenu; // 일시 정지 메뉴 창

    void Update()
    {
        // 'P' 키를 눌렀을 때 게임 일시 정지 토글
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePauseGame();
        }
    }

    void TogglePauseGame()
    {
        // 현재 게임의 일시 정지 상태 확인
        bool isGamePaused = Time.timeScale == 0;

        // 일시 정지 상태에 따라 처리
        if (!isGamePaused)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    public void PauseGame()
    {
        // 게임 일시 정지
        Time.timeScale = 0;

        // 일시 정지 메뉴 창을 활성화
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(true);
        }
    }

    public void ResumeGame()
    {
        // 게임 재개
        Time.timeScale = 1;

        // 일시 정지 메뉴 창을 비활성화
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false);
        }
    }
}