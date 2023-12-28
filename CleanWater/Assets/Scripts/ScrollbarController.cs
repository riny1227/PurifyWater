using UnityEngine;
using UnityEngine.UI;

public class ScrollbarController : MonoBehaviour
{
    public Scrollbar scrollbar;

    // Start is called before the first frame update
    void Start()
    {
        // 스크롤바의 값을 감시하는 이벤트를 등록합니다.
        scrollbar.onValueChanged.AddListener(OnScrollbarValueChanged);
    }

    // 스크롤바 값이 변경될 때 호출되는 함수
    void OnScrollbarValueChanged(float value)
    {
        // 스크롤바 값에 따라 어떤 작업을 수행하거나 스크롤에 대응하는 로직을 구현합니다.
        Debug.Log("Scrollbar Value: " + value);
    }
}
