using System.Reflection.Emit;
using System.Text.Json;

namespace ApuWeather;
//-----------------------------------------------------------------------------------------------------------------------------
public partial class MainPage : ContentPage
{
	const string url ="https//:api.hgbrasil.com/weather?woeid=455926&key=576e0ce9";
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

			}
	}


//-----------------------------------------------------------------------------------------------------------------------------
		void LayoutTest()
			{
				resposta.results.temp=21;
				resposta.results.description="Nublado";
				resposta.results.city="Apucarana-PR";
				resposta.results.rain=88.2;
				resposta.results.humidity=88.2;
				resposta.results.sunrise="6:22";
				resposta.results.sunset="18:44";
				resposta.results.wind_speedy=3;
				resposta.results.wind_direction="373 N";
				resposta.results.moon_phase="Nov";

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
				labelDirecaoWind.Text= resposta.results.wind_direction;
				if (resposta.results.moon_phase=="full")
					labelMoonFase.Text = "Cheia";
				else if (resposta.results.moon_phase=="new")
					labelMoonFase.Text = "Nova";

				if (resposta.results.currently=="dia")
					{
						if (resposta.results.rain>=10)
							imageBackground.Source="rainyday.jpg";
						else if (resposta.results.cloudiness>=10)
							imageBackground.Source="cloudyday.jpg";
						else
							imageBackground.Source="sunny.jpg";
					}
				else
					{
						if (resposta.results.rain>=10)
							imageBackground.Source="rainynight.jpg";
						else if (resposta.results.cloudiness>=10)
							imageBackground.Source="cloudynight.jpg";
						else
							imageBackground.Source="night.jpg";
					}
			}

//-----------------------------------------------------------------------------------------------------------------------------
	


}

