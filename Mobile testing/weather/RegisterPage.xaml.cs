namespace weather;
public partial class RegisterPage : ContentPage
{
	public RegisterPage()
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

	private void RegisterButtonClicked(object sender, EventArgs e)
    {
		string email = EmailEntry.Text; //gets the inputted email from the email entry
		string username = UsernameEntry.Text; //gets the inputted username from the email entry
		bool emailValid = EmailValidator(email); //checks that the email is not already in use
		bool usernameValid = UsernameValidator(username); //checks that the username is not already in use

		if (emailValid && usernameValid) //if the username and email are both avaliable
		{
			string password = HashLibrary.HashPassword(PasswordEntry.Text, username); //hash the inputted password with the username as salt

			User.Register(email, username, password); //uses the sqldatabase functionality within user to create a new user database entry
													  //then initialises the user class

			Application.Current.OpenWindow(new Window(new GardenPage())); //takes the user to the garden page
		}
	}

	private bool EmailValidator(string email)
	{
		bool valid = UserAccountsSql.EmailInUse(email); //uses the sqldatabase functionality to check if given email is in the database
		EmailValidLabel.IsVisible = valid; //if the email is in use it shows the user a label stating so
		return !valid; //it returns whether the email is valid or not
	}

	private bool UsernameValidator(string username)
    {
		bool valid = UserAccountsSql.UsernameInUse(username); //uses the sqldatabase functionality to check if given username is in the database
		UsernameValidLabel.IsVisible = valid; //if the username is in use it shows the user a label stating so
		return !valid; //it returns whether the username is valid or not
	}

	private void PasswordValidator(object sender, EventArgs e)
    {
		string password = PasswordEntry.Text; //gets the string entered in the password entry
		
		PasswordRequirements.IsVisible = password.Length > 0; //shows the requirement checklist while the user is entering a password

		CheckEightChars.IsChecked = HasEightCharacters(password); //checks the box if the password has >= 8 characters
		CheckThreeNums.IsChecked = HasThreeNumbers(password); //checks the box if the password has >= 3 numbers
		CheckOneCap.IsChecked = HasOneCapital(password); //checks the box if the password has >= 1 capital
		CheckOneSpecial.IsChecked = HasSpecialCharacter(password); //checks the box if the password has >= 1 special

		//allows the user to attempt to create their account once the password is of neseccary complexity
		RegisterButton.IsEnabled = (CheckEightChars.IsChecked && CheckThreeNums.IsChecked && CheckOneCap.IsChecked && CheckOneSpecial.IsChecked);
	}

	private static bool HasEightCharacters(string password)
    {
		return (password.Length >= 8); //returns true if the given password has >= 8 characters
	}

	private static bool HasThreeNumbers(string password)
	{
		int numCount = 0; //counter to count each instance of a numbers
		foreach(char c in password) //loops through each character in the given password
        {
			if (c >= 48 && c <= 57) //checks if the ascii value of the character is within the range of the numbers
			{
				numCount++; //if within range then the number counter is incremented by 1
			}
		}
		return (numCount >= 3); //returns true if there are >= 3 numbers
	}

	private static bool HasOneCapital(string password)
	{
		bool hasCapital = false; //flag bool to be returned
		foreach (char c in password) //loops through each character in the given password
		{
			if (c >= 65 && c <= 90) //checks if the ascii value of the character is within the range of the capital letters
			{
				hasCapital = true; //flips the flag to true if a capital is in the password
			}
		}
		return hasCapital; //returns true if a capital is in the password
	}

	private static bool HasSpecialCharacter(string password)
	{
		bool hasSpecial = false; //flag bool to be returned
		foreach (char c in password) //loops through each character in the given password
		{
			//checks if the ascii value of the character is within the range of the special characters
			if (!(c >= 65 && c <= 90) && !(c >= 48 && c <= 57) && !(c >= 97 && c <= 122) && c >= 33) 
			{
				hasSpecial = true; //flips the flag to true if a special character is in the password
			}
		}
		return hasSpecial; //returns true if the password has a special character
	}

	private void LoginButtonClicked(object sender, EventArgs e)
	{
		Application.Current.OpenWindow(new Window(new LoginPage())); //takes the user to the login page
	}
}