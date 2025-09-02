using System.ComponentModel.DataAnnotations;

namespace LojaBrinquedos.Models
{
    public class Brinquedo
    {
        [Key] 
        public int Id_brinquedo { get; set; }

        public string Nome_brinquedo { get; set; } = string.Empty;
        public string Tipo_brinquedo { get; set; } = string.Empty;
        public string Classificacao { get; set; } = string.Empty;
        public string Tamanho { get; set; } = string.Empty;
        public decimal Preco { get; set; }
    }
}
