using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplePicker : MonoBehaviour {

    [Header("Set in Inspector")]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList; // we use a collection here to hold the 3 basket objects

	// Use this for initialization
	void Start () {
        basketList = new List<GameObject>();

		// this code create the 3 basket game objects for us using the prefab
		// and adds each basket to the collection for easier management
		for(int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate(basketPrefab) as GameObject;
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
	}
	
	// Update is called once per frame
	void Update () {
		//nothing is needed here
	}

    public void AppleDestroyed()
    {
        // Destroy all of the falling apples
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tGO in tAppleArray)
        {
            Destroy(tGO);
        }

        // Destroy one of the baskets because an apple was missed
        int basketIndex = basketList.Count - 1;
        GameObject tBasketGO = basketList[basketIndex];
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGO);

        if (basketList.Count == 0)
        {
            // Code missing here
        }

    }
}
