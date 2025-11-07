using UnityEngine;
using TMPro;
using System.Collections;

public class TypewriterEffectTMP : MonoBehaviour
{
    [Header("Configuración")]
    public float typingSpeed = 0.05f;      
    public string fullText;               
    private TMP_Text textComponent;        

    private void Start()
    {
        textComponent = GetComponent<TMP_Text>();
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        textComponent.text = "";  
        foreach (char letter in fullText.ToCharArray())
        {
            textComponent.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
