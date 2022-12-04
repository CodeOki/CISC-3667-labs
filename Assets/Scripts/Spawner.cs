using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    [SerializeField] GameObject Zaku;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        int xMin = -10;
        int xMax = 16;
        int yMin = -2;
        int yMax = 2;

            Vector2 position = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
            Instantiate(Zaku, position, Quaternion.identity);
        
    }
}