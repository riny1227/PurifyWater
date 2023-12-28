using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public Text txtName;    // 캐릭터 이름을 표시하는 텍스트 오브젝트
    public Text txtSentence; // 대화 내용을 표시하는 텍스트 오브젝트\

    Queue<string> sentences = new Queue<string>(); // 대화 문장을 저장하는 큐

    public Animator anim; // 대화창 애니메이터

    private void Start()
    {

    }

    // 대화 시작 메서드
    public void Begin(Dialogue info)
    {
        anim.SetBool("isOpen", true); // 애니메이션을 열린 상태로 설정
        sentences.Clear(); // 기존 대화 내용을 비움

        txtName.text = info.name; // 대화창의 이름 텍스트 업데이트

        // 대화 정보에서 각 문장을 큐에 추가
        foreach (var sentence in info.sentences)
        {
            sentences.Enqueue(sentence);
        }

        Next(); // 다음 대화 진행
    }

    // 다음 대화로 넘어가는 메서드
    public void Next()
    {
        // 큐에 더 이상 대화가 없으면 대화 종료
        if (sentences.Count == 0)
        {
            End();
            return;
        }

        txtSentence.text = string.Empty; // 대화 텍스트 초기화
        StopAllCoroutines(); // 모든 코루틴 중지
        StartCoroutine(TypeSentence(sentences.Dequeue())); // 다음 문장 출력을 위해 코루틴 시작
    }

    // 문장을 한 글자씩 출력하는 코루틴
    IEnumerator TypeSentence(string sentence)
    {
        foreach (var letter in sentence)
        {
            txtSentence.text += letter;
            yield return new WaitForSeconds(0.1f);
        }
    }

    // 대화 종료 시 호출되는 메서드
    private void End()
    {
        // 대화가 종료되면 "Stage1" 씬으로 전환
        SceneManager.LoadScene("Stage1");
    }
}
