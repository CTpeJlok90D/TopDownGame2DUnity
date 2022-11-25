using UnityEngine;

internal interface IInteracteble
{
    public void Interact(InteractInfo interactInfo);
    public Transform transform { get; }
}
