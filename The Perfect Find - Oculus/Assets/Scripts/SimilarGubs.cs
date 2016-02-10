using UnityEngine;
using System.Collections;

public class SimilarGubs : MonoBehaviour
{

    public GameObject block;                // The block prefab to be spawned.
    public float spawnTime = 0.05f;            // How long between each spawn.
    public int gubcount = 100;               // The number of gubs spawned for each level
    public float colorDifferenceMin = 0.0f;        // This is how different the gubs should be from the prize
    public float colorDifferenceMax = 0.0f;
    public int tracker = 0;
    public SpawnPrize prizeScript;
    public float max_x = 5.0f;
    public float max_z = 5.0f;
    public float min_x = 5.0f;
    public float min_z = 5.0f;

    private float red;
    private float green;
    private float blue;

    void Start()
    {

        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.     
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }


    void Spawn()
    {
        // Add some code to break from function
        if (tracker >= gubcount)
        {
            CancelInvoke();
            prizeScript = GetComponent<SpawnPrize>();
        }

        // Generate and apply a random color to the game objects

        if ((tracker % 2 == 0 || prizeScript.R - colorDifferenceMin < 0) && prizeScript.R + colorDifferenceMin < 1.0)
        {
            red = prizeScript.R + Random.Range(colorDifferenceMin, colorDifferenceMax);
        } else {
            red = prizeScript.R - Random.Range(colorDifferenceMin, colorDifferenceMax);
        }

        if ((tracker % 2 == 0 || prizeScript.G - colorDifferenceMin < 0) && prizeScript.R + colorDifferenceMin < 1.0)
        {
            green = prizeScript.G + Random.Range(colorDifferenceMin, colorDifferenceMax);
        }
        else
        {
            green = prizeScript.G - Random.Range(colorDifferenceMin, colorDifferenceMax);
        }

        if ((tracker % 2 == 0 || prizeScript.B - colorDifferenceMin < 0) && prizeScript.R + colorDifferenceMin < 1.0)
        {
            blue = prizeScript.B + Random.Range(colorDifferenceMin, colorDifferenceMax);
        }
        else
        {
            blue = prizeScript.B - Random.Range(colorDifferenceMin, colorDifferenceMax);
        }

        Color randomColor = new Color(red, green, blue, 1);
        MeshRenderer gameObjectRenderer = block.GetComponent<MeshRenderer>();

        Material newMaterial = new Material(Shader.Find("Diffuse"));

        newMaterial.color = randomColor;
        gameObjectRenderer.material = newMaterial;

        Vector3 position = new Vector3(Random.Range(-min_x, max_x), 10, Random.Range(-min_z, max_z));

        // Create an instance of the blocks prefab at a random point with random rotation
        Instantiate(block, position, Random.rotation);

        tracker++;
    }
}