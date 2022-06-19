using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Security.Cryptography; // SHA256Managed
using System; // BitConverter
using UnityEngine.Networking; // UnityWebRequest
public class Quest_Add : EditorWindow
{
    private string secretKey = "UnityC";
    public string add_Quest_URL = "http://175.125.32.152/UnityDatabase/addQuest.php";

    [MenuItem("Custom/Quest/Add_Quest")]
    static void Init()
    {
        Quest_Add window = EditorWindow.GetWindow(typeof(Quest_Add)) as Quest_Add;
        window.Show();
    }

    private void OnGUI()
    {
        float componentWdith = 150f;

        string temp = "";

        string main_Index = "";
        string sub_Index;
        string quest_Name;
        string quest_detail;
        string to_Npc;

        string npc_Comunication;
        string player_Comunication;
        string req_Level;
        string req_Detail;
        string req_Main;

        string req_Monster_Index;
        string req_Monster_Num;
        string req_Item_Index;
        string req_Item_Num;
        string for_Npc;

        string for_Npc_Communication;
        string for_Player_Communication;
        string give;
        string give_num;
        string contents;

        // 1

       
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("메인 인덱스:", GUILayout.Width(componentWdith));
        main_Index = EditorGUILayout.TextField($"{main_Index}");
        EditorGUILayout.EndHorizontal();
  
        // 2
        GUILayout.BeginHorizontal();
        GUILayout.Label("연계 인덱스:", GUILayout.Width(componentWdith));
        sub_Index = EditorGUILayout.TextField("");
        GUILayout.EndHorizontal();
        /*
  // 3
  GUILayout.BeginHorizontal();
  GUILayout.Label("퀘스트 이름:", GUILayout.Width(componentWdith));
  quest_Name = EditorGUILayout.TextField("", GUILayout.Height(30f));
  GUILayout.EndHorizontal();

  // 4
  GUILayout.BeginHorizontal();
  GUILayout.Label("퀘스트 상세내용:", GUILayout.Width(componentWdith));
  quest_detail = EditorGUILayout.TextField("", GUILayout.Height(30f));
  GUILayout.EndHorizontal();

  // 5
  GUILayout.BeginHorizontal();
  GUILayout.Label("(수주) NPC 인덱스:", GUILayout.Width(componentWdith));
  to_Npc = EditorGUILayout.TextField("");
  GUILayout.EndHorizontal();

  // 6 ---------------
  GUILayout.BeginHorizontal();
  GUILayout.Label("(수주) NPC 지문:", GUILayout.Width(componentWdith));
  npc_Comunication = EditorGUILayout.TextField("", GUILayout.Height(100f));
  GUILayout.EndHorizontal();

  // 7 ---------------
  GUILayout.BeginHorizontal();
  GUILayout.Label("(수주) 플레이어 지문:", GUILayout.Width(componentWdith));
  player_Comunication = EditorGUILayout.TextField("", GUILayout.Height(100f));
  GUILayout.EndHorizontal();

  // 8 ---------------
  GUILayout.BeginHorizontal();
  GUILayout.Label("(필요) 레벨: ", GUILayout.Width(componentWdith));
  req_Level = EditorGUILayout.TextField("");
  GUILayout.EndHorizontal();

  // 9 ---------------
  GUILayout.BeginHorizontal();
  GUILayout.Label("(필요) 연계 퀘스트 인덱스:", GUILayout.Width(componentWdith));
  req_Detail = EditorGUILayout.TextField("");
  GUILayout.EndHorizontal();

  // 10 ---------------
  GUILayout.BeginHorizontal();
  GUILayout.Label("(필요) 메인 퀘스트 인덱스:", GUILayout.Width(componentWdith));
  req_Main = EditorGUILayout.TextField("");
  GUILayout.EndHorizontal();

  // 11
  GUILayout.BeginHorizontal();
  GUILayout.Label("(필요) 몬스터 사냥:", GUILayout.Width(componentWdith));
  req_Monster_Index = EditorGUILayout.TextField("");
  GUILayout.EndHorizontal();

  // 12 ---------------
  GUILayout.BeginHorizontal();
  GUILayout.Label("(필요) 몬스터 사냥 수:", GUILayout.Width(componentWdith));
  req_Monster_Num = EditorGUILayout.TextField("");
  GUILayout.EndHorizontal();

  // 13 ---------------
  GUILayout.BeginHorizontal();
  GUILayout.Label("(필요) 아이템 인덱스:", GUILayout.Width(componentWdith));
  req_Item_Index = EditorGUILayout.TextField("");
  GUILayout.EndHorizontal();

  // 14 ---------------
  GUILayout.BeginHorizontal();
  GUILayout.Label("(필요) 아이템 수:", GUILayout.Width(componentWdith));
  req_Item_Num = EditorGUILayout.TextField("");
  GUILayout.EndHorizontal();

  // 15 ---------------
  GUILayout.BeginHorizontal();
  GUILayout.Label("(완료) NPC 인덱스:", GUILayout.Width(componentWdith));
  for_Npc = EditorGUILayout.TextField("");
  GUILayout.EndHorizontal();

  // 16 ---------------
  GUILayout.BeginHorizontal();
  GUILayout.Label("(완료) NPC 지문:", GUILayout.Width(componentWdith));
  for_Npc_Communication = EditorGUILayout.TextField("", GUILayout.Height(100f));
  GUILayout.EndHorizontal();

  // 17---------------
  GUILayout.BeginHorizontal();
  GUILayout.Label("(완료) 플레이어 지문:", GUILayout.Width(componentWdith));
  for_Player_Communication = EditorGUILayout.TextField("", GUILayout.Height(100f));
  GUILayout.EndHorizontal();

  // 18 ---------------
  GUILayout.BeginHorizontal();
  GUILayout.Label("(완료) 보상 인덱스:", GUILayout.Width(componentWdith));
  give = EditorGUILayout.TextField("");
  GUILayout.EndHorizontal();

  // 19 ---------------
  GUILayout.BeginHorizontal();
  GUILayout.Label("(완료) 보상 수:", GUILayout.Width(componentWdith));
  give_num = EditorGUILayout.TextField("");
  GUILayout.EndHorizontal();

  // 20 ---------------
  GUILayout.BeginHorizontal();
  GUILayout.Label("퀘스트 유형:", GUILayout.Width(componentWdith));
  contents = EditorGUILayout.TextField("");
  GUILayout.EndHorizontal();

  */
        /*
        // Send
        EditorGUILayout.Space();
        if (GUILayout.Button(text: "전송"))
        {
            PostScores(
                 stringParser(main_Index),
                 stringParser(sub_Index),
                 quest_Name,
                 quest_detail,
                 stringParser(to_Npc),

                 npc_Comunication,
                 player_Comunication,
                 stringParser(req_Level),
                 stringParser(req_Detail),
                 stringParser(req_Main),

                 stringParser(req_Monster_Index),
                 stringParser(req_Monster_Num),
                 stringParser(req_Item_Index),
                 stringParser(req_Item_Num),
                 stringParser(for_Npc),

                 for_Npc_Communication,
                 for_Player_Communication,
                 stringParser(give),
                 stringParser(give_num),
                 stringParser(contents)
                );
        }
        */
    }

