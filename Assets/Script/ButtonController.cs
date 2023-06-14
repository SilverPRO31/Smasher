using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Net.Http;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine.SocialPlatforms;

public class ButtonController : MonoBehaviour
{
    private OpenLevel ol;
    public Text timeText;
    public Text rankScore;
    public Text nameScore;
    public Text timeScore;
    public Text scoreScore;
    private ViewLeaderBoard vlb;
    public Text scoreFinalText;
    public static int scoreFinal;
    private int time;
    public Add a;

    void Start()
    {
        ol = GetComponent<OpenLevel>();
        vlb = GetComponent<ViewLeaderBoard>();
    }

    private void Update()
    {
        
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void SwitchScene(int sceneid)
    {
        SceneManager.LoadScene(sceneid);
        Time.timeScale = 1f;
    }

    public void UrlOpen(string url)
    {
        Application.OpenURL(url);
    }

    public void StopTime()
    {
        Time.timeScale = 0f;
    }

    public void StartTime()
    {
        Time.timeScale = 1f;
    }

    public void Level()
    {
        StartCoroutine(ol.LoadData());
    }

    public async void TimeStart()
    {
        DB.timeStart = await GetTime();
    }

    public async void TimeEnd()
    {
        if (PlayerController.trig == 2)
        {
            DB.timeEnd = await GetTime();
            timeText.text = DB.timeEnd.Subtract(DB.timeStart).ToString().Substring(0, 8);
            WriteLeaderScore.timeText = DB.timeEnd.Subtract(DB.timeStart).ToString().Substring(0, 8);
            time = Convert.ToInt32(DB.timeEnd.Subtract(DB.timeStart).ToString().Substring(0, 8).Replace(":", ""));
            scoreFinal = PlayerController.startScore -( (time/100*60) + time%100)*5 + PlayerController.score;
            scoreFinalText.text = scoreFinal.ToString();
            WriteLeaderScore.time = Convert.ToInt32(DB.timeEnd.Subtract(DB.timeStart).ToString().Substring(0, 8).Replace(":", ""));
            PlayerController.trig = 0;
        }
    }

    private async Task<DateTime> GetTime()
    {
        HttpClient client = new HttpClient();
        string url = "http://worldtimeapi.org/api/timezone/Europe/Moscow";
        string response = await client.GetStringAsync(url);

        JSon json = JsonUtility.FromJson<JSon>(response);
        DateTime time = Convert.ToDateTime(json.datetime);
        return time;
    }

    public void ClearLeaderBoard()
    {
        rankScore.text = "";
        nameScore.text = "";
        timeScore.text = "";
        scoreScore.text = "";
    }

    public void InferenceLeaderBoard1Lvl()
    {
        StartCoroutine(vlb.LeaderBoard("1 уровень"));
    }

    public void InferenceLeaderBoard2Lvl()
    {
        StartCoroutine(vlb.LeaderBoard("2 уровень"));
    }

    public void InferenceLeaderBoard3Lvl()
    {
        StartCoroutine(vlb.LeaderBoard("3 уровень"));
    }

    public void StartAdd()
    {
        a.ShowAd();
    }
}
[System.Serializable]
public class JSon
{
    public string abbreviation;
    public string client_ip;
    public string datetime;
    public string day_of_week;
    public string day_of_year;
    public string dst;
    public string dst_from;
    public string dst_offset;
    public string dst_until;
    public string raw_offset;
    public string timezone;
    public string unixtime;
    public string utc_datetime;
    public string utc_offset;
    public string week_number;
}