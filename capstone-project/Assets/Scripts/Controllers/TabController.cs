using UnityEngine;
using UnityEngine.UI;

public class TabController : MonoBehaviour
{
    public GameObject[] tabs;

    public void ChangeTab(int tabIndex)
    {
        for (int i = 0; i < tabs.Length; i++) 
        {
            tabs[i].SetActive(i == tabIndex - 1);
        }
    }
}
