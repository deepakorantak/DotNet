using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.FormFlow;
using TestBot.Models;

namespace TestBot.Dialog
{
    public class HotelDialog
    {
        public static readonly IDialog<string> dialog = 
           Chain.PostToChain()
                    .Select(m => m.Text)
                    .Switch(
                            new RegexCase<IDialog<string>>(
                                                            new Regex("^hi", RegexOptions.IgnoreCase),
                                                            (c, t) =>
                                                                    {
                                                                        return Chain.ContinueWith(new InitialDialog(),
                                                                                                        PostInitialContinuation);
                                                                    }
                                                            )
                            ,new DefaultCase<string, IDialog<string>>(
                                                            (c, t) =>
                                                            {
                                                                return Chain.ContinueWith(FormDialog.FromForm(RoomReservation.BuildForm, FormOptions.PromptInStart),
                                                                                                                PostReservation);
                                                            }
                                                                    )
                        )
                    .Unwrap()
                    .PostToUser();

        private static async Task<IDialog<string>> PostInitialContinuation(IBotContext context, IAwaitable<object> item)
        {
            var token = await item;
            var name =  String.Empty;
            context.UserData.TryGetValue("Name",out name);
            return Chain.Return($"Thank you ,{name} for authenticating");

            
        }

        private static async Task<IDialog<string>> PostReservation(IBotContext context, IAwaitable<object> item)
        {
            var token = await item;
            var name = String.Empty;
            context.UserData.TryGetValue("Name", out name);
            return Chain.Return($"Thank you ,{name} for using Hotel Bot !!");
        }


    }
    
}