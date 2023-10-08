using CommunityToolkit.Maui.Views;
namespace MyGardenApp;

public partial class PlanterPage : ContentPage
{
	string planterName; //makes the planter name avaliable to the whole class

	//makes the controls avaliable to the whole class
	Popup plantSelectPopup;
	Picker plantPicker;

	public PlanterPage(string name = "Planter Name")
	{
		InitializeComponent();
		planterName = name; //sets the palanter name with the given value
		TitleLabel.Text = name; //sets the title text to the given planter name
		UpdatePlantList(); //updates the planter list control
	}

	private void UpdatePlantList()
	{
		PlantLayout.Clear(); //clears the control

		//gets the index position of the current planter
		int index = Garden.GetPlanterIndex(planterName);

		//selects the plants from the current planter
		List<Plant> planterPlants = Garden.Planters[index].Plants;

		//if there are plants in the planter
		if (planterPlants.Count > 0)
		{
			//loops through each plant
			foreach (Plant plant in planterPlants)
			{
				//initialises a delete button control
				Button deleteButton = new Button()
				{
					Text = "X",
					TextColor = Color.FromArgb("#512bdf"),
					FontSize = 16,
					BorderWidth = 1,
					BorderColor = Colors.Black,
					BackgroundColor = Colors.White,
					Padding = 5,
					CornerRadius = 10,
					WidthRequest = 35,
				};
				//set the buttons Clicked event
				EventHandler deleteButtonEventHandler = (sender, e) => DeleteButtonClicked(plant);
				deleteButton.Clicked += deleteButtonEventHandler;

				//intialises the plant control
				HorizontalStackLayout plantControl = new HorizontalStackLayout
				{
					Spacing = 5,
					Children =
					{
						new Label()
						{
							Text = plant.Name,
							TextColor = Colors.White,
							FontSize = 24,
							WidthRequest = 330,
						},

						deleteButton
					}

				};

				//shows the control on the screen
				PlantLayout.Add(plantControl);
			}
		}
	}

	private void DeleteButtonClicked(Plant plant)
    {
		int planterIndex = Garden.GetPlanterIndex(planterName); //gets the index of the current planter
		Garden.Planters[planterIndex].Plants.Remove(plant); //deletes the plant given plant in the current planter 
		UpdatePlantList(); //updates the plantlist control to show the change
	}

	private void CreatePlantSelectPopup()
	{
		//initialises the list of plant names
		List<string> plantsList = new List<string>() { "Carrot", "Tomato", "Potato", "Lettuce", "Strawberry", "Cabbage", "Rhubarb" };
		plantsList.Sort();

		//initialises plant picker control 
		plantPicker = new Picker
		{
			Title = "Select a plant",
			ItemsSource = plantsList,
			FontSize = 16
		};

		//initialises add plant button
		Button addPlantButton = new Button
		{
			FontSize = 16,
			Text = "Add Plant",
			BackgroundColor = Color.FromArgb("#512bdf"),
			WidthRequest = 100,
			HorizontalOptions = LayoutOptions.Center
		};
		//set the buttons Clicked event
		EventHandler buttonEventHandler = (sender, e) => AddNewPlant(plantPicker.SelectedItem.ToString());
		addPlantButton.Clicked += buttonEventHandler;
		
		//initialises the plant picker popup
		plantSelectPopup = new Popup()
		{
			Size = new Size(200, 120),

			Content = new VerticalStackLayout
			{
				Padding = 5,
				Children =
				{
					new Label
					{
						FontSize = 16,
						TextColor = Color.FromArgb("#512bdf"),
						Text = "Plants:",
						HorizontalOptions = LayoutOptions.Center
					},

					plantPicker,

					addPlantButton
				}
			}
		};
	}

	private void AddNewPlantButtonClicked(object sender, EventArgs e)
	{
		CreatePlantSelectPopup(); //creates a new plant select popup
		PopupExtensions.ShowPopup(Window.Page, plantSelectPopup); //shows the popup on screen
	}

	private void AddNewPlant(string plantName)
    {
		//if a plant is picked
		if (plantName != "")
		{
			int index = Garden.GetPlanterIndex(planterName); //get the index of the current planter
			Garden.Planters[index].AddPlant(plantName); //adds the plant with given name to the current planter
			plantSelectPopup.Close(); //closes the plant picker popup
			UpdatePlantList(); //update the plant list control to show the change
		}
	}

	private void SavePlanterButtonClicked(object sender, EventArgs e)
	{
		User.UpdateUserGarden(); //User class is called to save the current garden to the database
		Application.Current.OpenWindow(new Window(new GardenPage())); //takes the user back to the garden page
	}

}