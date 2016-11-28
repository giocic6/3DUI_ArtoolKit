using UnityEngine;
using System.Collections;

public class CustomPinch : MonoBehaviour {

	SceneMgr mgr;
	public int speed = 2;

	// Use this for initialization
	void Start () {
	
		mgr = FindObjectOfType<SceneMgr> ();

	}
	
	// Update is called once per frame
	void Update () {

		if (!mgr.allowSelect)
			pinchToScale ();
	
	}

	public void pinchToScale(){

		if(Input.touchCount == 2){

			Touch touch1 = Input.GetTouch (0);
			Touch touch2 = Input.GetTouch (1);

			Vector2 touch1PrevPos = touch1.position - touch1.deltaPosition;
			Vector2 touch2PrevPos = touch2.position - touch2.deltaPosition;

			float prevDeltaMag = (touch1PrevPos - touch2PrevPos).magnitude;
			float touchDeltaMag = (touch1.position - touch2.position).magnitude;

			float deltaMagnitudeDiff = (touchDeltaMag - prevDeltaMag)*Time.deltaTime*speed;

			if (mgr.selected.transform.localScale.x >= 1) {
				
				mgr.scale(deltaMagnitudeDiff);

			} else {

				mgr.scale(1f);

			}		

		}

	}
}
