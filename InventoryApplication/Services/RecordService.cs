using InventoryApplication.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace InventoryApplication.Services
{
    public class RecordService
    {
        static SQLiteAsyncConnection db;
        String databasePath = Path.Combine(FileSystem.AppDataDirectory, "MyData.db");

        public static readonly AsyncLazy<RecordService> Instance = new AsyncLazy<RecordService>(async () =>
        {
            var instance = new RecordService();
            CreateTableResult result = await db.CreateTableAsync<Record>();
            return instance;
        });
        public RecordService()
        {
            db = new SQLiteAsyncConnection(databasePath, SQLite.SQLiteOpenFlags.ReadWrite | SQLite.SQLiteOpenFlags.SharedCache);
        }

        public Task<int> AddRecord(Record item)
        {
            return db.InsertAsync(item);
        }

        public Task<int> RemoveRecord(Record item)
        {
            return db.DeleteAsync(item);
        }

        public Task<int> UpdateRecord(Record item)
        {
            return db.UpdateAsync(item);
        }

        public Task<Record> GetItem(Record item)
        {
            return db.Table<Record>().Where(i => item.Id == i.Id).FirstOrDefaultAsync();
        }
        public Task<List<Record>> GetItemsAsync()
        {
            return db.Table<Record>().ToListAsync();
        }
    }
}
