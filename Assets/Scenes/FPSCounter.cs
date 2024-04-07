using TMPro;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    public static FPSCounter Instance;
    public float timer, refresh, avgFramerate;
    string display = "{0} FPS";
    [SerializeField] private TMP_Text m_Text;
    [SerializeField] private TMP_Text txtOnlineOffline;
    private float waitTime = .2f;
    float currentTime = -1;
    private bool _isConnectTcp = true;

    private void Start()
    {
        Application.targetFrameRate = 60;

        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
        
    }
    
    private void Update()
    {
        //Change smoothDeltaTime to deltaTime or fixedDeltaTime to see the difference
        float timelapse = Time.smoothDeltaTime;
        timer = timer <= 0 ? refresh : timer -= timelapse;

        if (timer <= 0) avgFramerate = (int)(1f / timelapse);
        currentTime -= Time.deltaTime;
        if (currentTime < 0)
        {
            m_Text.text = string.Format(display, avgFramerate.ToString());
            currentTime = waitTime;
        }

    }
}
