using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileMap : MonoBehaviour {


    public GameObject[] tiles;
    public int width = 10, height = 10, xOffset, yOffset;


	// Use this for initialization
	void Start () {
        for (int i = 0; i < height; i++)
        {
            for (int x = 0; x < width; x++)
            {
                Instantiate(tiles[Random.Range(0, tiles.Length)], new Vector3(x * xOffset, 0, i * yOffset), Quaternion.identity, this.transform);
            }
        }
        
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
