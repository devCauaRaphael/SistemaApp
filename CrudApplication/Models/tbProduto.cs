﻿namespace CrudApplication.Models
{
    public class tbProduto
    {
        public int ?IdProduto { get; set; }
        public string ?NomeProduto { get; set; }
        public string ?Descricao { get; set; }
        public decimal ?Preco { get; set; }
        public int ?Quantidade { get; set; }

        public List<tbProduto> ?ListaProduto { get; set; }
    }
}
