using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json.Linq;
using System.Linq;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    public GameObject scorePrefab;
    private int highScore;
    private string playerName;

    public class SearchResult
    {
        public string name { get; set; }
        public string score { get; set; }
        public string seconds { get; set; }
        public string text { get; set; }
        public string date { get; set; }
    }

    void Start()
    {
        highScore = PlayerPrefs.GetInt("highscore");
        playerName = PlayerPrefs.GetString("username");

        StartCoroutine(GetSetScores());
    }


    IEnumerator GetSetScores()
    {
        UnityWebRequest www = UnityWebRequest.Get(string.Format("http://dreamlo.com/lb/6JXzVytc8UqDuVxG0xdQ9A9cBVCoWzlUiPL34KgvbizA/add/{0}/{1}", playerName, highScore));
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        { Debug.Log(www.error); }

        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        www = UnityWebRequest.Get("http://dreamlo.com/lb/62d5640c8f40bb84ec7613ef/json");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Show results as text
            JObject o = JObject.Parse(www.downloadHandler.text);
            IList<JToken> results = o["dreamlo"]["leaderboard"]["entry"].Children().ToList();

            IList<SearchResult> searchResults = new List<SearchResult>();
            foreach (JToken result in results)
            {
                // JToken.ToObject is a helper method that uses JsonSerializer internally
                SearchResult searchResult = result.ToObject<SearchResult>();
                searchResults.Add(searchResult);
            }

            foreach (SearchResult result in searchResults)
            {
                var newScore = Instantiate(scorePrefab, Vector3.zero, Quaternion.identity);
                newScore.transform.SetParent(transform, false);
                newScore.GetComponent<Text>().text = result.name + ": " + result.score;
            }
        }
    }
}
