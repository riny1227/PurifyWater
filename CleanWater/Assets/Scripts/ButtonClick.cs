using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    public int size = 7;
    public GameObject[] buttonImages; // ��ư �̹������� ���� �迭
    public GameObject[] buttons; // ��ư���� ���� �迭

    private void Start()
    {
        // ���� ���� �� �̹������� ��Ȱ��ȭ
        for (int i = 0; i < size; i++)
        {
            buttonImages[i].SetActive(false);
        }
    }

    // ��ư Ŭ�� �� ȣ��� �Լ�
    public void OnButtonClick(int buttonIndex)
    {
        if (buttonImages != null && buttonImages.Length > buttonIndex && !buttonImages[buttonIndex].activeSelf)
        {
            buttonImages[buttonIndex].SetActive(true); // �ش��ϴ� �̹����� Ȱ��ȭ
            StartCoroutine(ShowAndHideImage(buttonIndex));
        }
    }

    // �ش��ϴ� �̹����� �����ְ� 1.5�� �ڿ� ����� �ڷ�ƾ �Լ�
    private IEnumerator ShowAndHideImage(int index)
    {
        yield return new WaitForSeconds(1.5f); // 1.5�� ���
        buttonImages[index].SetActive(false); // �ش��ϴ� �̹����� ����
    }

    public void LoadNextScene()
    {
        //SceneManager.LoadScene("������ ����");
    }
}
