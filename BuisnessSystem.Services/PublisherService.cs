using BuisnessSystem.Models;
using BuisnessSystem.Services.Abstract;
using System.Linq;

namespace BuisnessSystem.Services
{
    public class PublisherService
    {
        public event ReporterDelegate ReportEvent;

        public Service _service;

        public void Add(Journal journal)
        {
            _service.Insert(journal);
            _service.Dispose();

            ReportEvent.Invoke("Добавлен новый номер! Скупитесь, не пожалеете!!!!!!");
        }

        public void Deliver(Client client, Journal journal)
        {
            var existingClient = new Client { Id = client.Id };
            var existingJournal = new Journal { Id = journal.Id };

            var existingOrder = (from o in _service._context.Orders
                             join cl in _service._context.Clients on o.Client.Id equals cl.Id
                             join j in _service._context.Journals on o.Journal.Id equals j.Id
                             where cl.TelephoneNumber == existingClient.TelephoneNumber && j.Name == existingJournal.Name && o.IsDelivered == false
                             select o).First();
;           existingOrder.IsDelivered = true;

            _service.Update(existingOrder);
            _service.Dispose();

            ReportEvent.Invoke("Ваша покупка была доставлена! Покупайте еще!");
        }

        public void UnloadReport()
        {
            var reportSumPrice = _service._context.Orders.Sum(o => o.Journal.Price);
            var reportCountJournal = _service._context.Orders.Where(o => o.IsDelivered == true).Count();
        }
    }
}
