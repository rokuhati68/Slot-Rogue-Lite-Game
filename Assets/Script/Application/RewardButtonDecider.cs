using UnityEngine;
using UnityEngine.UI;
public class RewardButtonDecider:MonoBehaviour
{
    [SerializeField] RewardButton[] nowButtons;
    [SerializeField] RewardButton[] rewardButtons;
    [SerializeField] Button decideButton;
    public AddStatusSet addStatusSet;
    public int preID;
    public int rewardID;
    public event System.Action OnRewardFinished;
    void Start()
    {
        foreach (var b in nowButtons)
        {
            b.OnClicked += preIDSet;
        }
        foreach (var b in rewardButtons)
        {
            b.OnClicked += rewardIDSet;
        }
        Reset();
    }
    public void onClickedDecideButton()
    {
        if(preID != -1 && rewardID != -1)
        {
            addStatusSet.RewardGet(preID,rewardID);
            Reset();
            OnRewardFinished?.Invoke();
        }
    }
    void preIDSet(int id)
    {
        preID = id;
    }
    void rewardIDSet(int id)
    {
        rewardID = id;
    }
    public void Reset()
    {
        preID = -1;
        rewardID = -1;
    }
}