using ConnectAPI.Models;
using Newtonsoft.Json;
using ReactiveUI;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ConnectAPI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        /// <summary>
        /// При запуске конструктор запускает метод, делающий запрос к БД
        /// </summary>
        public MainWindowViewModel()
        {
            GetCatalogs();
        }

        /// <summary>
        /// Cоздаем поле catalogs
        /// </summary>
        private List<Catalogs> catalogs;

        /// <summary>
        /// Инициализируем свойство для данного поля
        /// RaiseAndSetIfChanged() обновляет экран, когда изменяет информацию!
        /// </summary>
        public List<Catalogs> Catalogs { get => catalogs; set => this.RaiseAndSetIfChanged(ref catalogs, value); }

        /// <summary>
        /// Task - класс, выполняющий асинхронные операции
        /// async выполняет метод в асинхронном потоке
        /// Не забываем указывть await при получении ответа или Content не сработает
        /// </summary>
        /// <returns></returns>
        public async Task GetCatalogs()
        {
            // Для начала создаем клиента
            HttpClient client = new HttpClient();
            // Отправляем запрос Get через клиента на сервер - await позволяет использовать его ассинхронно
            var response = await client.GetAsync(@"https://iis.ngknn.ru/NGKNN/%D0%9C%D0%B0%D0%BC%D1%88%D0%B5%D0%B2%D0%B0%D0%AE%D0%A1/MedicMadlab/api/Catalog");
            //получаем строку
            var str = response.Content.ReadAsStringAsync().Result;
            // Выбираем управление пакетами NuGet и устанавливаем в проект Newtonsoft.Json
            //вызываем свойство Catalogs и даем ему лист, десериализованные из языка Json.
            Catalogs = JsonConvert.DeserializeObject<List<Catalogs>>(str);
        }
    }
}
