using UnityEngine;
using System.Collections;

public class SceneMgr : MonoBehaviour {

	public GameObject selected;
    public GameObject group;
    public bool toMoveGroup;

    //VARIABILI VECCHIE, CONTROLLARE SE DA TENERE
    public bool allowSelect = true;
	public Vector3 newScale;
	public Material m1, m2;

    /*
     *  This function must:
     *   - set current object to the new one
     *   - find the group of the new object (if any)
     *   This function is called by pointerManager
     */
    public void selectObject(GameObject toSelect)
    {
        selected = toSelect;
    }

    public void deSelectObject()
    {
        selected = null;
        //call pointer manager to reset
        //call gesture manager to reset
        //call UI to reset
        //other stuffs   
    }


    public void scale(float value){

		newScale.x = value;
		newScale.y = value;
		newScale.z = value;

		if (value == 1) {
			selected.transform.localScale = newScale;
		} else {
			selected.transform.localScale += newScale;
		}

	}

    public void rotate(int axe, float value)
    {
        //some stuff to write
    }

    /*
     *  This function must allow to translate single obj or groups
     *      If toAdd= true then xyz is added to the current position
     *      Else xyz override current position
     */ 
    public void translate (Vector3 xyz, bool toAdd)
    {
        if (selected != null)
        {
            if (toAdd)
            {
                selected.transform.position += xyz;
            }
            else
            {
                selected.transform.position = xyz;
            }
        }
    }

    /*
     *  For groups managment
     */
    public void selectNext()
    {

    }

    /*
     *  For groups managment
     */
    public void selectAll()
    {

    }

}
