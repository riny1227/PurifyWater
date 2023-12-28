using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    // ���� ������ ǥ���ϴ� �̹��� UI
    public Image questionImage;

    // ���� ��ư�� ���� ��ư
    public Button trueButton;
    public Button falseButton;

    // ���� ����� ǥ���ϴ� �̹��� UI
    public Image resultImage;

    // Retry �̹���
    public Image retryImage;

    // ���� ���� �̹��� �迭
    public Sprite[] questionImages;

    // ���� ���� �ε���
    private int currentQuestionIndex = 0;

    void Start()
    {
        // �ʱ�ȭ �޼��� ȣ��
        DisplayQuestion();
    }

    // ���� ������ ǥ���ϴ� �޼���
    void DisplayQuestion()
    {
        // ��� �̹��� ��Ȱ��ȭ
        resultImage.gameObject.SetActive(false);

        // RETRY �̹��� ��Ȱ��ȭ
        retryImage.gameObject.SetActive(false);

        // ���� ���� �̹����� ǥ��
        questionImage.sprite = questionImages[currentQuestionIndex];
        questionImage.gameObject.SetActive(true);

        // ��ư Ȱ��ȭ
        trueButton.gameObject.SetActive(true);
        falseButton.gameObject.SetActive(true);
    }

    // "O" ��ư Ŭ�� �� ȣ��Ǵ� �޼���
    public void OnTrueButtonClicked()
    {
        // ���� Ȯ�� �޼��� ȣ��
        CheckAnswer(true);
    }

    // "X" ��ư Ŭ�� �� ȣ��Ǵ� �޼���
    public void OnFalseButtonClicked()
    {
        // ���� Ȯ�� �޼��� ȣ��
        CheckAnswer(false);
    }

    // ���� Ȯ�� �޼���
    void CheckAnswer(bool userAnswer)
    {
        // RETRY ȭ�� ǥ��
        if (!userAnswer)
        {
            StartCoroutine(ShowRetryImageForSeconds(2f));
        }
        else
        {
            // ���� ���ο� ���� ��� �̹��� ǥ��
            resultImage.gameObject.SetActive(true);

            // ��ư ��Ȱ��ȭ
            trueButton.interactable = false;
            falseButton.interactable = false;

            // ���� ����� �̵� (��� �����ִ� ���)
            if (currentQuestionIndex < questionImages.Length - 1)
            {
                currentQuestionIndex++;
                StartCoroutine(DisplayNextQuestionAfterDelay(2f));
            }
            else
            {
                // ��� ����Ǹ� "Stage2" ������ ��ȯ
                SceneManager.LoadScene("Stage2");
            }
        }
    }

    IEnumerator ShowRetryImageForSeconds(float seconds)
    {
        // RETRY �̹��� Ȱ��ȭ
        retryImage.gameObject.SetActive(true);

        // ���� �ð� ���� ���
        yield return new WaitForSeconds(seconds);

        // RETRY �̹��� ��Ȱ��ȭ
        retryImage.gameObject.SetActive(false);
    }

    IEnumerator DisplayNextQuestionAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // ��ư ��Ȱ��ȭ �� ���� ���� ǥ��
        trueButton.interactable = true;
        falseButton.interactable = true;

        // ���� ���� ǥ��
        DisplayQuestion();
    }
}