using UnityEngine;

public class BanksyShredReveal : MonoBehaviour
{
    public Transform shreddedPart; // normal painting (moves down)
    public Transform playerCamera;

    public float triggerDistance = 2f;
    public float shredSpeed = 0.5f;

    private bool triggered = false;

    public AudioSource shredSound;

    // 🔥 YOUR EXACT VALUES
    private float hiddenX = -2.941f;
    private float visibleX = -2.790f;

    void Start()
    {
        // force shredded to start hidden
        Vector3 pos = transform.position;
        pos.x = hiddenX;
        transform.position = pos;
    }

    void Update()
    {
        float distance = Vector3.Distance(playerCamera.position, transform.position);

        if (distance < triggerDistance && !triggered)
        {
            triggered = true;

            if (shredSound != null)
                shredSound.Play();
        }

        if (triggered)
        {
            // 🔻 move normal painting DOWN
            shreddedPart.position += Vector3.down * shredSpeed * Time.deltaTime;

            // 👉 move shredded OUT (ONLY in X)
            Vector3 pos = transform.position;

            if (pos.x < visibleX)
            {
                pos.x += shredSpeed * Time.deltaTime;
                transform.position = pos;
            }
        }
    }
}