using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Summary : ó�� ������ GetCoinBtn���� ��� ��ư interactable == false
//          ���� üũ �Լ� �����Ͽ� ���� ���� �� �ش� ��ư interactable == true
//          ���׷��̵� ��ư�� �ִ� ���� Ƚ�� �����Ͽ� �̻� �Ѿ�� interactable == false
//          LevelUp��ư�� �ִ� �ѹ� ���� �� �� ��ư interactable == false

public class ButtonController : MonoBehaviour
{
    int coinCount = 0;
    int stageCount = 1;
    int upgradeCount = 1;
    int upgradeBonus = 1;
    int stageBonus = 1;

    public Text coinValue;
    public Text levelValue;
    public Image[] buildingImg = new Image[5];
    public Button getCoinBtn;
    public Button upgradeBtn;
    public Button levelUpBtn_2;
    public Button levelUpBtn_3;
    public Button levelUpBtn_4;
    public Button levelUpBtn_5;

    void Start()
    {
        coinValue.text = "Coin : 0";
        levelValue.text = "Level : 1";

        levelUpBtn_2.interactable = false;
        levelUpBtn_3.interactable = false;
        levelUpBtn_4.interactable = false;
        levelUpBtn_5.interactable = false;
    }

    void Update()
    {
        ImageActive();
        UpgradePossible();
    }

    void ImageActive()
    {
        for (int i = 0; i < buildingImg.Length; i++)
        {
            if (stageCount - 1 == i)
            {
                buildingImg[(i)].gameObject.SetActive(true);
            }
        }
    }

    //void ActiveStage(int stagenum) //Stage Level�� �´� �̹����� Active�Ǵ� �Լ�
    //{
    //    for (int i = 0; i < 5; i++)
    //    {
    //        bg_img[i].gameObject.SetActive(false);
    //    }
    //    bg_img[stagenum].gameObject.SetActive(true);
    //} 

    void UpgradePossible() //���� ���׷��̵� ���� �Լ�
    {
        //�ǹ� ���׷��̵� ���� üũ
        if (coinCount >= upgradeCount * upgradeBonus * 1000)
        {
            coinCount -= upgradeCount * upgradeBonus * 1000;

            coinValue.text = "Coin : " + coinCount;

            if (upgradeCount > 8)
            {
                upgradeBtn.GetComponentInChildren<Text>().text = "�ִ� ���׷��̵忡 �����߽��ϴ�.";
                upgradeBtn.interactable = false;
            }

            else
            {
                upgradeBtn.interactable = true;
            }
        }

        //�ǹ� ���� ���� üũ
        if (stageCount == 1 && coinCount > 10_000)
        {
            levelUpBtn_2.interactable = true;
        }

        else if (stageCount == 2 && coinCount > 1_000_000)
        {
            levelUpBtn_3.interactable = true;
        }

        else if (stageCount == 3 && coinCount > 10_000_000)
        {
            levelUpBtn_4.interactable = true;
        }

        else if (stageCount == 4 && coinCount > 100_000_000)
        {
            levelUpBtn_5.interactable = true;
        }
    }

    public void GetCoinBtn()
    {
        switch (upgradeCount)
        {
            case 2:
                upgradeBonus = 100;
                break;

            case 3:
                upgradeBonus = 200;
                break;

            case 4:
                upgradeBonus = 400;
                break;

            case 5:
                upgradeBonus = 600;
                break;

            case 6:
                upgradeBonus = 800;
                break;

            case 7:
                upgradeBonus = 1000;
                break;

            case 8:
                upgradeBonus = 1200;
                break;
        }

        switch (stageCount)
        {
            case 2:
                stageBonus = 100;
                break;

            case 3:
                stageBonus = 200;
                break;

            case 4:
                stageBonus = 400;
                break;

            case 5:
                stageBonus = 800;
                break;
        } 

        Debug.Log("UpgradeBonus : " + upgradeBonus);
        Debug.Log("StageBonus : " + stageBonus);

        coinCount += 1 * upgradeBonus * stageBonus;

        coinValue.text = $"Coin : {coinCount:N0}";
    }

    public void BuildingUpgradeBtn()
    {
        upgradeCount++;
        upgradeBtn.interactable = false;
    }

    public void SecondLevelUpBtn()
    {
        coinCount -= 10_000;
        stageCount = 2;
        levelValue.text = "Level : " + stageCount;
        coinValue.text = "Coin : " + coinCount;
        levelUpBtn_2.interactable = false;
        levelUpBtn_2.GetComponentInChildren<Text>().text = "���� �Ϸ�";
    }

    public void ThirdLevelUpBtn()
    {
        coinCount -= 1_000_000;
        stageCount = 3;
        levelValue.text = "Level : " + stageCount;
        coinValue.text = "Coin : " + coinCount;
        levelUpBtn_3.interactable = false;
        levelUpBtn_3.GetComponentInChildren<Text>().text = "���� �Ϸ�";
    }

    public void FourthLevelUpBtn()
    {
        coinCount -= 10_000_000;
        stageCount = 4;
        levelValue.text = "Level : " + stageCount;
        coinValue.text = "Coin : " + coinCount;
        levelUpBtn_4.interactable = false;
        levelUpBtn_4.GetComponentInChildren<Text>().text = "���� �Ϸ�";
    }

    public void FifthLevelUpBtn()
    {
        coinCount -= 100_000_000;
        stageCount = 5;
        levelValue.text = "Level : " + stageCount;
        coinValue.text = "Coin : " + coinCount;
        levelUpBtn_5.interactable = false;
        levelUpBtn_5.GetComponentInChildren<Text>().text = "���� �Ϸ�";
    }
}

/* GetCoinBtn ���������� Sound ���� ��� �߰�
 * GetCoinBtn ������ Color32���� ���� ����
 * GetCoinBtn ���������� Ŭ�� �������� text(ex.GetCoin!) ���� �� ���������� ������ �̵�, ������ �ð��� ���� ������ ������� ���
 */
