using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VR.WSA;
using UnityEngine.VR.WSA.Input;
using System.Linq;

public class Managers : MonoBehaviour {
    private Text text;
    public Camera cameraH;
    public GameObject cursor;

    private float angle;


    private GestureRecognizer gestureRecongnizer;
	// Use this for initialization
	void Start () {
       
        text = transform.FindChild("Text").GetComponent <Text>();
        gestureRecongnizer = new GestureRecognizer();
        gestureRecongnizer.TappedEvent += GestureRecognizerOnTappedEvent;
        gestureRecongnizer.SetRecognizableGestures(GestureSettings.Tap);
        gestureRecongnizer.StartCapturingGestures();
    }
    private void GestureRecognizerOnTappedEvent(InteractionSourceKind source,int tapCount,Ray headRay) {
        Shoot();
        throw new NotImplementedException();
    }
	// Update is called once per frame
	void Update () {
        if (cursor == null) return;
        var raycastHits = Physics.RaycastAll(transform.position, transform.forward);
        var firstHit = raycastHits.OrderBy(r => r.distance).FirstOrDefault();


        cursor.transform.position = firstHit.point;
        cursor.transform.forward = firstHit.normal;

        text.text = angle.ToString();
        


    }

    //public void OnButtonClick() {

    //   // text .text = UnityEngine.Random.Range(0, 20).ToString ();
    //}
    void Shoot() {
        //   OnButtonClick();

        angle = UnityEngine.Random.Range(0, 20);
    }


}
