using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using NLog;

namespace Company.Function
{
    public class TimerTrigger1
    {
        private readonly ILogger<TimerTrigger1> _logger;
        private readonly Logger _nlogger;

        public TimerTrigger1(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<TimerTrigger1>();
            _nlogger = LogManager.GetCurrentClassLogger();
            _nlogger.Info("timer trigger constructor nlog");
        }

        [Function("TimerTrigger1")]
        public void Run([TimerTrigger("0 */5 * * * *")] TimerInfo myTimer)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            _nlogger.Info($"C# Timer trigger function executed at: {DateTime.Now} | nlog");

            if (myTimer.ScheduleStatus is not null)
            {
                _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
                _nlogger.Info($"Next timer schedule at: {myTimer.ScheduleStatus.Next} | nlog");
            }
        }
    }
}
