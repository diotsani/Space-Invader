using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class LeaderboardManager : MonoBehaviour
{
    [SerializeField]
    private Transform parent;

    [SerializeField]
    private GameObject rowprefab;

    int playersToShow = 10;

    public List<LeaderBoardData> datas = new List<LeaderBoardData>();

    public void Refresh()
    {
        Sort();

        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        if (datas.Count > playersToShow)
        {
            datas.RemoveAt(datas.Count - 1);
        }

        if (datas.Count < playersToShow)
        {
            for (int i = 1; i <= datas.Count; i++)
            {
                Text[] t = Instantiate(rowprefab, parent).GetComponentsInChildren<Text>();
                Text ranktext = t[0];
                Text nametext = t[1];
                Text scoretext = t[2];

                ranktext.text = i.ToString();
                nametext.text = datas[i - 1].name;
                scoretext.text = datas[i - 1].score.ToString();
            }
        }
        else
        {
            for (int i = 1; i <= playersToShow; i++)
            {
                Text[] t = Instantiate(rowprefab, parent).GetComponentsInChildren<Text>();
                Text ranktext = t[0];
                Text nametext = t[1];
                Text scoretext = t[2];

                ranktext.text = i.ToString();
                nametext.text = datas[i - 1].name;
                scoretext.text = datas[i - 1].score.ToString();
            }
        }
    }

    public void AddHighScore(string name, int score)
    {
        datas.Add(new LeaderBoardData (name, score));
        Refresh();
    }

    public class LeaderBoardData
    {
        public string name;
        public int score;

        public LeaderBoardData(string name, int score)
        {
            this.name = name;
            this.score = score;
        }
    }

    void Sort()
    {
        datas.Sort((p1, p2) => p2.score.CompareTo(p1.score));
    }

    //public int rand()
    //{
    //    return Random.Range(1, 100);
    //}

}
