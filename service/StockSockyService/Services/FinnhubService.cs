using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Localization.Internal;
using Newtonsoft.Json;
using StockSockyService.Data.Contexts;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebSocketSharp;

namespace StockSockyService.Services
{
    public class FinnhubService : IHostedService
    {
        private readonly string _key;

        private readonly WebSocket _socket;

        private readonly MainContext _context;

        private string[] _symbols;

        public FinnhubService(IConfiguration config, MainContext context)
        {
            _key = config.GetSection("Finnhub").GetSection("key").Value;

            _context = context;

            _socket = new WebSocket("wss://ws.finnhub.io?token=" + _key);
            _socket.OnMessage += (sender, e) => OnMessage(sender, e);
        }

        public void Print(string msg)
        {
            Console.WriteLine("[FinnhubService]: " + msg);
        }

        public void OnMessage(object sender, MessageEventArgs e)
        {
            var package = JsonConvert.DeserializeObject<FinnhubPackage>(e.Data);

            if(package.Type == "error")
            {
                Print("Error - " + package.Msg);

                return;
            }

            if(package.Type == "trade")
            {
                package.Data.ToList().ForEach(x =>
                {
                    Print($"{x.Symbol}:\n" +
                        $"\tLast price: {x.Price}\n" +
                        $"\tTimestamp: {x.Timestamp}\n" +
                        $"\tVolume: {x.Volume}\n");
                });
            }
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _symbols = _context.Stocks.Select(x => x.Symbol).ToArray();

            _socket.Connect();

            // send symbols to subscribe to
            foreach (var symbol in _symbols)
            {
                var package = new
                {
                    type = "subscribe",
                    symbol = symbol
                };

                _socket.Send(JsonConvert.SerializeObject(package));
            }

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _socket.Close();

            return Task.CompletedTask;
        }
    }
}
