using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonTooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject tooltip; // ����â�� ��Ÿ���� UI ���

    // ���콺�� ��ư ���� �÷��� �� ȣ��Ǵ� �޼���
    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltip.SetActive(true); // ����â�� Ȱ��ȭ�Ͽ� �����ݴϴ�.
    }

    // ���콺�� ��ư���� ����� �� ȣ��Ǵ� �޼���
    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.SetActive(false); // ����â�� ��Ȱ��ȭ�Ͽ� ����ϴ�.
    }
}
