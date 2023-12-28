using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue info;
    public GameObject startButton; // Start ��ư�� �����ϱ� ���� ����

    public void Trigger()
    {
        var system = FindObjectOfType<DialogueSystem>();
        system.Begin(info);

        // ��ȭ ���� �� Start ��ư�� �����
        if (startButton != null)
        {
            startButton.SetActive(true);
        }
    }
}
