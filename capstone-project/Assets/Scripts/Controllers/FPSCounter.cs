using System.Collections;
using TMPro;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    public TextMeshProUGUI textField;

    private float fps = 0f;

    public IEnumerator Start()
    {
        QualitySettings.vSyncCount = 1;
        while (true)
        {
            fps = 1f / Time.unscaledDeltaTime;
            yield return new WaitForSeconds(0.1f);
        }
    }

    void Update()
    {
        textField.text = $"FPS: {Mathf.Round(fps)}";
    }

}
