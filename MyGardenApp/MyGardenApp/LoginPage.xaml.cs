namespace MyGardenApp;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

	private void ToggleShowPassword(object sender, EventArgs e)
	{
		bool passwordShown = PasswordEntry.IsPassword; //gets the current state of the toggle
		PasswordEntry.IsPassword = !passwordShown; //flips the value
												   //checks the state of the toggle
		if (passwordShown) //if the button is toggled to hide the passsword
		{
			ShowPasswordButton.Source = "show_password_visible_icon.png"; //sets the button image to visible
		}
		else //if the button is toggled to show the password
		{
			ShowPasswordButton.Source = "show_password_hidden_icon.png"; //sets the button image to hidden
		}
	}

	private void LoginButtonClicked(object sender, EventArgs e)
	{
		string username = UsernameEntry.Text; //gets the string entered into the username entry
		string password = HashLibrary.HashPassword(PasswordEntry.Text, username); //gets the string entered into the password entry
																				  //the password is then hashed because only hashed passwords are stored in the database

		if (UserAccountSql.UserExists(username, password)) //the database is checked to see if the if a user exists with the username and password
		{
			User.Login(username, password); //initialises the user class with the users data from the database
			Application.Current.OpenWindow(new Window(new GardenPage())); //takes the user to the garden designer page
		}
		else //if the user does not exist
		{
			IncorrectLoginLabel.IsVisible = true; //show the label informing the user that their username or password is incorrect
		}
	}

	private void RegisterButtonClicked(object sender, EventArgs e)
	{
		Application.Current.OpenWindow(new Window(new RegisterPage())); //takes the user to the registry page
	}
}
