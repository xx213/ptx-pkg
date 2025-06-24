using System;
using System.Threading.Tasks;


namespace PTXClassLibrary
{
    /// <summary>
    /// A static class representing a dictionary of currency symbols and their names.
    /// </summary>
    // TimerUtility.cs


    public class TimerUtility<T>
    {
        private readonly T component;
        private readonly Action<T> updateAction;
        private readonly string waitingMessage;
        private readonly int updateIntervalInSeconds;

        private System.Threading.Timer timer;

        public TimerUtility(T component, Action<T> updateAction, string waitingMessage = "Waiting...", int updateIntervalInSeconds = 1)
        {
            //this.component = component ?? throw new ArgumentNullException(nameof(component));
            this.updateAction = updateAction ?? throw new ArgumentNullException(nameof(updateAction));
            this.waitingMessage = waitingMessage;
            this.updateIntervalInSeconds = updateIntervalInSeconds;
        }

        public async Task RunAsync(Func<Task> asyncOperation)
        {
            timer = new System.Threading.Timer(_ =>
            {
                updateAction(component);
            }, null, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(updateIntervalInSeconds));

            await asyncOperation();

            timer.Dispose();
            updateAction(component);
        }
    }

}
