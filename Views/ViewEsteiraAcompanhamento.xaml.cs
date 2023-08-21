using Microcharts;
using Microcharts.Maui;
using SkiaSharp;

namespace CentralInovacao.Views;

public partial class ViewEsteiraAcompanhamento : ContentPage
{
    //Fonte de Dados Hard-Coded
    ChartEntry[] entries = new[]
    {
        new ChartEntry(212)
        {
            Label= "Leanderson",
            ValueLabel = "112",
            Color=SKColor.Parse("#2c3e50")
        },
        new ChartEntry(248)
        {
            Label= "Edem",
            ValueLabel = "648",
            Color=SKColor.Parse("#77d065")
        },
        new ChartEntry(128)
        {
            Label= "Danilo",
            ValueLabel = "428",
            Color=SKColor.Parse("#b455b6")
        },
        new ChartEntry(514)
        {
            Label= "Bruce",
            ValueLabel = "214",
            Color=SKColor.Parse("#3498db")
        }
    };
    ChartEntry[] entries2 = new[]
{
        new ChartEntry(212)
        {
            Label= "Finalizadas",
            ValueLabel = "10",
            Color=SKColor.Parse("#2c3e50")
        },
        new ChartEntry(248)
        {
            Label= "Pendentes",
            ValueLabel = "13",
            Color=SKColor.Parse("#77d065")
        }
    };
    ChartEntry[] entries3 = new[]
{
        new ChartEntry(212)
        {
            Label= "Infra",
            ValueLabel = "112",
            Color=SKColor.Parse("#2c3e50")
        },
        new ChartEntry(248)
        {
            Label= "Inovação",
            ValueLabel = "648",
            Color=SKColor.Parse("#77d065")
        },
        new ChartEntry(128)
        {
            Label= "TI Sistemas",
            ValueLabel = "428",
            Color=SKColor.Parse("#b455b6")
        }
    };
    public ViewEsteiraAcompanhamento()
    {
        InitializeComponent();

        _chartView.Chart = new BarChart
        {
            Entries = entries, //Fonte de Dados
            LabelOrientation = Orientation.Horizontal,
            ValueLabelOrientation = Orientation.Horizontal,
        };
        _chartView1.Chart = new DonutChart
        {
            Entries = entries2, //Fonte de Dados
            LabelMode = LabelMode.RightOnly                  
        };

        _chartView2.Chart = new PieChart 
        { 
            Entries = entries3,
            LabelMode = LabelMode.RightOnly
        };

    }
}