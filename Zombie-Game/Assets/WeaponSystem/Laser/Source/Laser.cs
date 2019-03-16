using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LineRenderer))]
public class Laser : MonoBehaviour {

	LineRenderer line;
	public Transform laserdot;
	public float range = 100;
	public float laserSpeed=0.5f;
	public LayerMask layer;

	Material lineM;

	void Awake () {
		line = GetComponent<LineRenderer>();
		lineM = line.material;
		line.useWorldSpace = true;
	}

	void OnEnable() {
		line.SetPosition(0, transform.position);
		line.SetPosition(1, transform.position);
		laserdot.position = transform.position;
	}
	
	void LateUpdate () {

		Ray ray = new Ray(transform.position, transform.forward);
			line.SetPosition(0, transform.position);

		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, range, layer)) {
			line.SetPosition(1, hit.point);
			laserdot.gameObject.SetActive (true);
			laserdot.position = hit.point-(transform.forward*0.01f);
			laserdot.rotation = Quaternion.LookRotation (hit.normal, transform.up);
		} else {
			line.SetPosition(1, ray.GetPoint(range));
			laserdot.gameObject.SetActive (false);
		}
			
		float offset = lineM.mainTextureOffset.x -Time.deltaTime * laserSpeed;
		lineM.mainTextureOffset = new Vector2(offset, 0);	
	}
}
