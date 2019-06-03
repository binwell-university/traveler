﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Traveler.DAL.DataObjects;
using Traveler.DAL.DataServices;
using Xamarin.Forms;

namespace Traveler.BL.ViewModels.Planning
{
    class CalendarViewModel : BaseViewModel
    {
        public DateTime Date
        {
            get => Get<DateTime>();
            set
            {
                Set(value);
                GetData();
            }
        }

        public (DateTime startDate, DateTime endDate) NewTravelDates
        {
            get => Get<(DateTime, DateTime)>();
            set => Set(value);
        }

        public List<TravelDataObject> Travels
        {
            get => Get<List<TravelDataObject>>();
            private set => Set(value);
        }

        public ICommand GoToTravelNameCommand
        {
            get
            {
                return new Command(
                    execute: () =>
                    {
                        NavigateTo(AppPages.TravelName, null, dataToLoad: new Dictionary<string, object>() { { "Dates", NewTravelDates } });
                    });
            }
        }

        public ICommand GoToEventsListCommand
        {
            get
            {
                return new Command(
                    execute: (parameter) =>
                    {
                        NavigateTo(AppPages.EventsList, null, dataToLoad: new Dictionary<string, object>() { { "parameter", parameter } });
                    });
            }
        }

        public override async Task OnPageAppearing()
        {
            NewTravelDates = default((DateTime, DateTime));
            GetData();
        }

        private async Task GetData()
        {
            State = PageState.Loading;
            var result = await DataServices.TravelerDataService.GetTravelsOfMonthAsync(Date, CancellationToken);
            if (result.IsValid)
            {
                Travels = result.Data;
                State = PageState.Normal;
            }
            else
            {
                State = PageState.Error;
            }
        }

        public CalendarViewModel() : base()
        {            
            Date = DateTime.Today;
        }
    }
}
