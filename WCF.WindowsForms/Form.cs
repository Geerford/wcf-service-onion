using System;
using System.Linq;
using System.Text;
using WCF.WindowsForms.Services;
using System.Collections.Generic;
using Service.DTO;
using System.ComponentModel;

namespace WCF.WindowsForms
{
    public partial class Form : System.Windows.Forms.Form
    {
        private ClientService service;

        public Form()
        {
            InitializeComponent();
            InitializeHost();
        }

        private void InitializeHost()
        {
            service = new ClientService(UpdateClientCount, (customers) => FillRichTextBox("Request from queue", customers));
            service.Initalize();
        }

        private void UpdateClientCount(RequestModel counter)
        {
            Invoke((Action)(() => labelClient.Text = $"Current clients: {counter.TotalRequest}"));
        }

        private void FillRichTextBox(string source, IEnumerable<CustomerDTO> customers)
        {
            var builder = new StringBuilder();
            builder.AppendLine(source);
            foreach (var customer in customers)
            {
                builder.AppendFormat($"№{customer.ID}: {customer.Name} {customer.Surname} {customer.Midname}\n");
                if (customer.Cart.Items.ToList().Count > 0)
                {
                    builder.AppendFormat("Orders:\nTitle | Type | Date | Quantity\n");
                }
                foreach (var item in customer.Cart.Items)
                {
                    builder.AppendFormat($"* {item.Item.Title} - {item.Item.Type} - {item.Date} - {item.Count}\n");
                }
                builder.Append("\n");
            }
            Invoke((Action)(() => richTextBox.Text += builder.ToString()));
        }

        private void FillRichTextBox(string source, IEnumerable<CustomerDTO> customers, IEnumerable<GoodsDTO> goods)
        {
            var builder = new StringBuilder();
            builder.AppendLine(source);
            foreach (var customer in customers)
            {
                builder.AppendFormat($"№{customer.ID}: {customer.Name} {customer.Surname} {customer.Midname}\n");
                if (customer.Cart.Items.ToList().Count > 0)
                {
                    builder.AppendFormat("Orders:\nTitle | Type | Date | Quantity\n");
                }
                foreach (var item in customer.Cart.Items)
                {
                    builder.AppendFormat($"* {item.Item.Title} - {item.Item.Type} - {item.Date} - {item.Count}\n");
                }
                builder.Append("\n");
            }
            builder.AppendLine(source);
            builder.AppendFormat("ID | Title | Type\n");
            foreach (var item in goods)
            {
                builder.AppendFormat($"№{item.ID}: {item.Title} - {item.Type}\n\n");
            }
            Invoke((Action)(() => richTextBox.Text += builder.ToString()));
        }

        private void FillRichTextBox(string source, IEnumerable<GoodsDTO> goods)
        {
            var builder = new StringBuilder();
            builder.AppendLine(source);
            builder.AppendFormat("ID | Title | Type\n");
            foreach (var item in goods)
            {
                builder.AppendFormat($"№{item.ID}: {item.Title} - {item.Type}\n\n");
            }
            Invoke((Action)(() => richTextBox.Text += builder.ToString()));
        }

        private async void buttonGetClients_Click(object sender, EventArgs e)
        {
            var customers = await service.GetCustomersAsync().ConfigureAwait(false);
            FillRichTextBox("Direct request", customers);
        }

        private async void buttonGetItems_Click(object sender, EventArgs e)
        {
            var goods = await service.GetGoodsAsync().ConfigureAwait(false);
            FillRichTextBox("Direct request", goods);
        }

        private async void buttonAsync_ClickAsync(object sender, EventArgs e)
        {
            await service.SendRequestAsync();
        }

        private void buttonGetHits_Click(object sender, EventArgs e)
        {
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            service.Dispose();
            base.OnClosing(e);
        }
    }
}