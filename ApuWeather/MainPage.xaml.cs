using System.Reflection.Emit;
using System.Text.Json;

namespace ApuWeather;
//-----------------------------------------------------------------------------------------------------------------------------
public partial class MainPage : ContentPage
{
	const string url ="https://api.hgbrasil.com/weather?woeid=455927&key=576e0ce9";
	Resposta resposta;

	
//-----------------------------------------------------------------------------------------------------------------------------

	public MainPage()
	{
		InitializeComponent();


		 AttTempo();


	}
//-----------------------------------------------------------------------------------------------------------------------------
		async void AttTempo()
	{
			try
			{
				var HttpClient = new HttpClient();
				var Response = await HttpClient.GetAsync(url);
				if (Response.IsSuccessStatusCode)
					{
						var content = await Response.Content.ReadAsStringAsync();
						resposta = JsonSerializer.Deserialize<Resposta>(content);
						
						PreencherTela();
					}
			}
			catch(Exception e)
			{
				System.Diagnostics.Debug.WriteLine(e);
			}
	}

//-----------------------------------------------------------------------------------------------------------------------------
		void PreencherTela()
			{
				labelTemp.Text= resposta.results.temp.ToString();
				labelSky.Text= resposta.results.description;
				labelCidade.Text= resposta.results.city;
				labelChuva.Text= resposta.results.rain.ToString();
				labelHumidade.Text= resposta.results.humidity.ToString();
				labelAmanhecer.Text= resposta.results.sunrise;
				labelAnoitecer.Text= resposta.results.sunset;
				labelForcaWind.Text= resposta.results.wind_speedy.ToString();
				labelDirecaoWind.Text= resposta.results.wind_direction.ToString();

				if (resposta.results.moon_phase=="full")
					labelMoonFase.Text = "Cheia";

				else if (resposta.results.moon_phase=="new")
					labelMoonFase.Text = "Nova";

				else if (resposta.results.moon_phase=="waxing_crescent")
					labelMoonFase.Text = "Lua Crescente";

				else if (resposta.results.moon_phase=="first_quarter")
					labelMoonFase.Text = "Quarto Crescente";

				else if (resposta.results.moon_phase=="last_quarter")
					labelMoonFase.Text = "Quarto Minguante";
				
				else if (resposta.results.moon_phase=="waxing_gibbous")
					labelMoonFase.Text = "Gibosa Crescente";
	
				else if (resposta.results.moon_phase=="waxing_crescent")
					labelMoonFase.Text = "Gibosa Minguante";
		
				else if (resposta.results.moon_phase=="waning_crescent")
					labelMoonFase.Text = "Lua Minguante";
			




				if (resposta.results.currently=="dia")
					{
						if (resposta.results.rain>=10)
							imagebackground.Source="rainyday.jpg";
						else if (resposta.results.cloudiness>=10)
							imagebackground.Source="cloudyday.jpg";
						else
							imagebackground.Source="sunny.jpg";
					}
				else
					{
						if (resposta.results.rain>=10)
							imagebackground.Source="rainynight.jpg";
						else if (resposta.results.cloudiness>=10)
							imagebackground.Source="cloudynight.jpg";
						else
							imagebackground.Source="night.jpg";
					}
			}

//-----------------------------------------------------------------------------------------------------------------------------
	


}

