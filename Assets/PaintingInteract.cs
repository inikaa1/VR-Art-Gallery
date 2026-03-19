using UnityEngine;

public class PaintingInteract : MonoBehaviour
{
    public Transform player;
    public SimpleFPS playerScript;
    public Transform viewPoint;

    private bool isViewing = false;

    void Update()
    {
        if (isViewing && Input.GetKeyDown(KeyCode.X))
        {
            ExitView();
        }
    }

    void OnMouseDown()
    {
        EnterView();
    }

    void EnterView()
    {
        isViewing = true;

        // Stop player movement
        playerScript.enabled = false;

        // Move player to the viewing position
        player.position = viewPoint.position;
        player.rotation = viewPoint.rotation;

        // Unlock cursor so player can press X
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void ExitView()
    {
        isViewing = false;

        // Re-enable movement
        playerScript.enabled = true;

        // Lock cursor again for FPS movement
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}