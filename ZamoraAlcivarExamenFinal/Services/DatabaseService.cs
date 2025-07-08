using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using ZamoraAlcivarExamenFinal.Models;
using System.Diagnostics;
using System.IO;
using Microsoft.Maui.Storage;


namespace ZamoraAlcivarExamenFinal.Services
{
    public class DatabaseService
    {
        SQLiteAsyncConnection Database;

        public DatabaseService()
        {
        }

        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            var result = await Database.CreateTableAsync<Suscripcion>();
        }

        public async Task<List<Suscripcion>> GetSuscripcionesAsync()
        {
            await Init();
            return await Database.Table<Suscripcion>().ToListAsync();
        }

        public async Task<int> SaveSuscripcionAsync(Suscripcion suscripcion)
        {
            await Init();
            return await Database.InsertAsync(suscripcion);
        }
    }

    public static class Constants
    {
        public const string DatabaseFilename = "Suscripciones.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            SQLite.SQLiteOpenFlags.ReadWrite |
            SQLite.SQLiteOpenFlags.Create |
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath =>
            Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
    }
}