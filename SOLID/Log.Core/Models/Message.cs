using Log.Core.Enums;
using Log.Core.Exceptions;
using Log.Core.Utillities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log.Core.Models
{
    public class Message
    {
        private string createdTime;
        private string text;
        public Message(string createdTime, string text, ReportLevel reportLevel)
        {
            CreatedTime = createdTime;
            Text = text;
            ReportLevel = reportLevel;
        }

        //TODO: Validations

        public string CreatedTime
        {
            get
            {
                return createdTime;
            }
            set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new EmptyCreatedTimeException();
                }
                if (!DateTimeValidator.ValidateDateTimeFormat(value))
                {
                    throw new InvalidDateTimeFormatException();
                }
                createdTime = value;

            } 
        }
        public string Text 
        {
            get
            {
                return text;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new EmptyTextException();
                }
                text = value;

            }
        }
        public ReportLevel ReportLevel { get; set; }

    }
}
