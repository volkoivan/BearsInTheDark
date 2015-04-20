using System;
using UnityEngine;

public class Player : MonoBehaviour {
    public GameObject bump;
    public GameObject bumpSound;
    public GameObject player;
    private Vector3 mousePosition;
    private Vector3 mousePositionForBump;
    private bool isFacingRight = true;
    private bool isFacingRightForBump = true;
    private bool isRightRotatingAnimationShown = false;
    private bool isLeftRotatingAnimationShown = false;

    // Use this for initialization
    private void Start() {
        //начальное направление игрока - ось OX!	
    }

    // Update is called once per frame
    private void Update() {
        //движение игрока за мышкой
        if (!LevelManager.isGameOver && LevelManager.isGameStarted) {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (mousePosition.x >= Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2f, 0, 0)).x) {
                isLeftRotatingAnimationShown = false;
                if (!isRightRotatingAnimationShown) GetComponent<Animator>().Play("PlayerRotating");
                isRightRotatingAnimationShown = true;
                Invoke("RotateSpriteRight", 0.05f);
                isFacingRight = true;
            }
            if (mousePosition.x < Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2f, 0, 0)).x) {
                isRightRotatingAnimationShown = false;
                if (!isLeftRotatingAnimationShown) GetComponent<Animator>().Play("PlayerRotating");
                isLeftRotatingAnimationShown = true;
                Invoke("RotateSpriteLeft", 0.05f);
                isFacingRight = false;
            }
            //float angle = Vector2.Angle(Vector2.right, mousePosition - transform.position);
            //transform.eulerAngles = new Vector3(0f, 0f, transform.position.y < mousePosition.y ? angle : -angle);

            //создание шишки по нажатию на левую кнопку мыши


            if (Input.GetMouseButtonDown(0)) {
                isFacingRightForBump = isFacingRight;
                mousePositionForBump = mousePosition;
                gameObject.GetComponent<Animator>().Play("PlayerThrow");
                Invoke("InstBump", 0.3f);
            }
        }
    }

    void InstBump()
    {
        var cloneSound = (GameObject)Instantiate(bumpSound);
        Destroy(cloneSound, 2f);
        var cloneBump = (GameObject)Instantiate(bump);
        if (isFacingRightForBump) cloneBump.transform.position = transform.position + transform.right / 2;
        else cloneBump.transform.position = transform.position - transform.right / 2;
        Vector3 bumpDir = mousePositionForBump - player.transform.position;
        cloneBump.transform.rotation = Quaternion.LookRotation(Vector3.forward, bumpDir);
        cloneBump.rigidbody2D.AddRelativeForce(new Vector2(0f, 400f));
        Destroy(cloneBump,5f);
    }

    private void RotateSpriteLeft() {
        transform.localScale = new Vector3(-Math.Abs(transform.localScale.x), transform.localScale.y,
            transform.localScale.z);

    }

    void RotateSpriteRight() {
        transform.localScale = new Vector3(Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }
}