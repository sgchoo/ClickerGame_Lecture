using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Summary : 처음 시작은 GetCoinBtn제외 모든 버튼 interactable == false
//          조건 체크 함수 생성하여 조건 충족 시 해당 버튼 interactable == true
//          업그레이드 버튼은 최대 가능 횟수 지정하여 이상 넘어갈시 interactable == false
//          LevelUp버튼은 최대 한번 가능 그 후 버튼 interactable == false

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

    //void ActiveStage(int stagenum) //Stage Level에 맞는 이미지만 Active되는 함수
    //{
    //    for (int i = 0; i < 5; i++)
    //    {
    //        bg_img[i].gameObject.SetActive(false);
    //    }
    //    bg_img[stagenum].gameObject.SetActive(true);
    //} 

    void UpgradePossible() //각종 업그레이드 조건 함수
    {
        //건물 업그레이드 가능 체크
        if (coinCount >= upgradeCount * upgradeBonus * 1000)
        {
            coinCount -= upgradeCount * upgradeBonus * 1000;

            coinValue.text = "Coin : " + coinCount;

            if (upgradeCount > 8)
            {
                upgradeBtn.GetComponentInChildren<Text>().text = "최대 업그레이드에 도달했습니다.";
                upgradeBtn.interactable = false;
            }

            else
            {
                upgradeBtn.interactable = true;
            }
        }

        //건물 구매 가능 체크
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
        levelUpBtn_2.GetComponentInChildren<Text>().text = "구매 완료";
    }

    public void ThirdLevelUpBtn()
    {
        coinCount -= 1_000_000;
        stageCount = 3;
        levelValue.text = "Level : " + stageCount;
        coinValue.text = "Coin : " + coinCount;
        levelUpBtn_3.interactable = false;
        levelUpBtn_3.GetComponentInChildren<Text>().text = "구매 완료";
    }

    public void FourthLevelUpBtn()
    {
        coinCount -= 10_000_000;
        stageCount = 4;
        levelValue.text = "Level : " + stageCount;
        coinValue.text = "Coin : " + coinCount;
        levelUpBtn_4.interactable = false;
        levelUpBtn_4.GetComponentInChildren<Text>().text = "구매 완료";
    }

    public void FifthLevelUpBtn()
    {
        coinCount -= 100_000_000;
        stageCount = 5;
        levelValue.text = "Level : " + stageCount;
        coinValue.text = "Coin : " + coinCount;
        levelUpBtn_5.interactable = false;
        levelUpBtn_5.GetComponentInChildren<Text>().text = "구매 완료";
    }
}

/* GetCoinBtn 누를때마다 Sound 실행 기능 추가
 * GetCoinBtn 누를때 Color32에서 투명도 조절
 * GetCoinBtn 누를때마다 클릭 지점에서 text(ex.GetCoin!) 생성 후 윗방향으로 서서히 이동, 정해진 시간에 맞춰 서서히 사라지는 기능
 */
