using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{

    public ScoreCounter scoreCounter;
    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");

        scoreCounter = scoreGO.GetComponent<ScoreCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;

        mousePos2D.z = -Camera.main.transform.position.z;

        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Apple") {
            Destroy(collidedWith);
            scoreCounter.score += 1;
            HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);

            if (RoundText.round < 5) {
                if (scoreCounter.score % 10 == 0) {
                    RoundText.round += 1;
                    AppleTree.speed += 1.5f;
                    AppleTree.appleDropDelay -= 0.15f;
                }
            }
        } else if (collidedWith.tag == "Branch") {
            Destroy(collidedWith);
            scoreCounter.score -= 1;
            
            ApplePicker appleScript = Camera.main.GetComponent<ApplePicker>();
            appleScript.AppleMissed();
            
        }
    }
}
