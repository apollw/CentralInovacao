using Business.Inovacao;
using CentralInovacao.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralInovacao.Models
{
    public class Project:ModelProject
    {
        //Propriedade que trata de carregar as imagens em base64 e convertê-las
        public ImageSource ThumbnailImage
        {
            get
            {
                if (string.IsNullOrEmpty(Thumb)) // Verifica se Thumb é nulo ou vazio
                {
                    return ImageSource.FromFile("sem_foto.png"); // Retorna a imagem padrão
                }
                else
                {
                    try
                    {
                        // Converte a string base64 de volta para um array de bytes
                        byte[] imageBytes = System.Convert.FromBase64String(Thumb);

                        // Cria uma ImageSource a partir dos bytes da imagem
                        ImageSource imageSource = ImageSource.FromStream(() => new MemoryStream(imageBytes));

                        return imageSource;
                    }
                    catch (Exception ex)
                    {
                        // Em caso de erro na conversão, você pode retornar a imagem padrão ou tratar o erro de outra maneira
                        Console.WriteLine($"Erro ao converter a string base64 para ImageSource: {ex}");
                        return ImageSource.FromFile("sem_foto.png"); // Retorna a imagem padrão
                    }
                }
            }
        }
    }
}

