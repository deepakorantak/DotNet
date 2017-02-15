using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using TestBot.Models;

namespace TestBot.Dialog
{
    [LuisModel("4fdeb507-6a9a-4111-b471-dc39fdacf843", "bd77ccd97b5a41e196bfe75d66a30ad3")]
    [Serializable]
    public class HotelDialogLUIS : LuisDialog<RoomReservation>
    {
        private readonly BuildFormDelegate<RoomReservation> _reserveRoom;
        public HotelDialogLUIS(BuildFormDelegate<RoomReservation> ireserveRoom)
        {
            _reserveRoom = ireserveRoom;
        }

        [LuisIntent("")]
        public async Task None(IDialogContext context,LuisResult result)
        {
            await context.PostAsync("I'm sorry don't understand what you requested for");
            context.Wait(MessageReceived);
        }

        [LuisIntent("Greeting")]
        public async Task GreetingDialog(IDialogContext context, LuisResult result)
        {
             context.Call(new InitialDialog(),Callback);            
        }

        [LuisIntent("Reservation")]
        public async Task RoomBooking(IDialogContext context, LuisResult result)
        {
            var reservationForm = new FormDialog<RoomReservation>(new RoomReservation(),this._reserveRoom,FormOptions.PromptInStart);
           context.Call<RoomReservation>(reservationForm,Callback);
        }

        [LuisIntent("QueryListAmenities")]
        public async Task ListOfAmenities(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("1.Gym \t 2.Parking \t 3.Wifi \t 4.Laundry \t  5.Pool ");
            context.Wait(MessageReceived);
        }
    

        [LuisIntent("QueryAmenity")]
        public async Task QueryAmenities(IDialogContext context, LuisResult result)
        {
            foreach (var entity in result.Entities.Where(r=> r.Type == "Amenity"))
            {
                var value = entity.Entity.ToLower();
                if(value == "gym" || value == "pool" || value == "wifi" || value == "wi-fi" || value == "laundry" || value == "parking")
                {
                    await context.PostAsync("Yes!! We have this amenity");
                    context.Wait(MessageReceived);
                    return;
                }
                else
                {
                    await context.PostAsync("Sorry...This is not available with us");
                    context.Wait(MessageReceived);
                    return;
                }
            }

            await context.PostAsync("Sorry...This is not available with us");
            context.Wait(MessageReceived);
            return;
        }
        
        private async Task Callback(IDialogContext context, IAwaitable<object> result)
        {
            context.Wait(MessageReceived);
        }
    }
}