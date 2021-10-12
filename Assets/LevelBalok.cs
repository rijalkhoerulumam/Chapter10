using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBalok : MonoBehaviour
{
    public int numberTospawn;
    public List<GameObject> spawnPool;
    public GameObject quad;
    [SerializeField] private float spawnDelay = 5f;
    private float boxSpawnDelay;

    private void Start()
    {
        spawnObjects(); 
    }

    private void Update()
    {  
        boxSpawnDelay -= Time.unscaledDeltaTime;
        if (boxSpawnDelay <= 0f)
        {
            boxSpawnDelay = spawnDelay;
        }
    }

    public void spawnObjects()
    {
        int randomItems = 0;
        GameObject toSpawn;
        MeshCollider c = quad.GetComponent<MeshCollider>();

        float screenX, screenY;
        Vector2 pos;
        for (int i = 0; i < numberTospawn; i++)
        {
            randomItems = Random.Range(0, spawnPool.Count);
            toSpawn = spawnPool[randomItems];
            screenX = Random.Range(c.bounds.min.x, c.bounds.max.x);
            screenY = Random.Range(c.bounds.min.y, c.bounds.max.y);
            pos = new Vector2(screenX, screenY);

            Instantiate(toSpawn, pos, toSpawn.transform.rotation);
        }
    }
    private void destroyedObjects()
    {
        foreach (GameObject o in GameObject.FindGameObjectsWithTag("Spawnable"))
        {
            Destroy(o);
        }
    }
}
