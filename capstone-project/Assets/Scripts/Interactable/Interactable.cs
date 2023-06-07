using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public string promptMessage;
    [HideInInspector] public bool interactable = true;

    public bool isEmitting;
    public Color pulseColor;
    [Range(0f, 1f)] public float pulseSpeed = 5f;
    private float intensity = 0;
    private bool pulseForward = true;

    private Material material;


    private void Awake()
    {
        interactable = true;
        try
        {
            material = GetComponent<Renderer>().materials[1];
            StartPulse();
        }
        catch { }
    }

    public void StartPulse()
    {
        isEmitting = true;
        material?.EnableKeyword("_EMISSION");
    }

    public void StopPulse()
    {
        isEmitting = false;
        material?.DisableKeyword("_EMISSION");
    }

    void Update()
    {
        if (!isEmitting || GameState.isPlayerFrozen)
            return;

        if (pulseForward)
        {
            intensity += pulseSpeed * Time.deltaTime;
            pulseForward = !(intensity >= 1f);
        }
        else
        {
            intensity -= pulseSpeed * Time.deltaTime;
            pulseForward = intensity <= 0;
        }

        material?.SetColor("_EmissionColor", pulseColor * intensity);
    }

    public void BaseInteract()
    {
        if (!interactable) 
            return;

        Interact();
    }

    public abstract void Interact();
}
