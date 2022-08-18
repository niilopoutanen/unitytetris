using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject[] objects;
    public int NextIndex;
    public void SpawnNext()
    {
        NextIndex = Random.Range(0, objects.Length);

        Instantiate(objects[NextIndex], transform.position, Quaternion.identity);
    }

    public int GetNext()
    {
        return NextIndex;
    }
    // Start is called before the first frame update
    void Start()
    {
        SpawnNext();
        NextIndex = Random.Range(0, objects.Length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
