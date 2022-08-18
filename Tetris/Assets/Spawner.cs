using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject[] objects;

    public void SpawnNext()
    {
        int rand = Random.Range(0, objects.Length);

        Instantiate(objects[rand], transform.position, Quaternion.identity);
    }
    // Start is called before the first frame update
    void Start()
    {
        SpawnNext();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
