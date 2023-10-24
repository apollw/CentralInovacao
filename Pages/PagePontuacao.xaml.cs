using System;
using System.IO;
using System.Threading.Tasks;

namespace CentralInovacao.Pages;

public partial class PagePontuacao : ContentPage
{
	public PagePontuacao()
	{
		InitializeComponent();

        Task task   = LoadTextFileAsync("Ranking.txt"  , _lblRanking);
        Task task2  = LoadTextFileAsync("Medalhas.txt" , _lblMedalhas);
        Task task3  = LoadTextFileAsync("Pontuacao.txt", _lblPontuacao);

    }

    public async Task LoadTextFileAsync(string fileName, Label label)
    {
        try
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync(fileName);
            using var reader = new StreamReader(stream);

            string fileContent = reader.ReadToEnd();

            label.Text = fileContent;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao carregar o arquivo de texto: " + ex.Message);
        }
    }
}