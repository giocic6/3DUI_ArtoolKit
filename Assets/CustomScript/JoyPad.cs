using UnityEngine;
using System.Collections;

public class JoyPad : MonoBehaviour {

   
    bool touched;
    Camera cam;
    SceneMgr mgr;
    Canvas canvas;
    Vector3 pixpos, pixposAct;
    public int radius= 50;
    public int trasfSpeed = 150;
    Vector3 direction;

    void Start()
    {
        cam = FindObjectOfType<Camera>();
        canvas = FindObjectOfType<Canvas>();
        pixposAct.z = canvas.planeDistance;
        mgr = FindObjectOfType<SceneMgr>();
        direction = new Vector3(0,0,0);
    }

    void Update()
    {

    }

    void OnMouseDown()
    {
        // Debug.Log(transform.localPosition);
        pixpos = cam.WorldToScreenPoint(transform.position);
       //pixpos.x = 100*pixpos.x / cam.pixelHeight;
       //pixpos.y = 100*pixpos.y / cam.pixelWidth;
       //Debug.Log(pixpos);

    }
    void OnMouseDrag ()
    {
        Vector3 t = Vector3.zero; 
       if (Input.touchCount != 0)
        {
            t = Input.GetTouch(0).position;
        }
       if(Input.GetMouseButton(0))
        {
            t = Input.mousePosition;
        }

        t.z = canvas.planeDistance;

        //Debug.Log("MousePos: " + t + "// PixPos: " + pixpos);
        //Debug.Log("Distance: " + Vector3.Distance(pixpos, t));

        if ( Vector3.Distance(pixpos, t) < radius)
        {
            pixposAct.x = (t.x) ;
            pixposAct.y = (t.y) ;
            this.transform.position = cam.ScreenToWorldPoint(pixposAct);
        }
        direction.x = this.transform.localPosition.x;
        direction.z = this.transform.localPosition.y;
        mgr.translate(direction * Time.deltaTime * trasfSpeed, true);
    }

    void OnMouseUp()
    {
        this.transform.localPosition = Vector3.zero;
        //Debug.Log("Mouse UP: " + transform.localPosition);
    }
}
