using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizDB : MonoBehaviour
{
    //esto es para guardar las preguntas del quiz en esta parte y va agarrar solo a los que tengan
    // su script de peguntasQuiz
    [SerializeField] private List<PreguntasQuiz> m_questionList = null;

    public static bool seAcabo=false;
    //esto sirve para que se pueda reiniciar la base de datos
    private List<PreguntasQuiz> m_backup = null;


    private void Awake()
    {
        m_backup = m_questionList.ToList();
    }


    //pregunta al azar y que no se repita la pregunta
    public PreguntasQuiz GetRandom(bool remove = true)
    {

        if (m_questionList.Count == 0)
        {
            //RestorBackup();
            seAcabo = true;
        }

        int index = Random.Range(0, m_questionList.Count);

        if (!remove)
        {
            return m_questionList[index];
        }
        PreguntasQuiz q = m_questionList[index];
        //este es para remover las preguntas 
        m_questionList.RemoveAt(index);

        return q;
    }

    //para reiniciar preguntas
    private void RestorBackup()
    {
        m_questionList = m_backup.ToList();
    }
}
