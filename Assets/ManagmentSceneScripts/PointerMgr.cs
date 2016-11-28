using UnityEngine;
using System.Collections;

public enum MovementState { MOVEXY, MOVEZ, NO_MOVE};

public class PointerManager : MonoBehaviour {

    public GameObject cursor;

    private MovementState ms = MovementState.NO_MOVE;
    private bool selectable;
    private Vector3 fixedPointer;
    private GameObject focused;
    private Camera cam;
    private float time;


	// Use this for initialization
	void Start () {
        selectable = true;
        cam = FindObjectOfType<Camera>();
        fixedPointer = new Vector3(0.5f*cam.pixelWidth, 0.5f*cam.pixelHeight, cam.nearClipPlane);
    }
	


	// Update is called once per frame
	void Update () {
        if(cursor == null)
        {
            cursor = GameObject.FindGameObjectWithTag("Player");
        }
        switch (ms)
        {
            case MovementState.NO_MOVE:
                //here pointer on collision with all object
                RaycastHit hit;
                Ray ray = cam.ScreenPointToRay(fixedPointer);
                Physics.Raycast(ray, out hit);

                if (hit.collider != null)
                {
                    Debug.DrawRay(ray.origin, ray.direction, Color.yellow);
                    //Debug.Log(hit.point);
                    cursor.transform.position = hit.point;
                }
                if (selectable && hit.collider != null){
                    //if on a obj for 1 sec, take that as selected
                    if (hit.collider.gameObject.GetComponent<Selectable>() != null)
                    {
                        if(hit.collider.gameObject.Equals(focused))
                        {
                            time += Time.deltaTime;
                            if(time >= 1)
                            {
                                //this object must be selected
                                focused.GetComponent<Selectable>().selectObj();
                                selectable = false;
                                time = 0;
                            }
                        }
                        else
                        {
                            focused = hit.collider.gameObject;
                        }
                    }
                }
                break;
            case MovementState.MOVEXY:
                //here pointer on collison with plane
                break;
            case MovementState.MOVEZ:
                //here pointer on collision with perpendicular plane
                break;
        }
    }


    public void changeMovState(int ms)
    {
        this.ms = (MovementState)ms;
    }

    public void deSelect()
    {
        focused.GetComponent<Selectable>().deSelectObj();
        selectable = true;
        focused = null;
    }

}
