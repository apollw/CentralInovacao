using Business.Inovacao;
using CentralInovacao.ViewModel;
using Microsoft.Maui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralInovacao.Models
{
    public class Project:ModelProject
    {
        public ImageSource ThumbnailImage
        {
            get
            {
                if (string.IsNullOrEmpty(Thumb))
                {
                    return ImageSource.FromFile("sem_foto.png");
                }
                else
                {
                    try
                    {
                        byte[] imageBytes = System.Convert.FromBase64String(Thumb);
                        ImageSource imageSource = ImageSource.FromStream(() => 
                                                  new MemoryStream(imageBytes));
                        return imageSource;
                    }
                    catch (Exception ex)
                    {                        
                        Console.WriteLine($"{ex.Message}");
                        return ImageSource.FromFile("sem_foto.png");
                    }
                }
            }
        }
    }
}

