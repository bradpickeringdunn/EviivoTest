using TextMatch.Domain;
using TextMatch.Web.Models;
using NLog;
using System;
using System.Linq;

namespace TextMatch.Web.Actions
{
    /// <summary>
    /// Action for getting subtext positions.
    /// </summary>
    public class StringMatchAction<T> where T : class
    {
        private ILogger logger;
        private ITextMatch stringMatch;

        public StringMatchAction(ILogger logger, ITextMatch stringMatch)
        {
            this.stringMatch = stringMatch;
            this.logger = logger;
        }

        public Func<TestMatchViewModel, T> OnComplete { get; set; }
        
        //Execute the action.
        public T Execute(TestMatchViewModel model)
        {
            try
            {
                var output = stringMatch.Match(model.Text, model.SubText);

                if (output.Any())
                {
                    model.Output = output;
                }
                else
                {
                    model.ErrorMessage = "There is no output";
                }
            }
            catch(Exception ex)
            {
                logger.Log(LogLevel.Fatal, "Error getting substring positions", ex);
                model.ErrorMessage = "There is no output";
            }

            return OnComplete(model);
        }
    }
}
