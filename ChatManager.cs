using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Summary : 1. ���� ��ǥ�� UI�� ��Ȱ��ȭ�� ä�� �ִٰ�
//             ��� Ʈ���� �Ǵ� �ð��� ���� ��
//             ����UI�� Ȱ��ȭ �� ��
//             �̹��� ���� Ȱ��ȭ ��Ű��
//             �ؽ�Ʈ�� �� 0.4~5�� �� ���
//             ���� �ؽ�Ʈ�� �ѱ��ھ� ���
//             => TextMeshProŬ���� ����ؾ��� ���� �ʿ�

//          2. ��ũ�� ��ǥ�� UI�� ��Ȱ��ȭ�� ä�� �ִٰ�
//             ��� Ʈ���� �Ǵ� �ð��� ���� ��
//             ��ũ��UI�� Ȱ��ȭ �� ��
//             �̹��� ���� Ȱ��ȭ ��Ű��
//             �ؽ�Ʈ�� �� 0.4~5�� �� ���
//             �ؽ�Ʈ�� �ѱ��ھ� ���
//             => �����ϰ� Text�� ����

public class ChatManager : MonoBehaviour
{
    public Text chatText;
    bool isChat = false;

    private void Start()
    {
        StartCoroutine(DelayChat("�ȳ��ϼ���. �� �̸��� �߼����Դϴ�.", 3f));
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
