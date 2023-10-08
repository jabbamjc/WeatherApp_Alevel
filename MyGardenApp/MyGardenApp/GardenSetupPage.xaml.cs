using Newtonsoft.Json;
namespace MyGardenApp;

public partial class GardenSetupPage : ContentPage
{
	public GardenSetupPage()
	{
		InitializeComponent();
		SetupControls(); //sets up the controls to be shown on the page
	}

	//deserialises the countries JSON file to a .NET object
	dynamic countries = JsonConvert.DeserializeObject("[\n  {\n    \"Code\": \"AF\",\n    \"Name\": \"Afghanistan\"\n  },\n  {\n    \"Code\": \"AX\",\n    \"Name\": \"�land Islands\"\n  },\n  {\n    \"Code\": \"AL\",\n    \"Name\": \"Albania\"\n  },\n  {\n    \"Code\": \"DZ\",\n    \"Name\": \"Algeria\"\n  },\n  {\n    \"Code\": \"AS\",\n    \"Name\": \"American Samoa\"\n  },\n  {\n    \"Code\": \"AD\",\n    \"Name\": \"Andorra\"\n  },\n  {\n    \"Code\": \"AO\",\n    \"Name\": \"Angola\"\n  },\n  {\n    \"Code\": \"AI\",\n    \"Name\": \"Anguilla\"\n  },\n  {\n    \"Code\": \"AQ\",\n    \"Name\": \"Antarctica\"\n  },\n  {\n    \"Code\": \"AG\",\n    \"Name\": \"Antigua and Barbuda\"\n  },\n  {\n    \"Code\": \"AR\",\n    \"Name\": \"Argentina\"\n  },\n  {\n    \"Code\": \"AM\",\n    \"Name\": \"Armenia\"\n  },\n  {\n    \"Code\": \"AW\",\n    \"Name\": \"Aruba\"\n  },\n  {\n    \"Code\": \"AU\",\n    \"Name\": \"Australia\"\n  },\n  {\n    \"Code\": \"AT\",\n    \"Name\": \"Austria\"\n  },\n  {\n    \"Code\": \"AZ\",\n    \"Name\": \"Azerbaijan\"\n  },\n  {\n    \"Code\": \"BS\",\n    \"Name\": \"Bahamas\"\n  },\n  {\n    \"Code\": \"BH\",\n    \"Name\": \"Bahrain\"\n  },\n  {\n    \"Code\": \"BD\",\n    \"Name\": \"Bangladesh\"\n  },\n  {\n    \"Code\": \"BB\",\n    \"Name\": \"Barbados\"\n  },\n  {\n    \"Code\": \"BY\",\n    \"Name\": \"Belarus\"\n  },\n  {\n    \"Code\": \"BE\",\n    \"Name\": \"Belgium\"\n  },\n  {\n    \"Code\": \"BZ\",\n    \"Name\": \"Belize\"\n  },\n  {\n    \"Code\": \"BJ\",\n    \"Name\": \"Benin\"\n  },\n  {\n    \"Code\": \"BM\",\n    \"Name\": \"Bermuda\"\n  },\n  {\n    \"Code\": \"BT\",\n    \"Name\": \"Bhutan\"\n  },\n  {\n    \"Code\": \"BO\",\n    \"Name\": \"Bolivia, Plurinational State of\"\n  },\n  {\n    \"Code\": \"BQ\",\n    \"Name\": \"Bonaire, Sint Eustatius and Saba\"\n  },\n  {\n    \"Code\": \"BA\",\n    \"Name\": \"Bosnia and Herzegovina\"\n  },\n  {\n    \"Code\": \"BW\",\n    \"Name\": \"Botswana\"\n  },\n  {\n    \"Code\": \"BV\",\n    \"Name\": \"Bouvet Island\"\n  },\n  {\n    \"Code\": \"BR\",\n    \"Name\": \"Brazil\"\n  },\n  {\n    \"Code\": \"IO\",\n    \"Name\": \"British Indian Ocean Territory\"\n  },\n  {\n    \"Code\": \"BN\",\n    \"Name\": \"Brunei Darussalam\"\n  },\n  {\n    \"Code\": \"BG\",\n    \"Name\": \"Bulgaria\"\n  },\n  {\n    \"Code\": \"BF\",\n    \"Name\": \"Burkina Faso\"\n  },\n  {\n    \"Code\": \"BI\",\n    \"Name\": \"Burundi\"\n  },\n  {\n    \"Code\": \"KH\",\n    \"Name\": \"Cambodia\"\n  },\n  {\n    \"Code\": \"CM\",\n    \"Name\": \"Cameroon\"\n  },\n  {\n    \"Code\": \"CA\",\n    \"Name\": \"Canada\"\n  },\n  {\n    \"Code\": \"CV\",\n    \"Name\": \"Cape Verde\"\n  },\n  {\n    \"Code\": \"KY\",\n    \"Name\": \"Cayman Islands\"\n  },\n  {\n    \"Code\": \"CF\",\n    \"Name\": \"Central African Republic\"\n  },\n  {\n    \"Code\": \"TD\",\n    \"Name\": \"Chad\"\n  },\n  {\n    \"Code\": \"CL\",\n    \"Name\": \"Chile\"\n  },\n  {\n    \"Code\": \"CN\",\n    \"Name\": \"China\"\n  },\n  {\n    \"Code\": \"CX\",\n    \"Name\": \"Christmas Island\"\n  },\n  {\n    \"Code\": \"CC\",\n    \"Name\": \"Cocos (Keeling) Islands\"\n  },\n  {\n    \"Code\": \"CO\",\n    \"Name\": \"Colombia\"\n  },\n  {\n    \"Code\": \"KM\",\n    \"Name\": \"Comoros\"\n  },\n  {\n    \"Code\": \"CG\",\n    \"Name\": \"Congo\"\n  },\n  {\n    \"Code\": \"CD\",\n    \"Name\": \"Congo, the Democratic Republic of the\"\n  },\n  {\n    \"Code\": \"CK\",\n    \"Name\": \"Cook Islands\"\n  },\n  {\n    \"Code\": \"CR\",\n    \"Name\": \"Costa Rica\"\n  },\n  {\n    \"Code\": \"CI\",\n    \"Name\": \"C�te d'Ivoire\"\n  },\n  {\n    \"Code\": \"HR\",\n    \"Name\": \"Croatia\"\n  },\n  {\n    \"Code\": \"CU\",\n    \"Name\": \"Cuba\"\n  },\n  {\n    \"Code\": \"CW\",\n    \"Name\": \"Cura�ao\"\n  },\n  {\n    \"Code\": \"CY\",\n    \"Name\": \"Cyprus\"\n  },\n  {\n    \"Code\": \"CZ\",\n    \"Name\": \"Czech Republic\"\n  },\n  {\n    \"Code\": \"DK\",\n    \"Name\": \"Denmark\"\n  },\n  {\n    \"Code\": \"DJ\",\n    \"Name\": \"Djibouti\"\n  },\n  {\n    \"Code\": \"DM\",\n    \"Name\": \"Dominica\"\n  },\n  {\n    \"Code\": \"DO\",\n    \"Name\": \"Dominican Republic\"\n  },\n  {\n    \"Code\": \"EC\",\n    \"Name\": \"Ecuador\"\n  },\n  {\n    \"Code\": \"EG\",\n    \"Name\": \"Egypt\"\n  },\n  {\n    \"Code\": \"SV\",\n    \"Name\": \"El Salvador\"\n  },\n  {\n    \"Code\": \"GQ\",\n    \"Name\": \"Equatorial Guinea\"\n  },\n  {\n    \"Code\": \"ER\",\n    \"Name\": \"Eritrea\"\n  },\n  {\n    \"Code\": \"EE\",\n    \"Name\": \"Estonia\"\n  },\n  {\n    \"Code\": \"ET\",\n    \"Name\": \"Ethiopia\"\n  },\n  {\n    \"Code\": \"FK\",\n    \"Name\": \"Falkland Islands (Malvinas)\"\n  },\n  {\n    \"Code\": \"FO\",\n    \"Name\": \"Faroe Islands\"\n  },\n  {\n    \"Code\": \"FJ\",\n    \"Name\": \"Fiji\"\n  },\n  {\n    \"Code\": \"FI\",\n    \"Name\": \"Finland\"\n  },\n  {\n    \"Code\": \"FR\",\n    \"Name\": \"France\"\n  },\n  {\n    \"Code\": \"GF\",\n    \"Name\": \"French Guiana\"\n  },\n  {\n    \"Code\": \"PF\",\n    \"Name\": \"French Polynesia\"\n  },\n  {\n    \"Code\": \"TF\",\n    \"Name\": \"French Southern Territories\"\n  },\n  {\n    \"Code\": \"GA\",\n    \"Name\": \"Gabon\"\n  },\n  {\n    \"Code\": \"GM\",\n    \"Name\": \"Gambia\"\n  },\n  {\n    \"Code\": \"GE\",\n    \"Name\": \"Georgia\"\n  },\n  {\n    \"Code\": \"DE\",\n    \"Name\": \"Germany\"\n  },\n  {\n    \"Code\": \"GH\",\n    \"Name\": \"Ghana\"\n  },\n  {\n    \"Code\": \"GI\",\n    \"Name\": \"Gibraltar\"\n  },\n  {\n    \"Code\": \"GR\",\n    \"Name\": \"Greece\"\n  },\n  {\n    \"Code\": \"GL\",\n    \"Name\": \"Greenland\"\n  },\n  {\n    \"Code\": \"GD\",\n    \"Name\": \"Grenada\"\n  },\n  {\n    \"Code\": \"GP\",\n    \"Name\": \"Guadeloupe\"\n  },\n  {\n    \"Code\": \"GU\",\n    \"Name\": \"Guam\"\n  },\n  {\n    \"Code\": \"GT\",\n    \"Name\": \"Guatemala\"\n  },\n  {\n    \"Code\": \"GG\",\n    \"Name\": \"Guernsey\"\n  },\n  {\n    \"Code\": \"GN\",\n    \"Name\": \"Guinea\"\n  },\n  {\n    \"Code\": \"GW\",\n    \"Name\": \"Guinea-Bissau\"\n  },\n  {\n    \"Code\": \"GY\",\n    \"Name\": \"Guyana\"\n  },\n  {\n    \"Code\": \"HT\",\n    \"Name\": \"Haiti\"\n  },\n  {\n    \"Code\": \"HM\",\n    \"Name\": \"Heard Island and McDonald Islands\"\n  },\n  {\n    \"Code\": \"VA\",\n    \"Name\": \"Holy See (Vatican City State)\"\n  },\n  {\n    \"Code\": \"HN\",\n    \"Name\": \"Honduras\"\n  },\n  {\n    \"Code\": \"HK\",\n    \"Name\": \"Hong Kong\"\n  },\n  {\n    \"Code\": \"HU\",\n    \"Name\": \"Hungary\"\n  },\n  {\n    \"Code\": \"IS\",\n    \"Name\": \"Iceland\"\n  },\n  {\n    \"Code\": \"IN\",\n    \"Name\": \"India\"\n  },\n  {\n    \"Code\": \"ID\",\n    \"Name\": \"Indonesia\"\n  },\n  {\n    \"Code\": \"IR\",\n    \"Name\": \"Iran, Islamic Republic of\"\n  },\n  {\n    \"Code\": \"IQ\",\n    \"Name\": \"Iraq\"\n  },\n  {\n    \"Code\": \"IE\",\n    \"Name\": \"Ireland\"\n  },\n  {\n    \"Code\": \"IM\",\n    \"Name\": \"Isle of Man\"\n  },\n  {\n    \"Code\": \"IL\",\n    \"Name\": \"Israel\"\n  },\n  {\n    \"Code\": \"IT\",\n    \"Name\": \"Italy\"\n  },\n  {\n    \"Code\": \"JM\",\n    \"Name\": \"Jamaica\"\n  },\n  {\n    \"Code\": \"JP\",\n    \"Name\": \"Japan\"\n  },\n  {\n    \"Code\": \"JE\",\n    \"Name\": \"Jersey\"\n  },\n  {\n    \"Code\": \"JO\",\n    \"Name\": \"Jordan\"\n  },\n  {\n    \"Code\": \"KZ\",\n    \"Name\": \"Kazakhstan\"\n  },\n  {\n    \"Code\": \"KE\",\n    \"Name\": \"Kenya\"\n  },\n  {\n    \"Code\": \"KI\",\n    \"Name\": \"Kiribati\"\n  },\n  {\n    \"Code\": \"KP\",\n    \"Name\": \"Korea, Democratic People's Republic of\"\n  },\n  {\n    \"Code\": \"KR\",\n    \"Name\": \"Korea, Republic of\"\n  },\n  {\n    \"Code\": \"KW\",\n    \"Name\": \"Kuwait\"\n  },\n  {\n    \"Code\": \"KG\",\n    \"Name\": \"Kyrgyzstan\"\n  },\n  {\n    \"Code\": \"LA\",\n    \"Name\": \"Lao People's Democratic Republic\"\n  },\n  {\n    \"Code\": \"LV\",\n    \"Name\": \"Latvia\"\n  },\n  {\n    \"Code\": \"LB\",\n    \"Name\": \"Lebanon\"\n  },\n  {\n    \"Code\": \"LS\",\n    \"Name\": \"Lesotho\"\n  },\n  {\n    \"Code\": \"LR\",\n    \"Name\": \"Liberia\"\n  },\n  {\n    \"Code\": \"LY\",\n    \"Name\": \"Libya\"\n  },\n  {\n    \"Code\": \"LI\",\n    \"Name\": \"Liechtenstein\"\n  },\n  {\n    \"Code\": \"LT\",\n    \"Name\": \"Lithuania\"\n  },\n  {\n    \"Code\": \"LU\",\n    \"Name\": \"Luxembourg\"\n  },\n  {\n    \"Code\": \"MO\",\n    \"Name\": \"Macao\"\n  },\n  {\n    \"Code\": \"MK\",\n    \"Name\": \"Macedonia, the Former Yugoslav Republic of\"\n  },\n  {\n    \"Code\": \"MG\",\n    \"Name\": \"Madagascar\"\n  },\n  {\n    \"Code\": \"MW\",\n    \"Name\": \"Malawi\"\n  },\n  {\n    \"Code\": \"MY\",\n    \"Name\": \"Malaysia\"\n  },\n  {\n    \"Code\": \"MV\",\n    \"Name\": \"Maldives\"\n  },\n  {\n    \"Code\": \"ML\",\n    \"Name\": \"Mali\"\n  },\n  {\n    \"Code\": \"MT\",\n    \"Name\": \"Malta\"\n  },\n  {\n    \"Code\": \"MH\",\n    \"Name\": \"Marshall Islands\"\n  },\n  {\n    \"Code\": \"MQ\",\n    \"Name\": \"Martinique\"\n  },\n  {\n    \"Code\": \"MR\",\n    \"Name\": \"Mauritania\"\n  },\n  {\n    \"Code\": \"MU\",\n    \"Name\": \"Mauritius\"\n  },\n  {\n    \"Code\": \"YT\",\n    \"Name\": \"Mayotte\"\n  },\n  {\n    \"Code\": \"MX\",\n    \"Name\": \"Mexico\"\n  },\n  {\n    \"Code\": \"FM\",\n    \"Name\": \"Micronesia, Federated States of\"\n  },\n  {\n    \"Code\": \"MD\",\n    \"Name\": \"Moldova, Republic of\"\n  },\n  {\n    \"Code\": \"MC\",\n    \"Name\": \"Monaco\"\n  },\n  {\n    \"Code\": \"MN\",\n    \"Name\": \"Mongolia\"\n  },\n  {\n    \"Code\": \"ME\",\n    \"Name\": \"Montenegro\"\n  },\n  {\n    \"Code\": \"MS\",\n    \"Name\": \"Montserrat\"\n  },\n  {\n    \"Code\": \"MA\",\n    \"Name\": \"Morocco\"\n  },\n  {\n    \"Code\": \"MZ\",\n    \"Name\": \"Mozambique\"\n  },\n  {\n    \"Code\": \"MM\",\n    \"Name\": \"Myanmar\"\n  },\n  {\n    \"Code\": \"NA\",\n    \"Name\": \"Namibia\"\n  },\n  {\n    \"Code\": \"NR\",\n    \"Name\": \"Nauru\"\n  },\n  {\n    \"Code\": \"NP\",\n    \"Name\": \"Nepal\"\n  },\n  {\n    \"Code\": \"NL\",\n    \"Name\": \"Netherlands\"\n  },\n  {\n    \"Code\": \"NC\",\n    \"Name\": \"New Caledonia\"\n  },\n  {\n    \"Code\": \"NZ\",\n    \"Name\": \"New Zealand\"\n  },\n  {\n    \"Code\": \"NI\",\n    \"Name\": \"Nicaragua\"\n  },\n  {\n    \"Code\": \"NE\",\n    \"Name\": \"Niger\"\n  },\n  {\n    \"Code\": \"NG\",\n    \"Name\": \"Nigeria\"\n  },\n  {\n    \"Code\": \"NU\",\n    \"Name\": \"Niue\"\n  },\n  {\n    \"Code\": \"NF\",\n    \"Name\": \"Norfolk Island\"\n  },\n  {\n    \"Code\": \"MP\",\n    \"Name\": \"Northern Mariana Islands\"\n  },\n  {\n    \"Code\": \"NO\",\n    \"Name\": \"Norway\"\n  },\n  {\n    \"Code\": \"OM\",\n    \"Name\": \"Oman\"\n  },\n  {\n    \"Code\": \"PK\",\n    \"Name\": \"Pakistan\"\n  },\n  {\n    \"Code\": \"PW\",\n    \"Name\": \"Palau\"\n  },\n  {\n    \"Code\": \"PS\",\n    \"Name\": \"Palestine, State of\"\n  },\n  {\n    \"Code\": \"PA\",\n    \"Name\": \"Panama\"\n  },\n  {\n    \"Code\": \"PG\",\n    \"Name\": \"Papua New Guinea\"\n  },\n  {\n    \"Code\": \"PY\",\n    \"Name\": \"Paraguay\"\n  },\n  {\n    \"Code\": \"PE\",\n    \"Name\": \"Peru\"\n  },\n  {\n    \"Code\": \"PH\",\n    \"Name\": \"Philippines\"\n  },\n  {\n    \"Code\": \"PN\",\n    \"Name\": \"Pitcairn\"\n  },\n  {\n    \"Code\": \"PL\",\n    \"Name\": \"Poland\"\n  },\n  {\n    \"Code\": \"PT\",\n    \"Name\": \"Portugal\"\n  },\n  {\n    \"Code\": \"PR\",\n    \"Name\": \"Puerto Rico\"\n  },\n  {\n    \"Code\": \"QA\",\n    \"Name\": \"Qatar\"\n  },\n  {\n    \"Code\": \"RE\",\n    \"Name\": \"R�union\"\n  },\n  {\n    \"Code\": \"RO\",\n    \"Name\": \"Romania\"\n  },\n  {\n    \"Code\": \"RU\",\n    \"Name\": \"Russian Federation\"\n  },\n  {\n    \"Code\": \"RW\",\n    \"Name\": \"Rwanda\"\n  },\n  {\n    \"Code\": \"BL\",\n    \"Name\": \"Saint Barth�lemy\"\n  },\n  {\n    \"Code\": \"SH\",\n    \"Name\": \"Saint Helena, Ascension and Tristan da Cunha\"\n  },\n  {\n    \"Code\": \"KN\",\n    \"Name\": \"Saint Kitts and Nevis\"\n  },\n  {\n    \"Code\": \"LC\",\n    \"Name\": \"Saint Lucia\"\n  },\n  {\n    \"Code\": \"MF\",\n    \"Name\": \"Saint Martin (French part)\"\n  },\n  {\n    \"Code\": \"PM\",\n    \"Name\": \"Saint Pierre and Miquelon\"\n  },\n  {\n    \"Code\": \"VC\",\n    \"Name\": \"Saint Vincent and the Grenadines\"\n  },\n  {\n    \"Code\": \"WS\",\n    \"Name\": \"Samoa\"\n  },\n  {\n    \"Code\": \"SM\",\n    \"Name\": \"San Marino\"\n  },\n  {\n    \"Code\": \"ST\",\n    \"Name\": \"Sao Tome and Principe\"\n  },\n  {\n    \"Code\": \"SA\",\n    \"Name\": \"Saudi Arabia\"\n  },\n  {\n    \"Code\": \"SN\",\n    \"Name\": \"Senegal\"\n  },\n  {\n    \"Code\": \"RS\",\n    \"Name\": \"Serbia\"\n  },\n  {\n    \"Code\": \"SC\",\n    \"Name\": \"Seychelles\"\n  },\n  {\n    \"Code\": \"SL\",\n    \"Name\": \"Sierra Leone\"\n  },\n  {\n    \"Code\": \"SG\",\n    \"Name\": \"Singapore\"\n  },\n  {\n    \"Code\": \"SX\",\n    \"Name\": \"Sint Maarten (Dutch part)\"\n  },\n  {\n    \"Code\": \"SK\",\n    \"Name\": \"Slovakia\"\n  },\n  {\n    \"Code\": \"SI\",\n    \"Name\": \"Slovenia\"\n  },\n  {\n    \"Code\": \"SB\",\n    \"Name\": \"Solomon Islands\"\n  },\n  {\n    \"Code\": \"SO\",\n    \"Name\": \"Somalia\"\n  },\n  {\n    \"Code\": \"ZA\",\n    \"Name\": \"South Africa\"\n  },\n  {\n    \"Code\": \"GS\",\n    \"Name\": \"South Georgia and the South Sandwich Islands\"\n  },\n  {\n    \"Code\": \"SS\",\n    \"Name\": \"South Sudan\"\n  },\n  {\n    \"Code\": \"ES\",\n    \"Name\": \"Spain\"\n  },\n  {\n    \"Code\": \"LK\",\n    \"Name\": \"Sri Lanka\"\n  },\n  {\n    \"Code\": \"SD\",\n    \"Name\": \"Sudan\"\n  },\n  {\n    \"Code\": \"SR\",\n    \"Name\": \"Suriname\"\n  },\n  {\n    \"Code\": \"SJ\",\n    \"Name\": \"Svalbard and Jan Mayen\"\n  },\n  {\n    \"Code\": \"SZ\",\n    \"Name\": \"Swaziland\"\n  },\n  {\n    \"Code\": \"SE\",\n    \"Name\": \"Sweden\"\n  },\n  {\n    \"Code\": \"CH\",\n    \"Name\": \"Switzerland\"\n  },\n  {\n    \"Code\": \"SY\",\n    \"Name\": \"Syrian Arab Republic\"\n  },\n  {\n    \"Code\": \"TW\",\n    \"Name\": \"Taiwan, Province of China\"\n  },\n  {\n    \"Code\": \"TJ\",\n    \"Name\": \"Tajikistan\"\n  },\n  {\n    \"Code\": \"TZ\",\n    \"Name\": \"Tanzania, United Republic of\"\n  },\n  {\n    \"Code\": \"TH\",\n    \"Name\": \"Thailand\"\n  },\n  {\n    \"Code\": \"TL\",\n    \"Name\": \"Timor-Leste\"\n  },\n  {\n    \"Code\": \"TG\",\n    \"Name\": \"Togo\"\n  },\n  {\n    \"Code\": \"TK\",\n    \"Name\": \"Tokelau\"\n  },\n  {\n    \"Code\": \"TO\",\n    \"Name\": \"Tonga\"\n  },\n  {\n    \"Code\": \"TT\",\n    \"Name\": \"Trinidad and Tobago\"\n  },\n  {\n    \"Code\": \"TN\",\n    \"Name\": \"Tunisia\"\n  },\n  {\n    \"Code\": \"TR\",\n    \"Name\": \"Turkey\"\n  },\n  {\n    \"Code\": \"TM\",\n    \"Name\": \"Turkmenistan\"\n  },\n  {\n    \"Code\": \"TC\",\n    \"Name\": \"Turks and Caicos Islands\"\n  },\n  {\n    \"Code\": \"TV\",\n    \"Name\": \"Tuvalu\"\n  },\n  {\n    \"Code\": \"UG\",\n    \"Name\": \"Uganda\"\n  },\n  {\n    \"Code\": \"UA\",\n    \"Name\": \"Ukraine\"\n  },\n  {\n    \"Code\": \"AE\",\n    \"Name\": \"United Arab Emirates\"\n  },\n  {\n    \"Code\": \"GB\",\n    \"Name\": \"United Kingdom\"\n  },\n  {\n    \"Code\": \"US\",\n    \"Name\": \"United States\"\n  },\n  {\n    \"Code\": \"UM\",\n    \"Name\": \"United States Minor Outlying Islands\"\n  },\n  {\n    \"Code\": \"UY\",\n    \"Name\": \"Uruguay\"\n  },\n  {\n    \"Code\": \"UZ\",\n    \"Name\": \"Uzbekistan\"\n  },\n  {\n    \"Code\": \"VU\",\n    \"Name\": \"Vanuatu\"\n  },\n  {\n    \"Code\": \"VE\",\n    \"Name\": \"Venezuela, Bolivarian Republic of\"\n  },\n  {\n    \"Code\": \"VN\",\n    \"Name\": \"Viet Nam\"\n  },\n  {\n    \"Code\": \"VG\",\n    \"Name\": \"Virgin Islands, British\"\n  },\n  {\n    \"Code\": \"VI\",\n    \"Name\": \"Virgin Islands, U.S.\"\n  },\n  {\n    \"Code\": \"WF\",\n    \"Name\": \"Wallis and Futuna\"\n  },\n  {\n    \"Code\": \"EH\",\n    \"Name\": \"Western Sahara\"\n  },\n  {\n    \"Code\": \"YE\",\n    \"Name\": \"Yemen\"\n  },\n  {\n    \"Code\": \"ZM\",\n    \"Name\": \"Zambia\"\n  },\n  {\n    \"Code\": \"ZW\",\n    \"Name\": \"Zimbabwe\"\n  }\n]");

