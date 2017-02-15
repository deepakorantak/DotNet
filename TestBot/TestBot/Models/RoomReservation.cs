using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
namespace TestBot.Models
{
    public enum BedSizeOption
    {
        King = 1,
        Queen = 2,
        Double = 3,
        Single = 4
    }

    public enum AmentiesOption
    {
        gym = 1,
        parking = 2,
        wifi = 3,
        laundry = 4,
        pool = 5
    }

    [Serializable]
    public class RoomReservation
    {

        public BedSizeOption? BedSize;
        public int? NumberOfGuests;
        public DateTime? CheckinDate;
        public int? NumberOfDaysStay;
        public List<AmentiesOption> AmenitiesList;

        public static IForm<RoomReservation> BuildForm()
        {
            return new FormBuilder<RoomReservation>()
                    .Message("Welocme to the Hotel Bot !!")
                    .Build();  
        }
    }
}