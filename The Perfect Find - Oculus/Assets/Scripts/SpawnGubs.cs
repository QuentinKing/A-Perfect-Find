using UnityEngine;
using System.Collections;

public class SpawnGubs : MonoBehaviour
{

    public GameObject block;                // The block prefab to be spawned.
    public float spawnTime = 0.05f;            // How long between each spawn.
    public int gubcount = 100;               // The number of gubs spawned for each level
    public float colorDifference = 0.0f;        // This is how different the gubs should be from the prize
    public int tracker = 0;
    public SpawnPrize prizeScript;
    public float max_x = 5.0f;
    public float max_z = 5.0f;
    public float min_x = 5.0f;
    public float min_z = 5.0f;

    void Start()
    {
        // This is just a precaution to make sure the game doesnt crash
        if (colorDifference >= 1 || colorDifference < 0) {
            colorDifference = 0;
        }

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

        float red = Random.Range(0.0f, 1.0f);
        float green = Random.Range(0.0f, 1.0f);
        float blue = Random.Range(0.0f, 1.0f);

        while (System.Math.Abs(red - prizeScript.R) < colorDifference) {
            red = Random.Range(0.0f, 1.0f);
        }
        while (System.Math.Abs(green - prizeScript.G) < colorDifference){
            green = Random.Range(0.0f, 1.0f);
        }
        while (System.Math.Abs(blue - prizeScript.B) < colorDifference){
            blue = Random.Range(0.0f, 1.0f);
        }

        Color randomColor = new Color(red, green, blue, 1);
        MeshRenderer gameObjectRenderer = block.GetComponent<MeshRenderer>();

        Material newMaterial = new Material(Shader.Find("Diffuse"));

        newMaterial.color = randomColor;
        gameObjectRenderer.material = newMaterial;

        // Special case for level 4 where gubs should spawn on four levels
        if (Application.loadedLevelName.Equals("Level 4")) {
            int floor = Random.Range(1, 5);
            Vector3 position = new Vector3(Random.Range(-min_x, max_x), 10 + (10 * (floor-1)), Random.Range(-min_z, max_z));

            // Create an instance of the blocks prefab at a random point with random rotation
            Instantiate(block, position, Random.rotation);

            tracker++;
        } else {
            Vector3 position = new Vector3(Random.Range(-min_x, max_x), 10, Random.Range(-min_z, max_z));

            // Create an instance of the blocks prefab at a random point with random rotation
            Instantiate(block, position, Random.rotation);

            tracker++;
        }
    }
}