using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterPainting : MonoBehaviour
{
    public string sceneToLoad = "StarryNight";
    public float interactDistance = 100f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Clicked mouse");

            if (Camera.main == null)
            {
                Debug.LogError("Camera.main is NULL. Tag your camera as MainCamera.");
                return;
            }

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactDistance))
            {
                Debug.Log("Ray hit: " + hit.collider.gameObject.name);

                if (hit.collider.gameObject == gameObject)
                {
                    Debug.Log("Painting clicked. Loading scene: " + sceneToLoad);
                    SceneManager.LoadScene(sceneToLoad);
                }
                else
                {
                    Debug.Log("Hit something else, not this painting.");
                }
            }
            else
            {
                Debug.Log("Raycast hit nothing.");
            }
        }
    }
}