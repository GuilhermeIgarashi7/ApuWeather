using System.Reflection.Emit;

namespace ApuWeather;

public partial class MainPage : ContentPage
{
	Results Resultados;



	public MainPage()
	{
		InitializeComponent();

		 Resultados = new Results();
		 LayoutTest();
		 PreencherTela();

	}
	
		void LayoutTest()
			{
				Resultados.temp=21;
				Resultados.description="Nublado";
				Resultados.city="Apucarana-PR";
				Resultados.rain=88.2;
				Resultados.humidity=88.2;
				Resultados.sunrise="6:22";
				Resultados.sunset="18:44";
				Resultados.wind_speedy=3;
				Resultados.wind_direction="373 N";
				Resultados.moon_phase="Nov";

			}

		void PreencherTela()
			{
				labelTemp.Text= Resultados.temp.ToString();
				labelSky.Text= Resultados.description;
				labelCidade.Text= Resultados.city;
				labelChuva.Text= Resultados.rain.ToString();
				labelHumidade.Text= Resultados.humidity.ToString();
				labelAmanhecer.Text= Resultados.sunrise;
				labelAnoitecer.Text= Resultados.sunset;
				labelForcaWind.Text= Resultados.wind_speedy.ToString();
				labelDirecaoWind.Text= Resultados.wind_direction;
				labelMoonFase.Text= Resultados.moon_phase;
			}
	


}

