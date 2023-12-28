using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue info;
    public GameObject startButton; // Start 버튼을 연결하기 위한 변수

    public void Trigger()
    {
        var system = FindObjectOfType<DialogueSystem>();
        system.Begin(info);

        // 대화 시작 시 Start 버튼을 숨기기
        if (startButton != null)
        {
            startButton.SetActive(true);
        }
    }
}
