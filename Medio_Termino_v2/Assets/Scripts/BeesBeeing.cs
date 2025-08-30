using UnityEngine;
using TMPro;

public class BeesBeeing : MonoBehaviour
{
    [SerializeField] private TMP_Text beeCounter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        beeCounter.text = "Número de abejas: " + GameController.beesAlive;
    }
}
