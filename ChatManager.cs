using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Summary : 1. 월드 좌표의 UI가 비활성화된 채로 있다가
//             어느 트리거 또는 시간이 지난 후
//             월드UI가 활성화 된 후
//             이미지 같이 활성화 시키고
//             텍스트는 약 0.4~5초 뒤 재생
//             또한 텍스트는 한글자씩 재생
//             => TextMeshPro클래스 사용해야함 논의 필요

//          2. 스크린 좌표의 UI가 비활성화된 채로 있다가
//             어느 트리거 또는 시간이 지난 후
//             스크린UI가 활성화 된 후
//             이미지 같이 활성화 시키고
//             텍스트는 약 0.4~5초 뒤 재생
//             텍스트는 한글자씩 재생
//             => 간단하게 Text만 구현

public class ChatManager : MonoBehaviour
{
    public Text chatText;
    bool isChat = false;

    private void Start()
    {
        StartCoroutine(DelayChat("안녕하세요. 제 이름은 추성결입니다.", 3f));
    }

    IEnumerator DelayChat(string content, float delay)
    {
        if (isChat == false)
        {
            //string chat;

            for (int i = 0; i < content.Length; i++)
            {
                //chat = "" +  $"{content[i]}";
                chatText.text += "" + $"{content[i]}";
                yield return new WaitForSeconds(delay);
            }
        }
        isChat = true;
    }

    //void TimeDelay(float maxTime)
    //{
    //    float curTime =0;
    //    curTime += Time.deltaTime;

    //    if (curTime > maxTime)
    //    {
    //        return;
    //    }
    //}
}
