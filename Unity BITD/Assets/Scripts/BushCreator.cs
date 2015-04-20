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
		pos = Random.Range(0.2f,0.8f);
		bushObject = Instantiate (Bushes [Random.Range (0, 2)], new Vector3 (4.5f * pos, 4.5f * (Mathf.Sqrt (1 - pos * pos)), 9), Quaternion.identity) as GameObject;
		pos = Random.Range (1f, 2f);
		bushObject.transform.localScale = new Vector3 (pos, pos, 1); 
		pos = Random.Range(0.2f,0.8f);
		bushObject = Instantiate(Bushes[Random.Range(0,2)], new Vector3(4.5f*(-pos), 4.5f*(Mathf.Sqrt(1-pos*pos)), 9), Quaternion.identity) as GameObject;
		pos = Random.Range (1f, 2f);
		bushObject.transform.localScale = new Vector3 (pos, pos, 1);
		pos = Random.Range(0.2f,0.8f);
		bushObject = Instantiate(Bushes[Random.Range(0,2)], new Vector3(4.5f*pos, 4.5f*(-(Mathf.Sqrt(1-pos*pos))), 9), Quaternion.identity) as GameObject;
		pos = Random.Range (1f, 2f);
		bushObject.transform.localScale = new Vector3 (pos, pos, 1);
		pos = Random.Range(0.2f,0.8f);
		bushObject = Instantiate(Bushes[Random.Range(0,2)], new Vector3(4.5f*(-pos), 4.5f*(-(Mathf.Sqrt(1-pos*pos))), 9), Quaternion.identity) as GameObject;
		pos = Random.Range (1f, 2f);
		bushObject.transform.localScale = new Vector3 (pos, pos, 1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
