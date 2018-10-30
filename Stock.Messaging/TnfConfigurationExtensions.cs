using System;
using System.Threading;
using Microsoft.Extensions.Configuration;
using Stock.Domain.Commands;
using Stock.Domain.Events;
using Tnf.Bus.Queue;
using Tnf.Bus.Queue.RabbitMQ;

namespace Tnf.Configuration
{
    public static class TnfConfigurationExtensions
    {
        public static void ConfigureStockMessaging(this ITnfConfiguration tnfConfiguration, IConfiguration configuration)
        {
            ConfigurePublishedEvents(tnfConfiguration, configuration);
            ConfigurePubleshedCommands(tnfConfiguration, configuration);
            ConfigureListeningCommands(tnfConfiguration, configuration);
            ConfigureListeningEvents(tnfConfiguration, configuration);
        }

        private static void ConfigurePubleshedCommands(ITnfConfiguration tnfConfiguration, IConfiguration configuration)
        {
        }

        private static void ConfigureListeningEvents(ITnfConfiguration tnfConfiguration, IConfiguration configuration)
        {
        }

        private static void ConfigureListeningCommands(ITnfConfiguration tnfConfiguration, IConfiguration configuration)
        {
            var makeProductReservationCommand = TopicSetup.Builder
                            .New(s =>
                                    s.Message<MakeProductReservationCommand>()
                                    .AddKey(nameof(MakeProductReservationCommand)));

            var cancelProductReservationsCommand = TopicSetup.Builder
                            .New(s =>
                                    s.Message<CancelProductReservationsCommand>()
                                    .AddKey(nameof(CancelProductReservationsCommand)));

            // Cria uma Fila
            var queue = QueueSetup.Builder
               .New(s => s
                    .QueueName("Stock.Commands.Queue")
                    .AddTopics(makeProductReservationCommand)
                    .AddTopics(cancelProductReservationsCommand)
                    .Reliability(r => r
                        .AutoAck(false)
                        .AutoDeleteQueue(false)
                        .MaxMessageSize(256)
                        .PersistMessage(true))
                    .QoS(q => q
                        .PrefetchGlobalLimit(true)
                        .PrefetchLimit(100)
                        .PrefetchSize(0)));

            var eventExchangeRouter = ExchangeRouter
                .Builder
                .Factory()
                .Name("Stock.Commands.Exchange")
                .AddQueue(queue)
                .ServerAddress(configuration["RabbitMqHost"])
                .Type(ExchangeType.direct)
                .QueueChannel(QueueChannel.Amqp)
                .Reliability(isDurable: true, isAutoDelete: false, isPersistent: true)
                .SetExclusive(false)
                .AutomaticRecovery(
                    isEnable: true,
                    connectionTimeout: 15000,
                    networkRecoveryInterval: TimeSpan.FromSeconds(10))
                .MessageCollector(
                    refreshInterval: TimeSpan.FromMilliseconds(value: 2000),
                    timeout: TimeSpan.FromSeconds(60))
                .ShutdownBehavior(
                    graceful: new CancellationTokenSource(),
                    forced: new CancellationTokenSource())
                .Build();

            tnfConfiguration
                .BusClient()
                .AddSubscriber(e => eventExchangeRouter, e => new SubscriberListener(e, tnfConfiguration.ServiceProvider));
        }

        private static void ConfigurePublishedEvents(ITnfConfiguration tnfConfiguration, IConfiguration configuration)
        {
            var productCraeted = TopicSetup.Builder
                            .New(s =>
                                    s.Message<ProductCreated>()
                                    .AddKey(nameof(ProductCreated)));

            var productQuantityChanged = TopicSetup.Builder
                .New(s =>
                        s.Message<ProductQuantityChanged>()
                        .AddKey(nameof(ProductQuantityChanged)));

            var productReservationFailed = TopicSetup.Builder
                .New(s =>
                        s.Message<ProductReservationFailed>()
                        .AddKey(nameof(ProductReservationFailed)));

            var productReservationMade = TopicSetup.Builder
                .New(s =>
                        s.Message<ProductReservationMade>()
                        .AddKey(nameof(ProductReservationMade)));

            // Cria uma Fila
            var queue = QueueSetup.Builder
               .New(s => s
                    .QueueName("UnusedQueue")
                    .AddTopics(productCraeted)
                    .AddTopics(productQuantityChanged)
                    .AddTopics(productReservationFailed)
                    .AddTopics(productReservationMade)
                    .Reliability(r => r
                        .AutoAck(false)
                        .AutoDeleteQueue(true)
                        .MaxMessageSize(256)
                        .PersistMessage(false))
                    .QoS(q => q
                        .PrefetchGlobalLimit(true)
                        .PrefetchLimit(100)
                        .PrefetchSize(0)));

            var eventExchangeRouter = ExchangeRouter
                .Builder
                .Factory()
                .Name("Stock.Events")
                .AddQueue(queue)
                .ServerAddress(configuration["RabbitMqHost"])
                .Type(ExchangeType.direct)
                .QueueChannel(QueueChannel.Amqp)
                .Reliability(isDurable: true, isAutoDelete: false, isPersistent: true)
                .SetExclusive(false)
                .AutomaticRecovery(
                    isEnable: true,
                    connectionTimeout: 15000,
                    networkRecoveryInterval: TimeSpan.FromSeconds(10))
                .MessageCollector(
                    refreshInterval: TimeSpan.FromMilliseconds(value: 2000),
                    timeout: TimeSpan.FromSeconds(60))
                .ShutdownBehavior(
                    graceful: new CancellationTokenSource(),
                    forced: new CancellationTokenSource())
                .Build();

            tnfConfiguration
                .BusClient()
                .AddPublisher(e => eventExchangeRouter, e => new PublisherListener(e, tnfConfiguration.ServiceProvider));
        }
    }
}
