﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.IO;
using SQLite;
using Traveler.Android;
using Traveler.DAL.DataServices.Database;

[assembly: Xamarin.Forms.Dependency(typeof(DatabaseConnectionAndroid))]
namespace Traveler.Android
{
    class DatabaseConnectionAndroid : IDatabaseConnection
    {
        public string GetConnectionString()
        {
            string dbName = "TravelerDB.db3";
            string path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), dbName);
            return path;
        }
    }
}