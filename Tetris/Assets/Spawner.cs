using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Spawner : MonoBehaviour
{
    private int current;
    private int next = -1;
    public GameObject[] objects;
    public GameObject[] visualObjects;
    public GameObject pos;
    private GameObject todelete;
    public int Next { get => next; set => next = value; }
    public int Current { get => current; set => current = value; }

    //public void SpawnNext()
    //{
    //    int rand = Random.Range(0, objects.Length);

    //    Instantiate(objects[rand], transform.position, Quaternion.identity);
    //}

    public void SpawnNext()
    {
        try
        {
            Destroy(todelete);
        }
        catch (System.Exception)
        {

        }
        Random.InitState((int)System.DateTime.Now.Ticks);
        if (Next == -1)
        {
            Current = Random.Range(0, objects.Length);
            Next = Random.Range(0, objects.Length);

        }
        else if (Next != -1)
        {
            Current = Next;
            Next = Random.Range(0, objects.Length);
        }
        Instantiate(objects[Current], transform.position, Quaternion.identity);
        todelete = Instantiate(visualObjects[Next], pos.transform.position, Quaternion.identity);
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
