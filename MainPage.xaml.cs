namespace MultiPage;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await Task.Delay(100);
        await Navigation.PushModalAsync(new ChildPage());
    }

    public DateTime PageCreatedTime { get; } = DateTime.Now;

    private void MainPage_Button_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage());
    }

    private void Page1_Button_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Page1());
    }

    private void Page2_Button_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Page2());
    }

    private async void ChildPage_Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ChildPage());
    }

    private async void ChildPage_Async_Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new ChildPage());
    }

    private void SimulatedCommand(object sender, EventArgs e)
    {
        string actionText = "some";
        if (sender is Button button)
            actionText = button.CommandParameter.ToString();
        else if (sender is ToolbarItem toolbarItem)
            actionText = toolbarItem.CommandParameter.ToString();

        DisplayAlert("Simulated Action", $"'{actionText}' action for " + GetType().Name, "Cancel");
    }
}

