using UnityEngine;
using System.Collections;

public class SwipedPart : MonoBehaviour {
	
	private MeshRenderer parentRenderer;
	private bool is_exploded;

	// Use this for initialization
	void Start () {
		parentRenderer = transform.parent.GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!parentRenderer.enabled && !is_exploded){
			gameObject.AddComponent<Rigidbody>();
			if(transform.rigidbody){
				rigidbody.useGravity = true;
				rigidbody.AddForce(new Vector3(-1 * transform.localPosition.x * 300, 100, 0));
				is_exploded = true;
			}
		}
	}
}
