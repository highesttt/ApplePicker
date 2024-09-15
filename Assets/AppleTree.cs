using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject applePrefab;
    public GameObject branchPrefab;

    public static float speed = 8f;

    public float leftAndRightEdge = 10f;

    public float changeDirChance = 0.1f;

    public static float appleDropDelay = 0.8f;
    // Start is called before the first frame update
    void Start() {
        Invoke("DropApple", 2f);
    }

    // Update is called once per frame
    void Update() {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -leftAndRightEdge) {
            speed = Mathf.Abs(speed);
        } else if (pos.x > leftAndRightEdge) {
            speed = -Mathf.Abs(speed); 
        }
        
    }

    void FixedUpdate() {
        if (Random.value < changeDirChance) {
            speed *= -1;
        }
    }

    void DropApple() {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;

        if (Random.value < 0.1f) {
            Invoke("DropBranch", appleDropDelay);
        } else {
            Invoke("DropApple", appleDropDelay);
        }
    }

    void DropBranch() {
        GameObject branch = Instantiate<GameObject>(branchPrefab);
        branch.transform.position = transform.position;
        if (Random.value < 0.1f) {
            Invoke("DropBranch", appleDropDelay);
        } else {
            Invoke("DropApple", appleDropDelay);
        }
    }
}
