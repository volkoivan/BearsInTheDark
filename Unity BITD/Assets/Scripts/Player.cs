using UnityEngine;

public class Player : MonoBehaviour {
    public GameObject bump;
    public GameObject player;
    // Use this for initialization
    private void Start() {
        //начальное направление игрока - ось OX!	
    }

    // Update is called once per frame
    private void Update() {
        //движение игрока за мышкой
        if (!LevelManager.isGameOver) {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float angle = Vector2.Angle(Vector2.right, mousePosition - transform.position);
            transform.eulerAngles = new Vector3(0f, 0f, transform.position.y < mousePosition.y ? angle : -angle);

            //создание стрелки по нажатию на левую кнопку мыши


            if (Input.GetMouseButtonDown(0)) {
                var cloneBump = (GameObject) Instantiate(bump);
                Vector3 bumpDir = mousePosition - player.transform.position;
                cloneBump.transform.rotation = Quaternion.LookRotation(Vector3.forward, bumpDir);
                cloneBump.rigidbody2D.AddRelativeForce(new Vector2(0f, 500f));
            }
        }
    }
}