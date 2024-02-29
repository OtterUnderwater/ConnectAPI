using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectAPI.Models
{
    /// <summary>
    /// Для доступа к Catalogs класс обязательно должен быть public
    /// Переписываем со схемы свойства для всех полей с большой буквы и public
    /// </summary>
    public class Catalogs
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }
        public string TimeResul { get; set; }
        public string Preparation { get; set; }
        public string Bio { get; set; }

    }
}
