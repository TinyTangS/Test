using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.VR.WSA.Input;
using HoloToolkit.Unity.SpatialMapping;
using HoloToolkit.Unity;

public class Controller : MonoBehaviour
{


    public static Controller instance;
    public GameObject cube;
    private MapCube gp;
    [HideInInspector]
    public GameObject selectedCube;

    private CubeBehaviour[] hadselected;
    private int index;
    private GestureRecognizer gestureRecongnizer;
    private Vector3 normalPos;
    
    // Use this for initialization
    void Start()
    {
        instance = this;
        gestureRecongnizer = new GestureRecognizer();
        gestureRecongnizer.SetRecognizableGestures(GestureSettings.Tap);
        gestureRecongnizer.TappedEvent += GestureRecognizerOnTappedEvent;
        gestureRecongnizer.StartCapturingGestures();
        hadselected = new CubeBehaviour[2];
    }
    private void GestureRecognizerOnTappedEvent(InteractionSourceKind source, int tapCount, Ray headRay)
    {

        RaycastHit hitInfo;
        if (Physics.Raycast(headRay, out hitInfo))
        {
            Vector3 pos = hitInfo.point;
            if (hitInfo.collider != null && hitInfo.collider.tag != "Model" && hitInfo.collider.tag != "UI" && hitInfo.collider.tag != "Cube")
            {

                GameObject go = GameObject.Instantiate(cube, pos, Quaternion.identity);
                normalPos = go.transform.GetChild(0).transform.position;
            }

            if (hitInfo.collider.gameObject.tag == "Model")
            {
                index++;
                if (index > 2)
                {
                    index = 1;
                }
                selectedCube = hitInfo.collider.gameObject;
                selectedCube.SendMessage("ChangeMaterial", true);
                hadselected[index - 1] = selectedCube.GetComponent<CubeBehaviour>();

                if (hadselected[1] == null)
                {
                    hadselected[index - 1].gameObject.SendMessage("ChangeMaterial", true);

                }
                else if (hadselected[0] != hadselected[1] && hadselected != null)
                {
                    hadselected[index - 1].gameObject.SendMessage("ChangeMaterial", true);
                    if (index == 1)
                    {
                        hadselected[1].gameObject.SendMessage("ChangeMaterial", false);

                    }
                    if (index == 2)
                    {
                        hadselected[0].gameObject.SendMessage("ChangeMaterial", false);
                    }
                }
                else if (hadselected[0] == hadselected[1])
                {
                    hadselected[index - 1].isSelected = true;
                }
            }
        }
    }
   
    private void OnDestroy()
    {
        gestureRecongnizer.TappedEvent -= GestureRecognizerOnTappedEvent;

    }
   
}
