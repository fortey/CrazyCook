using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum PanStatus { Empty, Raw, Norm, Burn}
public class Pan : MonoBehaviour, IPointerClickHandler
{
    public GameObject Raw;
    public GameObject Norm;
    public GameObject Burn;

    public SetOfPlates SetOfPlates;
    public ProgressBar GreenProgress;
    public ProgressBar RedProgress;

    public float CookingTime = 5f;
    public float BurnTime = 7f;

    public PanStatus Status { get; set; } = PanStatus.Empty;

    public void PutMeat()
    {
        Raw.SetActive(true);
        GreenProgress.StartTimer(CookingTime, CompleteCooking);
        Status = PanStatus.Raw;
    }

    void CompleteCooking()
    {
        Status = PanStatus.Norm;
        Raw.SetActive(false);
        Norm.SetActive(true);

        RedProgress.StartTimer(BurnTime, CompleteBurning);
    }
   
    void CompleteBurning()
    {
        Status = PanStatus.Burn;
        Norm.SetActive(false);
        Burn.SetActive(true);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(Status== PanStatus.Norm)
        {
            if (SetOfPlates.PutFilling())
            {
                Status = PanStatus.Empty;
                Norm.SetActive(false);
                RedProgress.Stop();
            }
        }
        else if(Status == PanStatus.Burn && eventData.clickCount == 2)
        {
            Burn.SetActive(false);
            Status = PanStatus.Empty;
        }
    }
}
