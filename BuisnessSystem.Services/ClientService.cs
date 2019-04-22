using BuisnessSystem.Models;
using BuisnessSystem.Services.Abstract;

namespace BuisnessSystem.Services
{
    public class ClientService
    {
        public event ReporterDelegate ReportEvent;

        public Service _service;
        
        public void Subscribe(Client client, int monthCount)
        {
            _service.Insert(client);
            _service.Dispose();

            ReportEvent.Invoke($"Вы оформили подписку на {monthCount} месяцев(а).");
        }

        public void Pay(Client client, Journal journal)
        {
            var existingClient = new Client { Id = client.Id };
            var existingJournal = new Journal { Id = journal.Id };

            _service._context.Clients.Attach(client);
            _service._context.Journals.Attach(journal);

            var order = new Order
            {
                Client = existingClient,
                Journal = existingJournal,
                IsDelivered = false
            };

            _service.Insert(order);

            _service.Dispose();

            ReportEvent.Invoke($"Вы оплатили покупку стоимостью {existingJournal.Price} тенге. Ждите доставки");
        }

        public void Unsubscribe(Client client)
        {
            _service.Delete(client);
            _service.Dispose();

            ReportEvent.Invoke("Вы отказались от подписки.");
        }
    }
}
