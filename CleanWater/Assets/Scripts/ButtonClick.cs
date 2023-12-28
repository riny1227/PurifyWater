using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    public int size = 7;
    public GameObject[] buttonImages; // 버튼 이미지들을 담을 배열
    public GameObject[] buttons; // 버튼들을 담을 배열

    private void Start()
    {
        // 게임 시작 시 이미지들을 비활성화
        for (int i = 0; i < size; i++)
        {
            buttonImages[i].SetActive(false);
        }
    }

    // 버튼 클릭 시 호출될 함수
    public void OnButtonClick(int buttonIndex)
    {
        if (buttonImages != null && buttonImages.Length > buttonIndex && !buttonImages[buttonIndex].activeSelf)
        {
            buttonImages[buttonIndex].SetActive(true); // 해당하는 이미지를 활성화
            StartCoroutine(ShowAndHideImage(buttonIndex));
        }
    }

    // 해당하는 이미지를 보여주고 1.5초 뒤에 숨기는 코루틴 함수
    private IEnumerator ShowAndHideImage(int index)
    {
        yield return new WaitForSeconds(1.5f); // 1.5초 대기
        buttonImages[index].SetActive(false); // 해당하는 이미지를 숨김
    }

    public void LoadNextScene()
    {
        //SceneManager.LoadScene("다음씬 제목");
    }
}
