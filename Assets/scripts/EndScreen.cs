using System;

public class EndScreen : Window
{
    public event Action ResetButtonClicked;

    public override void Close()
    {
        WindowGroup.alpha = 0f;
        WindowGroup.blocksRaycasts = false;
        ActionButton.interactable = false;
    }

    public override void Open()
    {
        WindowGroup.alpha = 1f;
        WindowGroup.blocksRaycasts = true;
        ActionButton.interactable = true;
    }

    public override void OnButtonClick()
    {
        ResetButtonClicked?.Invoke();
    }
}
