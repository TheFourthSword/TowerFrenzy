using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeightButton : MonoBehaviour
{
    public enum ButtonType { larger, smaller, equal, not }
    public ButtonType BigButtonBuddy;
    public int GoodThiccness;
    public int CurrentThiccness;
    //public barscript bar;

    public UnityEvent Stonks;
    public UnityEvent NotStonks;

    public void Start()
    {
        //bar?.setBar(CurrentThiccness, GoodThiccness);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Thicc"))
        {
            CurrentThiccness += other.GetComponent<HowHeavy>().Thiccy;
            //bar?.setBar(CurrentThiccness, GoodThiccness);
            ThiccEnough();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Thicc"))
        {
            CurrentThiccness -= other.GetComponent<HowHeavy>().Thiccy;
            //bar?.setBar(CurrentThiccness, GoodThiccness);
            ThiccEnough();
        }
    }

    private void ThiccEnough()
    {
        bool ThiccyEnough = false;
        switch (BigButtonBuddy)
        {
            case ButtonType.equal:
                ThiccyEnough = CurrentThiccness == GoodThiccness;
                break;

            case ButtonType.not:
                ThiccyEnough = CurrentThiccness != GoodThiccness;
                break;

            case ButtonType.larger:
                ThiccyEnough = CurrentThiccness >= GoodThiccness;
                break;

            case ButtonType.smaller:
                ThiccyEnough = CurrentThiccness <= GoodThiccness;
                break;

            default:
                Debug.LogError("Gozer wtf");
                break;
        }

       /* if (ThiccyEnough)
        {
            Stonks.Invoke();
        }
        else
        {
            NotStonks.Invoke();
        } */
    }

}
