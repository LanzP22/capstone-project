using UnityEngine;
using UnityEngine.UI;

public class TabController : MonoBehaviour
{
    public GameObject[] tabs;

    public Color active;
    public Color inactive;

    public void ChangeTab(int tabIndex)
    {
        for (int i = 0; i < tabs.Length; i++) 
        {
            GameObject gameObj = tabs[i];
            if (gameObj == null) 
                continue;

            gameObj.SetActive(i == tabIndex - 1);

            GameObject button = gameObject.transform.GetChild(i).gameObject;

            button.GetComponent<Image>().color = i == tabIndex - 1 ? active : inactive;
        }
    }
}
