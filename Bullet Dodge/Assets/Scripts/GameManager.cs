
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI time;
    public TextMeshProUGUI gameOver;
    public TextMeshProUGUI bestRecord;

    private float surviveTime;
    private bool isGameOver;

    // Start is called before the first frame update
    private void Start()
    {
        bestRecord.gameObject.SetActive(false);
        surviveTime = 0;
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGameOver)
        {
            surviveTime += Time.deltaTime;
            time.text = $"Time: {surviveTime:N2}";
        }
        else
        {
            if(Input.GetKeyUp(KeyCode.R))
            {
                //¿ÁΩ√¿€
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.buildIndex);
            }
        }

    }

    public void EndGame()
    {
        isGameOver = true;
        gameOver.gameObject.SetActive(true);

        float bestSurviveTime = PlayerPrefs.GetFloat("BEST RECORD", 0f);

        if(bestSurviveTime < surviveTime)
        {
            bestSurviveTime = surviveTime;
            PlayerPrefs.SetFloat("BEST RECORD", bestSurviveTime);
        }

        bestRecord.text = $"Best Record: {bestSurviveTime:N2}";
        bestRecord.gameObject.SetActive(true);
    }
}
