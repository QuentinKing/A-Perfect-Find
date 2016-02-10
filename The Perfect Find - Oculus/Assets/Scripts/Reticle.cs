using UnityEngine;
using System.Collections;

public class Reticle : MonoBehaviour
{

    public Camera CameraFacing;
    private Vector3 originalScale;
    public float guessNum = 3.0f;
    public AudioClip sound;

    private string currentTime;
    // Use this for initialization
    void Start()
    {
        originalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {

        // Determine crosshair position
        RaycastHit hit;
        float distance;

        // Get distance of whatever the reticle hit
        if (Physics.Raycast(new Ray(CameraFacing.transform.position, CameraFacing.transform.rotation * Vector3.forward), out hit))
        {
            distance = hit.distance;
        }
        else
        {
            distance = CameraFacing.farClipPlane * 0.95f;
        }
        transform.position = CameraFacing.transform.position +
            CameraFacing.transform.rotation * Vector3.forward * distance;
        // Set in front of camera
        transform.LookAt(CameraFacing.transform.position);
        transform.Rotate(0.0f, 180.0f, 0.0f);
        // Prevents reticle from taking up entire screen when close to an object
        if (distance < 10.0f)
        {
            distance *= 1 + 5 * Mathf.Exp(-distance);
        }
        transform.localScale = originalScale * distance;

        // Check for guesses
        if (Input.GetMouseButtonDown(0) && guessNum > 0 && distance < 10.0f)
        {
            if (hit.collider.CompareTag("Finish"))
            {
                guessNum -= 1;
                AudioSource.PlayClipAtPoint(sound, new Vector3(0, 0, 0));
                Destroy(hit.collider.gameObject);
            }
            else if (hit.collider.CompareTag("Respawn"))
            {
                GameObject gd = GameObject.Find("GameData");
                GameData gdScript = gd.GetComponent<GameData>();

                // Determine level and mark it complete
                string sceneName = Application.loadedLevelName;
                if (sceneName.Equals("Level 1"))
                {
                    gdScript.L1check = true;
                }
                else if (sceneName.Equals("Level 2"))
                {
                    gdScript.L2check = true;
                }
                else if (sceneName.Equals("Level 3"))
                {
                    gdScript.L3check = true;
                }
                else if (sceneName.Equals("Level 4"))
                {
                    gdScript.L4check = true;
                }
                else if (sceneName.Equals("Level 5"))
                {
                    gdScript.L5check = true;
                }
                else if (sceneName.Equals("Level 6"))
                {
                    gdScript.L6check = true;
                }
                else if (sceneName.Equals("Level 7"))
                {
                    gdScript.L7check = true;
                }
                else if (sceneName.Equals("Level 8"))
                {
                    gdScript.L8check = true;
                }
                else if (sceneName.Equals("Level 9"))
                {
                    gdScript.L9check = true;
                }
                else if (sceneName.Equals("Level 10"))
                {
                    gdScript.L10check = true;
                }

                // Return to main menu
                Application.LoadLevel("Level Select");
            }
        }
    }
}
