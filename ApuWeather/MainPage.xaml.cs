using System.Reflection.Emit;
using System.Text.Json;

namespace ApuWeather;

public partial class MainPage : ContentPage
{
	const string url ="https//:api.hgbrasil.com/weather?woeid=455926&key=576e0ce9";
	Results results;
	Resposta resposta;

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




	public MainPage()
	{
		InitializeComponent();

		 LayoutTest();
		 PreencherTela();
		 AttTempo();

	}

	
		void LayoutTest()
			{
				resposta.temp=21;
				resposta.description="Nublado";
				resposta.city="Apucarana-PR";
				resposta.rain=88.2;
				resposta.humidity=88.2;
				resposta.sunrise="6:22";
				resposta.sunset="18:44";
				resposta.wind_speedy=3;
				resposta.wind_direction="373 N";
				resposta.moon_phase="Nov";

			}

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
				labelMoonFase.Text= resposta.results.moon_phase;
			}

		void Background()
	


}

