using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralInovacao.Models
{
    public class ModelGenericLocal
    {
        private int    _id;
        private string _description;

        public int Id { get => _id; set => _id = value; }
        public string Description { get => _description; set => _description = value; }
    }
}
