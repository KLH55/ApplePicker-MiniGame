using UnityEngine;
using System.Collections;

public class AppleTree : MonoBehaviour
{
    // Prefab for instantiating apples
    public GameObject applePrefab;

    // Spped at which the AppleTree moves in meters/second
    public float speed = 1f;

    // Distance where AppleTree turns around
    public float leftAndRightEdge = 10f;

    // Chance that the AppleTree will change directions
    public float chanceToChangeDirections = 0.1f;

    // Rate at which Apples will be instantiated
    public float secondsBetweenAppleDrops = 1f;


    // Use this for initialization
    void Start()
    {
        // Dropping apples every second
        InvokeRepeating("DropApple", 2f, secondsBetweenAppleDrops);     // InvokeRepeating calls the DropApple function after a 2 sec. delay, then drop based on secondsBetweenAppleDrops variable.
    }

    void DropApple()
    {
        GameObject apple = Instantiate(applePrefab) as GameObject;      // Defines the DropApple function, which creates a new instance of the Apple prefab as a new GameObject
        
		// sets the position of the newly created apple to that of the apple tree
		apple.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Add a line of code here
		// Hint: you'll need to get the tree's position vector and update it
		

        // Changing Direction -- no need to change this code
		if (transform.position.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); // Positive value moves right
        }
		else if (transform.position.x  > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); // Negative value moves left
        }
    }

	// the following code is put here instead of in update in order to 
	// change direction at a more constant rate
    void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirections)
        {       // Random.value returns a random numb. between 0 and 1.
            speed *= -1;  // Change directions if random.value is less than chanceToChangeDirection
        }
    }
}