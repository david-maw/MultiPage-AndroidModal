namespace MultiPage;

public partial class ChildPage : ContentPage
{
	public ChildPage()
	{
		InitializeComponent();
	}
    public DateTime PageCreatedTime { get; } = DateTime.Now;

    private void SimulatedCommand(object sender, EventArgs e)
    {
        string actionText = "some";
        if (sender is Button button)
            actionText = button.CommandParameter.ToString();
        else if (sender is ToolbarItem toolbarItem)
            actionText = toolbarItem.CommandParameter.ToString();

        DisplayAlert("Simulated Action", $"'{actionText}' action for " + GetType().Name, "Cancel");
    }

    private async void Button_PopAsync(object sender, EventArgs e)
    {
        if (Navigation.NavigationStack.Count > 1 && Navigation.NavigationStack[Navigation.NavigationStack.Count - 1] == this)
            await Navigation.PopAsync();
    }

    private async void Button_PopModalAsync(object sender, EventArgs e)
    {
        if (Navigation.ModalStack.Count > 0 && Navigation.ModalStack[Navigation.ModalStack.Count - 1] == this)
            await Navigation.PopModalAsync();
    }
}