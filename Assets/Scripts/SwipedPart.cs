using UnityEngine;
using System.Collections;

public class SwipedPart : MonoBehaviour {
	
	private Renderer parentRenderer;
	private bool is_exploded;
	private float magnitude = 0;

	// Use this for initialization
	void Start () {
		parentRenderer = transform.parent.renderer;
		if(transform.name[transform.name.Length - 1] == '1'){
			magnitude = 1;
		}
		renderer.material.mainTextureOffset = new Vector2(0.5F - magnitude / 2F, 0F);
	}
	
	// Update is called once per frame
	void Update () {
		if(!parentRenderer.enabled && !is_exploded){
			if(transform.position.x < -11){
				renderer.enabled = true;
				transform.Translate(new Vector3 (-0.2F + magnitude * 0.4F, 0, 0));
				transform.localEulerAngles += new Vector3(0 ,20 - magnitude * 40, 0);
				is_exploded = true;
			}
			else{
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
}
