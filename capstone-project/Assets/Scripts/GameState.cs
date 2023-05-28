using UnityEngine;

public class GameState : MonoBehaviour
{
    public static bool isPlayerFrozen { get => openedCanvas != 0; }
    public static int openedCanvas = 0;
}
