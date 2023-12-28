using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenURL : MonoBehaviour
{
    public void NewsURL()
    {
        Application.OpenURL("https://www.unicef.or.kr/what-we-do/news/168821/");
    }

    public void FormURL()
    {
        Application.OpenURL("https://forms.gle/mEBjqNZKzdsQ4pnn8");
    }
}
