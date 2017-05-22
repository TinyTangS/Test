using UnityEngine;
using UnityEngine.VR.WSA.Input;


/// <summary>
/// Simple test script for dropping cubes with physics to observe interactions
/// </summary>
public class CubeCreator : MonoBehaviour
{
    public GameObject cube;
    GestureRecognizer recognizer;

    private void Start()
    {
        recognizer = new GestureRecognizer();
        recognizer.SetRecognizableGestures(GestureSettings.Tap);
        recognizer.TappedEvent += Recognizer_TappedEvent;
        //recognizer.SetRecognizableGestures(GestureSettings.Hold);
        //recognizer.HoldStartedEvent += Recognizer_HoldStartedEvent ;
        //recognizer.HoldCanceledEvent += Recognizer_HoldCancledEvent;
        recognizer.StartCapturingGestures();

    }

    private void OnDestroy()
    {
        recognizer.TappedEvent -= Recognizer_TappedEvent;
        //recognizer.HoldStartedEvent -= Recognizer_HoldStartedEvent;
        //recognizer.HoldCanceledEvent -= Recognizer_HoldCancledEvent;
    }

    private void Recognizer_TappedEvent(InteractionSourceKind source, int tapCount, Ray headRay)
    {
        RaycastHit hit;
        if (Physics.Raycast(headRay, out hit))
        {
            if (hit.collider != null&&hit.collider.gameObject.tag != "Cube")
            {
                Instantiate(cube,hit.point , Quaternion.identity);
            }
        }
    }
    //private void Recognizer_HoldStartedEvent(InteractionSourceKind source, Ray headRay) {


    //}
    //private void Recognizer_HoldCancledEvent(InteractionSourceKind source, Ray headRay)
    //{


    //}


}