    public void PostScores(
        int main_Index,
        int sub_Index,
        string quest_Name,
        string quest_detail,
        int to_Npc,

        string npc_Comunication,
        string player_Comunication,
        int req_Level,
        int req_Detail,
        int req_Main,

        int req_Monster_Index,
        int req_Monster_Num,
        int req_Item_Index,
        int req_Item_Num,
        int for_Npc,

        string for_Npc_Communication,
        string for_Player_Communication,
        int give,
        int give_num,
        int contents

        )
    {
        string hash = HashInput(
            main_Index +
            sub_Index +
            quest_Name +
            quest_detail +
            to_Npc +

            npc_Comunication +
            player_Comunication +
            req_Level +
            req_Detail +
            req_Main +

            req_Monster_Index +
            req_Monster_Num +
            req_Item_Index +
            req_Item_Num +
            for_Npc +

            for_Npc_Communication +
            for_Player_Communication +
            give +
            give_num +
            contents +

            secretKey);

        string post_url = add_Quest_URL +
            "?main_Index=" + main_Index +
            "&sub_Index=" + sub_Index +
            "&quest_Name=" + UnityWebRequest.EscapeURL(quest_Name) +
            "&quest_detail=" + UnityWebRequest.EscapeURL(quest_detail) +
            "&to_Npc=" + to_Npc +

            "&npc_Comunication=" + UnityWebRequest.EscapeURL(npc_Comunication) +
            "&player_Comunication=" + UnityWebRequest.EscapeURL(player_Comunication) +
            "&req_Level=" + req_Level +
            "&req_Detail=" + req_Detail +
            "&req_Main=" + req_Main +

            "&req_Monster_Index=" + req_Monster_Index +
            "&req_Monster_Num=" + req_Monster_Num +
            "&req_Item_Index=" + req_Item_Index +
            "&req_Item_Num=" + req_Item_Num +
            "&for_Npc=" + for_Npc +

            "&for_Npc_Communication=" + UnityWebRequest.EscapeURL(for_Npc_Communication) +
            "&for_Player_Communication=" + UnityWebRequest.EscapeURL(for_Player_Communication) +
            "&give=" + give +
            "&give_num=" + give_num +
            "&contents=" + contents +

            "&hash=" + hash;

        UnityWebRequest hs_post = UnityWebRequest.Post(post_url, hash);

        hs_post.SendWebRequest();

        if (hs_post.error != null)
            Debug.Log("There was an error posting the high score: " + hs_post.error);
    }

    public string HashInput(string input)
    {
        SHA256Managed hm = new SHA256Managed();
        byte[] hashValue = hm.ComputeHash(System.Text.Encoding.ASCII.GetBytes(input));
        string hash_convert = BitConverter.ToString(hashValue).Replace("-", "").ToLower();
        return hash_convert;
    }

    public int stringParser(string _source)
    {
        return Int32.Parse(_source);
    }
}