	public void SetupControls()
	{
		UsersGardenLabel.Text = $"{User.Username}'s Garden"; //Personalises the title label with the user's username

		//loops through each country in the countries object
		foreach (dynamic country in countries)
		{
			//adds the country to the picker
			UserCountryPicker.Items.Add(country.Name.ToString());
		}
	}

	public string GetCountryCode(string name)
	{
		string countryCode = ""; //initialises the string to be returned

		//loops through each entity in the deserialised country object
		foreach (dynamic country in countries)
		{
			//when the corresponding entity is found to the given name
			if (country.Name == name)
			{
				//gets that countrie's country code
				countryCode = country.Code;
			}
		}

		return countryCode; //returns the fetched country code
	}

	private void SaveButtonClicked(object sender, EventArgs e)
	{
		//aborts if the user has not selected a country
		if (UserCountryPicker.SelectedItem == null)
		{
			return;
		}

		string country = UserCountryPicker.SelectedItem.ToString(); //gets the selected country 
		string countryCode = GetCountryCode(country); //Get the country code of selected country 
		string postcode = UserPostCodeEntry.Text; //gets the entered postcode

		//Attempt API call
		try //Accept if call is successful
		{
			//calls the WeatherAPI class to use the geocoding API with the selected country and entered postcode
			string GeocodeResponse = OpenWeatherApiClass.ReverseGeocode(postcode, countryCode);

			//deserialises the geocode API response
			dynamic GeocodeData = JsonConvert.DeserializeObject(GeocodeResponse);

			//Update user's garden location in database
			UserAccountSql.UpdateGardenLocation(User.UserId, country, postcode, GeocodeData.lat.ToString(), GeocodeData.lon.ToString());

			//takes the user back to the garden page
			Application.Current.OpenWindow(new Window(new GardenPage()));
		}
		//Do not accept and abort if call fails
		catch (Exception ex)
		{
			return;
		}
	}
}