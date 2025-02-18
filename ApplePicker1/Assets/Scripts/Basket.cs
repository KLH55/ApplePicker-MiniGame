using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Basket : MonoBehaviour
{
	// The following shows this  note in the inspector
    [Header("Set Dynamically")]
    public Text scoreGT;
	private static int score = 0;

    // Use this for initialization
    void Start()
    {
		// finds and retrieves the score text game object (not high score, but the player score)
        GameObject scoreGO = GameObject.Find("ScoreCounter");
		// retrieves the text component of the game object
        scoreGT = scoreGO.GetComponent<Text>();
		// update the score
        scoreGT.text = ""+score;
        score = 0;

    }

    // Update is called once per frame
    void Update()
    {
		// this moves the basket based on the user's mouse movement
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision coll)
    {
        // Add code here
        if (coll.gameObject.CompareTag("Apple"))
            score += 100;
            scoreGT.text = "" + score;
            Destroy(coll.gameObject);
		// Need to add 100 points to the score and display the score
        
		// if the player's current score is higher than the high score, the high score gets updated
        if (score > HighScore.score)
        {
            HighScore.score = score;
        }
    }
}
