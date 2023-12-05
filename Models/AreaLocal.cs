using Business.Inovacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralInovacao.Models
{
    public class AreaLocal:ModelArea
    {
        private bool _isSelected;

        public bool IsSelected { get => _isSelected; set => _isSelected = value; }
    }
}
