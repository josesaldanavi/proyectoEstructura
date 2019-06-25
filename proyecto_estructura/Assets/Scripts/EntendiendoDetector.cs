using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;

public class EntendiendoDetector : MonoBehaviour, ITrackableEventHandler
{

    public Canvas pantallaSecundaria;
    public Canvas pantallaPuntaje;
    public Text cambio;
    protected TrackableBehaviour mTrackableBehaviour;
    protected TrackableBehaviour.Status m_PreviousStatus;
    protected TrackableBehaviour.Status m_NewStatus;
    public Botones controlpantalla;
    // Start is called before the first frame update
    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
    }
    public void OnTrackableStateChanged(
    TrackableBehaviour.Status previousStatus,
    TrackableBehaviour.Status newStatus)
    {
        m_PreviousStatus = previousStatus;
        m_NewStatus = newStatus;

            //cuando detecta un target
            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            {
                print("detecto target");
                pantallaSecundaria.enabled = false;
                pantallaPuntaje.enabled = true;
            }
            //cuando pierde el target
            else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                     newStatus == TrackableBehaviour.Status.NO_POSE)
            {
                print("perdio el target");
                pantallaSecundaria.enabled = true;
                pantallaPuntaje.enabled = false;
                cambio.text = "¡No se logra detectar el target!";
            }
            //cuando comienza el programa
            else
            {
                // For combo of previousStatus=UNKNOWN + newStatus=UNKNOWN|NOT_FOUND
                // Vuforia is starting, but tracking has not been lost or found yet
                // Call OnTrackingLost() to hide the augmentations
                print("comenzo el programa");
                pantallaSecundaria.enabled = true;
            pantallaPuntaje.enabled = false;
            cambio.text = "¡Detecta el target!";
            }
        }

}
