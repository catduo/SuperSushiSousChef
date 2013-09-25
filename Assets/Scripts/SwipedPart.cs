using UnityEngine;
using System.Collections;

public class SwipedPart : MonoBehaviour {
	
	private MeshRenderer parentRenderer;
	private bool is_exploded;
	private float magnitude = 0;

	// Use this for initialization
	void Start () {
		parentRenderer = transform.parent.GetComponent<MeshRenderer>();
		if(transform.name[transform.name.Length - 1] == '1'){
			magnitude = 1;
		}
		renderer.material.mainTextureOffset = new Vector2(0.5F - magnitude / 2F, 0F);
	}
	
	// Update is called once per frame
	void Update () {
		if(!parentRenderer.enabled && !is_exploded){
			renderer.enabled = true;
			rigidbody.isKinematic = false;
			rigidbody.useGravity = true;
			float rotation = transform.parent.rotation.z + 180 * magnitude;
			rigidbody.velocity = new Vector3(Mathf.Cos (rotation) * 10, Mathf.Sin (rotation) * 10, 0);
			rigidbody.AddTorque(new Vector3(0,0, Random.value *500 - 250));
			is_exploded = true;
		}
	}
}
