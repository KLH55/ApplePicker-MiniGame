using UnityEngine;
using System.Collections;

public class Apple : MonoBehaviour
{
    [Header("Set in Inspector")]
    public static float bottomY = -20f;             // Creates a new float var. that is STATIC, 
                                                    // meaning every instance of Apples on the screen will have the same value for bottomY
    // Use this for initialization
    void Start()
    {
		//nothing needed here
    }

    // Update is called once per frame
    void Update()
    {
		// this code helps us determine if the apple has fallen past the basket
        if (transform.position.y < bottomY)
        {   // If any instance of Apple is less than the value of bottomY,
            Destroy(this.gameObject); // destroy this instance of the Apple GameObject

            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
			// calls the AppleDestroyed method in order to note a "missed" apple
			// this means that one of the baskets will be removed (e.g. a life lost)
            apScript.AppleDestroyed();
        }
    }
}