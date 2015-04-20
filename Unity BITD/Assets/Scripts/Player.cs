using System;
using UnityEngine;

public class Player : MonoBehaviour {
    public GameObject bump;
    public GameObject player;
    private Vector3 mousePosition;
    // Use this for initialization
    private void Start() {
        //начальное направление игрока - ось OX!	
    }

    // Update is called once per frame
    private void Update() {
        //движение игрока за мышкой
        if (!LevelManager.isGameOver) {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (mousePosition.x >= Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2f, 0, 0)).x) transform.localScale = new Vector3(-Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            if (mousePosition.x < Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2f,0,0)).x) transform.localScale = new Vector3(Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            //float angle = Vector2.Angle(Vector2.right, mousePosition - transform.position);
            //transform.eulerAngles = new Vector3(0f, 0f, transform.position.y < mousePosition.y ? angle : -angle);

            //создание шишки по нажатию на левую кнопку мыши


            if (Input.GetMouseButtonDown(0)) {
                gameObject.GetComponent<Animator>().Play("PlayerThrow");
                Invoke("InstBump", 0.5f);

            }
        }
    }

    void InstBump() {
        var cloneBump = (GameObject)Instantiate(bump, transform.position + transform.up, transform.rotation);
        Vector3 bumpDir = mousePosition - player.transform.position;
        cloneBump.transform.rotation = Quaternion.LookRotation(Vector3.forward, bumpDir);
        cloneBump.rigidbody2D.AddRelativeForce(new Vector2(0f, 500f));
    }
}