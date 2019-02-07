using System;
using System.Linq;
using System.Text;
using WCF.WindowsForms.ServiceReference;

namespace WCF.WindowsForms
{
    public partial class Form : System.Windows.Forms.Form
    {
        private WcfServiceClient clientService;

        public Form()
        {
            InitializeComponent();
        }

        private void buttonGetClients_Click(object sender, EventArgs e)
        {
            clientService = new WcfServiceClient();
            var builder = new StringBuilder();
            foreach (var client in clientService.GetClients())
            {
                builder.AppendFormat($"№{client.ID}: {client.Name} {client.Surname} {client.Midname}\n");
                var cart = clientService.GetByClient(client.ID);
                if(cart.Items.ToList().Count > 0)
                {
                    builder.AppendFormat("Orders:\nTitle | Type | Date | Quantity\n");
                }
                foreach (var item in cart.Items)
                {
                    builder.AppendFormat($"* {item.Item.Title} - {item.Item.Type} - {item.Date} - {item.Count}\n");
                }
                builder.Append("\n");
            }
            richTextBox.Text = builder.ToString();
            clientService.Close();
        }

        private void buttonGetItems_Click(object sender, EventArgs e)
        {
            clientService = new WcfServiceClient();
            var builder = new StringBuilder();
            builder.AppendFormat("ID | Title | Type\n");
            foreach (var item in clientService.GetGoods())
            {
                builder.AppendFormat($"№{item.ID}: {item.Title} - {item.Type}\n\n");
            }
            richTextBox.Text = builder.ToString();
            clientService.Close();
        }

        private void buttonGetOrderGroup_Click(object sender, EventArgs e)
        {
            clientService = new WcfServiceClient();
            var builder = new StringBuilder();
            builder.AppendFormat("ID | Title | Type | Quantity\n");
            foreach (var item in clientService.GetOrdersGroup())
            {
                builder.AppendFormat($"№{item.Item.ID}: {item.Item.Title} - {item.Item.Type} - {item.Count}\n\n");
            }
            richTextBox.Text = builder.ToString();
            clientService.Close();
        }

        private async void buttonAsync_ClickAsync(object sender, EventArgs e)
        {
            clientService = new WcfServiceClient();
            var result = await clientService.GetGoodsAsync();
            var builder = new StringBuilder();
            builder.AppendFormat("ID | Title | Type\n");
            foreach (var item in result)
            {
                builder.AppendFormat($"№{item.ID}: {item.Title} - {item.Type}\n\n");
            }
            richTextBox.Text = builder.ToString();
            clientService.Close();
        }

        private void buttonGetHits_Click(object sender, EventArgs e)
        {
            clientService = new WcfServiceClient();
            var builder = new StringBuilder();
            var result = clientService.TotalHits();
            builder.AppendFormat("Total requests:\n");
            builder.AppendFormat($"'GetClients' - {result.GetClientsRequest}\n");
            builder.AppendFormat($"'GetByClient' - {result.GetByClientRequest}\n");
            builder.AppendFormat($"'GetGoods' - {result.GetGoodsRequest}\n");
            builder.AppendFormat($"'GetOrders' - {result.GetOrdersRequest}\n");
            builder.AppendFormat($"'Total Requests' - {result.TotalRequest}\n");
            richTextBox.Text = builder.ToString();
            clientService.Close();
        }
    }
}