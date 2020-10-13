using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using HackLock.Server.Data;
using HackLock.Server.Data.Models;

namespace HackLock.Server.Services
{
    public interface ILoggingService
    {
        public void LogItem(EntryLogItem item);
        public IEnumerable<EntryLogItem> GetEntryLogItems(int count);
        public IEnumerable<EntryLogItem> GetAllEntryLogItems();
    }

    public class LoggingService : ILoggingService
    {
        private readonly ApplicationDbContext _dbContext;

        public LoggingService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public void LogItem(EntryLogItem item)
        {
            _dbContext.EntryLog.Add(item);
        }

        public IEnumerable<EntryLogItem> GetEntryLogItems(int count)
        {
            var item =
                _dbContext.EntryLog
                    .OrderByDescending(i =>
                        DateTime.Parse(i.Timestamp, CultureInfo.InvariantCulture).Ticks)
                    .Take(count)
                    .ToList();
            return item;
        }

        public IEnumerable<EntryLogItem> GetAllEntryLogItems()
        {
            return _dbContext.EntryLog
                .OrderByDescending(i =>
                    DateTime.Parse(i.Timestamp, CultureInfo.InvariantCulture).Ticks)
                .ToList();
        }
    }
}
