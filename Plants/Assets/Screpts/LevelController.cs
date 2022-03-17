using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winMenu;
    [SerializeField] GameObject looseMenu;
    [SerializeField] AudioClip looseSFX;

    [SerializeField]int atackersAlive = 0;
    // Start is called before the first frame update
    bool lastWave = false;
    private void Awake()
    {
        winMenu.SetActive(false);
        looseMenu.SetActive(false);
    }
    private void OnEnable()
    {
        SliderControler.onSliderEnded += LastWave;
    }
    private void OnDisable()
    {
        SliderControler.onSliderEnded -= LastWave;
    }
    void Start()
    {
        
    }
    private void Update()
    {
        if (lastWave && atackersAlive == 0)
        {
            Debug.Log("IZI");
            StartCoroutine(WinScreenShow());

        }
    }
    public void Loosed()
    {
        StartCoroutine(LooseScreenShow());
    }

    IEnumerator LooseScreenShow()
    {
        looseMenu.SetActive(true);
        AudioSource.PlayClipAtPoint(looseSFX, Camera.main.transform.position);
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0;
        StopCoroutine(LooseScreenShow());
        
    }
    
    IEnumerator WinScreenShow()
    {        
        winMenu.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2f);
        FindObjectOfType<LevelLoader>().LoadNextScene();
        StopCoroutine(WinScreenShow());
    }
    public void PlusAttacker()
    {
        atackersAlive++;
    }
    public void MinusAttacker()
    {
        atackersAlive--;
    }

    public void LastWave()
    {
        Debug.Log("Huita");
        var spawners = FindObjectsOfType<AttackerSpawner>();
        foreach(var sp in spawners)
        {
            sp.StopSpawn();
        }
        lastWave = true;
    }
}
