using Business.Inovacao;

namespace CentralInovacao.Models
{
    public class AreaLocal : ModelArea
    {
        private bool _isSelected;

        public bool IsSelected { get => _isSelected; set => _isSelected = value; }
    }
}
