using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TXT_GameOVer : MonoBehaviour
{
    public GameObject lerpPos;

    private Text m_Text;

    void Start()
    {
        m_Text = GetComponent<Text>();

    }
    
    void OnEnable()
    {
        if(m_Text == null)
        {
            m_Text = GetComponent<Text>();
        }
    }

    public void MoveToPos()
    {
        StartCoroutine(cr_LerpPos());
        StartCoroutine(cr_SizeLerp());
    }

    IEnumerator cr_LerpPos()
    {
        while (Vector3.Distance(transform.position,lerpPos.transform.position) > 2)
        {
            Vector3 dir = lerpPos.transform.position - transform.position;
            transform.position += dir.normalized * 4;

            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator cr_SizeLerp()
    {

        while(m_Text.fontSize <= 80)
        {
            m_Text.fontSize += 1;
            yield return new WaitForSeconds(0.01f);
        }

    }



}
