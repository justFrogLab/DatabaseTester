﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
using System.Security.Cryptography; //  Hash 관리자 : Index 0
using System.Text.RegularExpressions;
using UnityEngine.Networking;
using UnityEngine.UI;
using System; // string.format

public class HighScore : MonoBehaviour
{
    private string secretKey = "UnityC";
    public string adddScoreURL = "http://175.125.32.152/HighScoreGame/addscore.php";
    public string highscoreURL = "http://175.125.32.152/HighScoreGame/display.php";
    public string deleteScoreURL  = "http://175.125.32.152/HighScoreGame/deletescore.php";

    public Text nameTextInput;
    public Text scoreTextInput;
    public Text nameResultText;
    public Text scoreResultText;
    //
    public Text deleteNameTextInput;

    public void GetScoreBtn()
    {
        nameResultText.text = "Player: \n \n";
        scoreResultText.text = "Score: \n \n";
        StartCoroutine(GetScores());
    }

    public void SendScoreBtn()
    {
        StartCoroutine(PostScores(nameTextInput.text,
             Convert.ToInt32(scoreTextInput.text)));

        nameTextInput.gameObject.transform.parent.GetComponent<InputField>().text = "";
        scoreTextInput.gameObject.transform.parent.GetComponent<InputField>().text = "";
    }

    public void DeleteScoreBtn()
    {
        StartCoroutine(DeleteScores(deleteNameTextInput.text));
        deleteNameTextInput.transform.parent.GetComponent<InputField>().text = "";
    }

    #region 스코어 가져오기
    IEnumerator GetScores()
    {
        UnityWebRequest hs_get = UnityWebRequest.Get(highscoreURL);
        yield return hs_get.SendWebRequest();

        if (hs_get.error != null)
            Debug.Log("There was an error posting the high score: " + hs_get.error);
        else
        {
            string dataText = hs_get.downloadHandler.text;
            MatchCollection mc = Regex.Matches(dataText, @"_");
            if (mc.Count > 0)
            {
                string[] splitData = Regex.Split(dataText, @"_");
                for (int i = 0; i < mc.Count; i++)
                {
                    if (i % 2 == 0)
                        nameResultText.text += splitData[i];
                    else
                        scoreResultText.text += splitData[i];
                }
            }
        }
    }
    #endregion


    #region
    IEnumerator PostScores(string name, int score)
    {
        string hash = HashInput(name + score + secretKey);
        string post_url = adddScoreURL + "?name=" +
            UnityWebRequest.EscapeURL(name) + "&score=" + score 
            + "&hash=" + hash;

        Debug.Log(post_url);


        UnityWebRequest hs_post = UnityWebRequest.Post(post_url , hash);

        yield return hs_post.SendWebRequest();

        if (hs_post.error != null)
            Debug.Log("There was an error posting the high score: " + hs_post.error);
    }
    #endregion

    
    IEnumerator DeleteScores(string name)
    {
        string hash = HashInput(name + secretKey);
        string post_url = deleteScoreURL + "?name=" +
            UnityWebRequest.EscapeURL(name) + "&hash=" + hash;

        Debug.Log(post_url);


        UnityWebRequest hs_post = UnityWebRequest.Post(post_url, hash);

        yield return hs_post.SendWebRequest();

        if (hs_post.error != null)
            Debug.Log("There was an error posting the high score: " + hs_post.error);
    }
    


    #region Hash 관리자 : Index 0
    public string HashInput(string input)
    {
        SHA256Managed hm = new SHA256Managed();
        byte[] hashValue =
            hm.ComputeHash(System.Text.Encoding.ASCII.GetBytes(input));
        string hash_convert =
            BitConverter.ToString(hashValue).Replace("-", "").ToLower();
        return hash_convert;
    }
    #endregion
}
