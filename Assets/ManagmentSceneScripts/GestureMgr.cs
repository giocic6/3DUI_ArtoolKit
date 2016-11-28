using UnityEngine;
using System.Collections;

public enum RotateState { NO_ROT, ROT_X, ROT_Y, ROT_Z };

public class GestureMgr : MonoBehaviour {

    private RotateState rs = RotateState.ROT_Z;
    private bool allowScaling;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void allowScale ( bool allow)
    {
        allowScaling = allow;
    }

    public void changeRotState(int rs)
    {
        switch (rs)
        {
            case 0:
                this.rs = RotateState.NO_ROT;
                break;
            case 1:
                this.rs = RotateState.ROT_X;
                break;
            case 2:
                this.rs = RotateState.ROT_Y;
                break;
            case 3:
                this.rs = RotateState.ROT_Z;
                break;

        }
    }

}
