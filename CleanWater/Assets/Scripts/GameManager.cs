using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject pauseMenu; // �Ͻ� ���� �޴� â

    void Update()
    {
        // 'P' Ű�� ������ �� ���� �Ͻ� ���� ���
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePauseGame();
        }
    }

    void TogglePauseGame()
    {
        // ���� ������ �Ͻ� ���� ���� Ȯ��
        bool isGamePaused = Time.timeScale == 0;

        // �Ͻ� ���� ���¿� ���� ó��
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
        // ���� �Ͻ� ����
        Time.timeScale = 0;

        // �Ͻ� ���� �޴� â�� Ȱ��ȭ
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(true);
        }
    }

    public void ResumeGame()
    {
        // ���� �簳
        Time.timeScale = 1;

        // �Ͻ� ���� �޴� â�� ��Ȱ��ȭ
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false);
        }
    }
}