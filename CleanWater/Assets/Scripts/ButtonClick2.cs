using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonClick2 : MonoBehaviour
{
    public GameObject[] imagesInOrder; // ����, Ȱ��ź, ��, �ڰ� �̹����� ���� �迭
    public Button[] buttonsInOrder; // ����, Ȱ��ź, ��, �ڰ� ��ư�� ���� �迭
    public Text wrongOrderText; // ������ Ʋ���� �� ǥ���� �ؽ�Ʈ UI
    public Text correctOrderText; // ���� && ��ᰡ �¾��� �� ǥ���� �ؽ�Ʈ UI
    public GameObject Arrow; // ȭ��ǥ ���� ������Ʈ
    public GameObject FinishPanel; // �ϼ��г�

    private int currentIndex = 0; // ���� ����

    private void Start()
    {
        wrongOrderText.gameObject.SetActive(false);
        correctOrderText.gameObject.SetActive(false);
        AttachButtonClickHandlers();
    }

    // �� ��ư�� Ŭ�� �̺�Ʈ �ڵ鷯 ����
    private void AttachButtonClickHandlers()
    {
        for (int i = 0; i < buttonsInOrder.Length; i++)
        {
            int buttonIndex = i; // ��ư �ε��� ������ �Ҵ� (Ŭ���� ���� �ذ�)

            buttonsInOrder[i].onClick.AddListener(() =>
            {
                OnButtonClick(buttonIndex);
            });
        }
    }

    // ��ư Ŭ�� �� ȣ��� �Լ�
    public void OnButtonClick(int buttonIndex)
    {
        if (buttonIndex == currentIndex) // ��ư ������ ���� �̹��� ������ ��ġ�Ѵٸ�
        {
            ShowCorrectOrderText(); // ������ �¾Ҵٴ� �ؽ�Ʈ ǥ��
            StartCoroutine(ShowImageAfterDelay(currentIndex)); // 1.5�� �Ŀ� �̹��� Ȱ��ȭ
            currentIndex++; // ���� �̹��� �ε����� �̵�

            if (currentIndex >= imagesInOrder.Length)
            {
                currentIndex = 0; // ��� �̹��� ǥ�ð� ������ �� �ε��� �ʱ�ȭ
                StartCoroutine(ActivateFinishPanelDelayed());
            }
        }
        else // ��ư ������ ���� �̹��� ������ ��ġ���� �ʴ´ٸ�
        {
            ShowWrongOrderText(); // ������ Ʋ�ȴٴ� �ؽ�Ʈ ǥ��
        }
    }

    // ������ �¾Ҵٴ� �ؽ�Ʈ ǥ�� �Լ�
    private void ShowCorrectOrderText()
    {
        correctOrderText.gameObject.SetActive(true);
        StartCoroutine(HideTextAfterDelay(correctOrderText));

        // ArrowMove ��ũ��Ʈ�� originalPosition�� y������ 1.76 ����
        Arrow.GetComponent<ArrowMove>().UpdateOriginalPosition();
    }

    // ������ Ʋ�ȴٴ� �ؽ�Ʈ ǥ�� �Լ�
    private void ShowWrongOrderText()
    {
        wrongOrderText.gameObject.SetActive(true);
        StartCoroutine(HideTextAfterDelay(wrongOrderText));
    }

    // �ؽ�Ʈ ����� �Լ�
    private IEnumerator HideTextAfterDelay(Text text)
    {
        yield return new WaitForSeconds(1.5f);
        text.gameObject.SetActive(false);
    }

    // �̹����� Ȱ��ȭ�ϴ� �ڷ�ƾ �Լ�
    private IEnumerator ShowImageAfterDelay(int index)
    {
        yield return new WaitForSeconds(1.5f); // 1.5�� ��� ��
        imagesInOrder[index].SetActive(true); // ���� �̹��� Ȱ��ȭ
    }

    // FinishPanel�� Ȱ��ȭ�ϴ� �Լ�
    private IEnumerator ActivateFinishPanelDelayed()
    {
        yield return new WaitForSeconds(2.0f); // 2�� ��� ��
        FinishPanel.SetActive(true); // �ϼ� �г� Ȱ��ȭ
    }
}
