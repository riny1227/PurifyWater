using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public Text txtName;    // ĳ���� �̸��� ǥ���ϴ� �ؽ�Ʈ ������Ʈ
    public Text txtSentence; // ��ȭ ������ ǥ���ϴ� �ؽ�Ʈ ������Ʈ\

    Queue<string> sentences = new Queue<string>(); // ��ȭ ������ �����ϴ� ť

    public Animator anim; // ��ȭâ �ִϸ�����

    private void Start()
    {

    }

    // ��ȭ ���� �޼���
    public void Begin(Dialogue info)
    {
        anim.SetBool("isOpen", true); // �ִϸ��̼��� ���� ���·� ����
        sentences.Clear(); // ���� ��ȭ ������ ���

        txtName.text = info.name; // ��ȭâ�� �̸� �ؽ�Ʈ ������Ʈ

        // ��ȭ �������� �� ������ ť�� �߰�
        foreach (var sentence in info.sentences)
        {
            sentences.Enqueue(sentence);
        }

        Next(); // ���� ��ȭ ����
    }

    // ���� ��ȭ�� �Ѿ�� �޼���
    public void Next()
    {
        // ť�� �� �̻� ��ȭ�� ������ ��ȭ ����
        if (sentences.Count == 0)
        {
            End();
            return;
        }

        txtSentence.text = string.Empty; // ��ȭ �ؽ�Ʈ �ʱ�ȭ
        StopAllCoroutines(); // ��� �ڷ�ƾ ����
        StartCoroutine(TypeSentence(sentences.Dequeue())); // ���� ���� ����� ���� �ڷ�ƾ ����
    }

    // ������ �� ���ھ� ����ϴ� �ڷ�ƾ
    IEnumerator TypeSentence(string sentence)
    {
        foreach (var letter in sentence)
        {
            txtSentence.text += letter;
            yield return new WaitForSeconds(0.1f);
        }
    }

    // ��ȭ ���� �� ȣ��Ǵ� �޼���
    private void End()
    {
        // ��ȭ�� ����Ǹ� "Stage1" ������ ��ȯ
        SceneManager.LoadScene("Stage1");
    }
}
