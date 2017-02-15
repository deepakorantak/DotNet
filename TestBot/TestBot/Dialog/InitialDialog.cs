using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;

namespace TestBot.Dialog
{
    [Serializable]
    public class InitialDialog : IDialog
    {
        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("Hi I'm Admin Bot");
            await Reply(context);
            context.Wait(NextMessageAync);
        }

        public async Task Reply(IDialogContext context)
        {
           
            string userName = String.Empty;
            context.UserData.TryGetValue("Name", out userName);
           
            if (string.IsNullOrEmpty(userName))
            {
                await context.PostAsync("What is your name?");
                context.UserData.SetValue("GetName", true);
            }
            else
            {
                await context.PostAsync($"Hi {userName} How can I help you today ?");
            }
        }

        private async Task NextMessageAync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var msg =  await result;
            string  userName = String.Empty;
            bool getName = false;

            context.UserData.TryGetValue("Name", out userName);
            context.UserData.TryGetValue("GetName", out getName);

            if (getName)
            {
                userName = msg.Text;
                context.UserData.SetValue("Name", userName);
                context.UserData.SetValue("GetName", false);
            }

            await Reply(context);
            context.Done(msg);
            
        }
    }
}