using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GameManager : MonoBehaviour
{
    [SerializeField] private AudioClip m_CorrectSound = null;
    [SerializeField] private AudioClip m_incorretSound = null;
    [SerializeField] private Color m_correctColor = Color.black;
    [SerializeField]private Color m_incorrectColor = Color.black;
    [SerializeField] private float m_waitTime = 0.0f;
    // va a dictar el control del juego 
    public  QuizDB m_quizDB = null;
    public  QuizUI m_quizUI = null;
    private AudioSource m_audioSource = null;

    private void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
        //crea la interfaz grafica
        NextQuestion();
    }
    


    private void NextQuestion()
    {
        m_quizUI.Contructor(m_quizDB.GetRandom(), GiveAnswer);
    }

    private void GiveAnswer(OptionButton optionButton)
    {
        StartCoroutine(GiveAnswerRoutine(optionButton));
    }

    //corrutina
    private IEnumerator GiveAnswerRoutine(OptionButton optionbutton)
    {
        if (m_audioSource.isPlaying)
        {
            m_audioSource.Stop();
        }

        //operador ternario 
        m_audioSource.clip = optionbutton.Opcion.correct ? m_CorrectSound : m_incorretSound;
        optionbutton.SetColor(optionbutton.Opcion.correct ? m_correctColor : m_incorrectColor);

        m_audioSource.Play();

        yield return new WaitForSeconds(m_waitTime);

        NextQuestion();
    }
}
