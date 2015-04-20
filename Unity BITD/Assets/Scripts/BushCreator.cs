using UnityEngine;
using System.Collections;

public class BushCreator : MonoBehaviour {
	public static GameObject Bush1;
	public static GameObject Bush2;
	public static GameObject bushObject;
	public GameObject[] Bushes = new GameObject[]{Bush1, Bush2};
	private float pos;
	// Use this for initialization
	void Start () {
	    float z = 9;
		pos = Random.Range(0.2f,0.8f);
        bushObject = Instantiate(Bushes[Random.Range(0, 2)], new Vector3(3 * pos, 4 * (Mathf.Sqrt(1 - pos * pos)), z += 0.01f), Quaternion.identity) as GameObject;
        pos = Random.Range(2f, 2.5f);
		bushObject.transform.localScale = new Vector3 (pos, pos, 1); 
		pos = Random.Range(0.2f,0.8f);
        bushObject = Instantiate(Bushes[Random.Range(0, 2)], new Vector3(4 * (-pos), 3 * (Mathf.Sqrt(1 - pos * pos)), z += 0.01f), Quaternion.identity) as GameObject;
        pos = Random.Range(2f, 2.5f);
		bushObject.transform.localScale = new Vector3 (pos, pos, 1);
		pos = Random.Range(0.2f,0.8f);
        bushObject = Instantiate(Bushes[Random.Range(0, 2)], new Vector3(5 * pos, 6 * (-(Mathf.Sqrt(1 - pos * pos))), z += 0.01f), Quaternion.identity) as GameObject;
        pos = Random.Range(2f, 2.5f);
		bushObject.transform.localScale = new Vector3 (pos, pos, 1);
		pos = Random.Range(0.2f,0.8f);
        bushObject = Instantiate(Bushes[Random.Range(0, 2)], new Vector3(6 * (-pos), 5 * (-(Mathf.Sqrt(1 - pos * pos))), z += 0.01f), Quaternion.identity) as GameObject;
        pos = Random.Range(2f, 2.5f);
        bushObject.transform.localScale = new Vector3(pos, pos, 1);
        pos = Random.Range(0.2f, 0.8f);
        bushObject = Instantiate(Bushes[Random.Range(0, 2)], new Vector3(Random.Range(3f, 5f) * ((Mathf.Sqrt(1 - pos * pos))), Random.Range(3.5f, 4f) * (-pos), z += 0.01f), Quaternion.identity) as GameObject;
        pos = Random.Range(2f, 2.5f);
        bushObject.transform.localScale = new Vector3(pos, pos, 1);
        pos = Random.Range(-0.1f, 0.1f);
        bushObject = Instantiate(Bushes[Random.Range(0, 2)], new Vector3(Random.Range(3f, 5f) * (-(Mathf.Sqrt(1 - pos * pos))), Random.Range(3.5f, 4f) * (-pos), z += 0.01f), Quaternion.identity) as GameObject;
        pos = Random.Range(2f, 2.5f);
        bushObject.transform.localScale = new Vector3(pos, pos, 1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
