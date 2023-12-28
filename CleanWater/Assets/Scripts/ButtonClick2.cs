using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonClick2 : MonoBehaviour
{
    public GameObject[] imagesInOrder; // 석영, 활성탄, 모래, 자갈 이미지를 담을 배열
    public Button[] buttonsInOrder; // 석영, 활성탄, 모래, 자갈 버튼을 담을 배열
    public Text wrongOrderText; // 순서가 틀렸을 때 표시할 텍스트 UI
    public Text correctOrderText; // 순서 && 재료가 맞았을 때 표시할 텍스트 UI
    public GameObject Arrow; // 화살표 게임 오브젝트
    public GameObject FinishPanel; // 완성패널

    private int currentIndex = 0; // 현재 순서

    private void Start()
    {
        wrongOrderText.gameObject.SetActive(false);
        correctOrderText.gameObject.SetActive(false);
        AttachButtonClickHandlers();
    }

    // 각 버튼에 클릭 이벤트 핸들러 연결
    private void AttachButtonClickHandlers()
    {
        for (int i = 0; i < buttonsInOrder.Length; i++)
        {
            int buttonIndex = i; // 버튼 인덱스 변수에 할당 (클로저 문제 해결)

            buttonsInOrder[i].onClick.AddListener(() =>
            {
                OnButtonClick(buttonIndex);
            });
        }
    }

    // 버튼 클릭 시 호출될 함수
    public void OnButtonClick(int buttonIndex)
    {
        if (buttonIndex == currentIndex) // 버튼 순서가 현재 이미지 순서와 일치한다면
        {
            ShowCorrectOrderText(); // 순서가 맞았다는 텍스트 표시
            StartCoroutine(ShowImageAfterDelay(currentIndex)); // 1.5초 후에 이미지 활성화
            currentIndex++; // 다음 이미지 인덱스로 이동

            if (currentIndex >= imagesInOrder.Length)
            {
                currentIndex = 0; // 모든 이미지 표시가 끝났을 때 인덱스 초기화
                StartCoroutine(ActivateFinishPanelDelayed());
            }
        }
        else // 버튼 순서가 현재 이미지 순서와 일치하지 않는다면
        {
            ShowWrongOrderText(); // 순서가 틀렸다는 텍스트 표시
        }
    }

    // 순서가 맞았다는 텍스트 표시 함수
    private void ShowCorrectOrderText()
    {
        correctOrderText.gameObject.SetActive(true);
        StartCoroutine(HideTextAfterDelay(correctOrderText));

        // ArrowMove 스크립트의 originalPosition을 y축으로 1.76 증가
        Arrow.GetComponent<ArrowMove>().UpdateOriginalPosition();
    }

    // 순서가 틀렸다는 텍스트 표시 함수
    private void ShowWrongOrderText()
    {
        wrongOrderText.gameObject.SetActive(true);
        StartCoroutine(HideTextAfterDelay(wrongOrderText));
    }

    // 텍스트 숨기기 함수
    private IEnumerator HideTextAfterDelay(Text text)
    {
        yield return new WaitForSeconds(1.5f);
        text.gameObject.SetActive(false);
    }

    // 이미지를 활성화하는 코루틴 함수
    private IEnumerator ShowImageAfterDelay(int index)
    {
        yield return new WaitForSeconds(1.5f); // 1.5초 대기 후
        imagesInOrder[index].SetActive(true); // 현재 이미지 활성화
    }

    // FinishPanel을 활성화하는 함수
    private IEnumerator ActivateFinishPanelDelayed()
    {
        yield return new WaitForSeconds(2.0f); // 2초 대기 후
        FinishPanel.SetActive(true); // 완성 패널 활성화
    }
}
