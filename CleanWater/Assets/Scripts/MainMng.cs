using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMng : MonoBehaviour
{
    public GameObject HowToPlayPanel;   // ���ӹ�� �� ���۹�� �г�
    public GameObject MainPanel;   // ����ȭ�� �г�

    // Start is called before the first frame update
    void Start()
    {
        // ����ȭ�� �г� Ȱ��ȭ
        if (MainPanel != null)
        {
            MainPanel.SetActive(true);
        }

        // ���� ��� �г� ��Ȱ��ȭ
        if (HowToPlayPanel != null)
        {
            HowToPlayPanel.SetActive(false);
        }
    }

    // �ݱ� ��ư Ŭ�� �� ȣ���� �޼���
    public void Exit()
    {
        // ���� ��� �г� ��Ȱ��ȭ
        if (HowToPlayPanel != null)
        {
            HowToPlayPanel.SetActive(false);
        }

        // ����ȭ�� �г� Ȱ��ȭ
        if (MainPanel != null)
        {
            MainPanel.SetActive(true);
        }
    }

    // ���� ���� ��ư Ŭ�� �� ȣ���� �޼���
    public void StartGame()
    {
        SceneManager.LoadScene("Dialogue");   // ��ȭ�� �ε�
    }

    // ���ӹ�� ��ư Ŭ�� �� ȣ���� �޼���
    public void ShowHowToPlayPanel()
    {
        // ���ӹ�� ���� �г� Ȱ��ȭ
        if (HowToPlayPanel != null)
        {
            HowToPlayPanel.SetActive(true);
        }

        // ����ȭ�� �г� ��Ȱ��ȭ
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
