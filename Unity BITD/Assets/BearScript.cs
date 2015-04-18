using UnityEngine;

public class BearScript : MonoBehaviour {
    private const float BearSpeed = 50f;
    // Use this for initialization
    private void Start() {
        InstantiateAtBorder();
        MoveToThePlayer();
    }

    // Update is called once per frame
    private void Update() {
    }

    private void InstantiateAtBorder() {
        float x, y;
        if (Random.Range(0, 2) == 1) {
            x = Random.Range(0, Screen.width);
            y = Random.Range(0, 2)*Screen.height;
        }
        else {
            x = Random.Range(0, 2)*Screen.width;
            y = Random.Range(0, Screen.height);
        }
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(x, y, transform.position.z));
    }


    private void MoveToThePlayer() {
        Vector3 targetDir = GameObject.FindGameObjectWithTag("Player").transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, targetDir);
        rigidbody2D.AddRelativeForce(new Vector2(0, BearSpeed));
    }


    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Player") {
            //Application.LoadLevel("Test");
        }
    }
}