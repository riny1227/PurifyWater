using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    // 퀴즈 문제를 표시하는 이미지 UI
    public Image questionImage;

    // 정답 버튼과 오답 버튼
    public Button trueButton;
    public Button falseButton;

    // 정답 결과를 표시하는 이미지 UI
    public Image resultImage;

    // Retry 이미지
    public Image retryImage;

    // 퀴즈 문제 이미지 배열
    public Sprite[] questionImages;

    // 현재 퀴즈 인덱스
    private int currentQuestionIndex = 0;

    void Start()
    {
        // 초기화 메서드 호출
        DisplayQuestion();
    }

    // 퀴즈 문제를 표시하는 메서드
    void DisplayQuestion()
    {
        // 결과 이미지 비활성화
        resultImage.gameObject.SetActive(false);

        // RETRY 이미지 비활성화
        retryImage.gameObject.SetActive(false);

        // 현재 퀴즈 이미지를 표시
        questionImage.sprite = questionImages[currentQuestionIndex];
        questionImage.gameObject.SetActive(true);

        // 버튼 활성화
        trueButton.gameObject.SetActive(true);
        falseButton.gameObject.SetActive(true);
    }

    // "O" 버튼 클릭 시 호출되는 메서드
    public void OnTrueButtonClicked()
    {
        // 정답 확인 메서드 호출
        CheckAnswer(true);
    }

    // "X" 버튼 클릭 시 호출되는 메서드
    public void OnFalseButtonClicked()
    {
        // 정답 확인 메서드 호출
        CheckAnswer(false);
    }

    // 정답 확인 메서드
    void CheckAnswer(bool userAnswer)
    {
        // RETRY 화면 표시
        if (!userAnswer)
        {
            StartCoroutine(ShowRetryImageForSeconds(2f));
        }
        else
        {
            // 정답 여부에 따라 결과 이미지 표시
            resultImage.gameObject.SetActive(true);

            // 버튼 비활성화
            trueButton.interactable = false;
            falseButton.interactable = false;

            // 다음 퀴즈로 이동 (퀴즈가 남아있는 경우)
            if (currentQuestionIndex < questionImages.Length - 1)
            {
                currentQuestionIndex++;
                StartCoroutine(DisplayNextQuestionAfterDelay(2f));
            }
            else
            {
                // 퀴즈가 종료되면 "Stage2" 씬으로 전환
                SceneManager.LoadScene("Stage2");
            }
        }
    }

    IEnumerator ShowRetryImageForSeconds(float seconds)
    {
        // RETRY 이미지 활성화
        retryImage.gameObject.SetActive(true);

        // 일정 시간 동안 대기
        yield return new WaitForSeconds(seconds);

        // RETRY 이미지 비활성화
        retryImage.gameObject.SetActive(false);
    }

    IEnumerator DisplayNextQuestionAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // 버튼 재활성화 및 다음 문제 표시
        trueButton.interactable = true;
        falseButton.interactable = true;

        // 다음 문제 표시
        DisplayQuestion();
    }
}