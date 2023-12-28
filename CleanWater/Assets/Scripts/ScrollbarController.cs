using UnityEngine;
using UnityEngine.UI;

public class ScrollbarController : MonoBehaviour
{
    public Scrollbar scrollbar;

    // Start is called before the first frame update
    void Start()
    {
        // ��ũ�ѹ��� ���� �����ϴ� �̺�Ʈ�� ����մϴ�.
        scrollbar.onValueChanged.AddListener(OnScrollbarValueChanged);
    }

    // ��ũ�ѹ� ���� ����� �� ȣ��Ǵ� �Լ�
    void OnScrollbarValueChanged(float value)
    {
        // ��ũ�ѹ� ���� ���� � �۾��� �����ϰų� ��ũ�ѿ� �����ϴ� ������ �����մϴ�.
        Debug.Log("Scrollbar Value: " + value);
    }
}
