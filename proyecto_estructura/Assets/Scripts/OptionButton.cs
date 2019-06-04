using System;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]
public class OptionButton : MonoBehaviour
{
    private Text m_text = null;
    private Button m_button = null;
    private Image m_image = null;
    private Color m_originalColor = Color.black;
    public OpcionesQuiz Opcion{get;set;}
    /*ESTE CONSTRUCTOR NOS AVISARA SI LA PREGUNTA ES CORRECTA
     EL CALLBACK ES UN METODO QUE SE LLAMARA CUANDO EL JUGADOR SELECCIONE LA OPCION 
     Y SE NOTIFICARA AL CREADOR DEL OBJETO LA OPCION DEL JUGADOR, DE ESTO SE BASARA SI LA OPCION 
     ES CORRECTA O INCORRECTA POR SONIDOS POR EFECTOS TODO SE DARA POR ESE CALLBACK*/

    private void Awake()
    {
        m_button = GetComponent<Button>();
        m_image = GetComponent<Image>();
        //asegurarse que tenga tipo texto el objeto donde se ponga el script
        m_text = transform.GetChild(0).GetComponent<Text>();
        m_originalColor = m_image.color;
    }
    public void Constructor(OpcionesQuiz opcion, Action<OptionButton> callback)
    {
        m_text.text = opcion.text;

        m_button.onClick.RemoveAllListeners();
        m_button.enabled = true;
        m_image.color = m_originalColor;

        Opcion = opcion;

        m_button.onClick.AddListener(delegate
        {
            callback(this);
        });
    }

    //para poner las opciones del color 
    public void SetColor(Color a)
    {
        m_button.enabled = false;
        m_image.color = a;
    }
}
