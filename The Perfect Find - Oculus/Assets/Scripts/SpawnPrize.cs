using UnityEngine;
using System.Collections;

public class SpawnPrize : MonoBehaviour
{

    public GameObject prize;                // The block prefab to be spawned.
    public GameObject preview;
    public float maxTime = 2.5f;

    public float R;
    public float G; 
    public float B;

    public float max_x = 5.0f;
    public float max_z = 5.0f;
    public float min_x = 5.0f;
    public float min_z = 5.0f;

    void Start()
    {
        R = Random.Range(0.0f, 1.0f);
        G = Random.Range(0.0f, 1.0f);
        B = Random.Range(0.0f, 1.0f);
        Color randomColor = new Color(R, G, B, 1);
        MeshRenderer gameObjectRenderer = prize.GetComponent<MeshRenderer>();
        MeshRenderer gameObjectRendererPreview = preview.GetComponent<MeshRenderer>();
        Material newMaterial = new Material(Shader.Find("Diffuse"));

        newMaterial.color = randomColor;
        gameObjectRenderer.material = newMaterial;
        gameObjectRendererPreview.material = newMaterial;

        // Create preview
        CreatePreview();

        StartCoroutine(Spawn());
    }


    IEnumerator Spawn()
    {
        float spawnTime = Random.Range(0.0f, maxTime);
        yield return new WaitForSeconds(spawnTime);

        

        // Special case for level 4, where prize could spawn on multiple floors
        if (Application.loadedLevelName.Equals("Level 4"))
        {
            int floor = Random.Range(1, 5);
            Vector3 position = new Vector3(Random.Range(-min_x, max_x), 10 + (10 * (floor-1)), Random.Range(-min_z, max_z));

            Instantiate(prize, position, Random.rotation);
        } else {
            Vector3 position = new Vector3(Random.Range(-min_x, max_x), 10, Random.Range(-min_z, max_z));

            // Create an instance of the prize prefab at a random point with random rotation
            Instantiate(prize, position, Random.rotation);
        }



    }

    void CreatePreview() {
        // Level must have podium positioned at 0,0,0
        Instantiate(preview, new Vector3(1f, 1.0f, 0f), Quaternion.identity);
        Instantiate(preview, new Vector3(0f, 1.0f, 1f), Quaternion.identity);
        Instantiate(preview, new Vector3(-1f, 1.0f, 0f), Quaternion.identity);
        Instantiate(preview, new Vector3(0f, 1.0f, -1f), Quaternion.identity);
    }
}