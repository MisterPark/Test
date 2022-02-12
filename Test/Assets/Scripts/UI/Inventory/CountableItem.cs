using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CountableItem : Item
{
    public CountableItemData CountableData { get; private set; }

    public int Amount { get; protected set; }

    public int MaxAmount => CountableData.MaxAmount;

    public bool IsMax => Amount >= CountableData.MaxAmount;

    public bool IsEmpty => Amount <= 0;

    public void SetAmount(int amount)
    {
        Amount = Mathf.Clamp(amount, 0, MaxAmount);
    }
    public CountableItem(CountableItemData data, int amount = 1) : base(data)
    {
        CountableData = data;
        SetAmount(amount);
    }

    public int AddAmountAndGetExcess(int amount)
    {
        int nextamount = Amount + amount;
        SetAmount(nextamount);

        return (nextamount > MaxAmount) ? (nextamount - MaxAmount) : 0;
    }
    protected abstract CountableItem Clone(int amount);
}
